using AutoMapper;
using Hospital.core.Base;
using Hospital.core.Features.Auth.Command.Model;
using Hospital.core.Features.Auth.Query.Response;
using Hospital.Services.Abstract;
using HospitalSystem.Data;
using HospitalSystem.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Hospital.core.Features.Auth.Command.Handler
{
    public class AuthCommandHandler : ResponseHandler,
        IRequestHandler<RegisterCommand, Response<RegisterResponse>>,
        IRequestHandler<LoginCommand, Response<LoginResponse>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtTokenService _jwtService;
        private readonly IMapper _mapper;
        private readonly AppDbContext context;
        public AuthCommandHandler(UserManager<AppUser> userManager, IJwtTokenService jwtService, IMapper mapper, AppDbContext context)
        {
            _userManager = userManager;
            _jwtService = jwtService;
            _mapper = mapper;
            this.context = context;
        }
        public async Task<Response<RegisterResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var existEmail = await _userManager.FindByEmailAsync(request.Email);
            if (existEmail != null)
            {
                return BadRequest<RegisterResponse>("User with this email already exists");
            }
            var user = _mapper.Map<AppUser>(request);
            var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var result = await _userManager.CreateAsync(user, request.Password);
                if (!result.Succeeded)
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    return BadRequest<RegisterResponse>($"Registration failed: {errors}");

                }
                var roleClaim = new Claim(ClaimTypes.Role, request.Role);
                var RoleResult = await _userManager.AddClaimAsync(user, roleClaim);
                if (!RoleResult.Succeeded)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    var errors = string.Join(", ", RoleResult.Errors.Select(e => e.Description));
                    return BadRequest<RegisterResponse>($"Failed to assign role claim: {errors}");

                }
                await transaction.CommitAsync(cancellationToken);
                var response = new RegisterResponse
                {
                    Message = "User registered successfully",
                    UserId = user.Id,
                    Email = user.Email
                };
                return Success(response);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }

        }

        public async Task<Response<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return Unauthorized<LoginResponse>("Invalid email or password");
            }
            var CheckPassword = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!CheckPassword)
            {
                return Unauthorized<LoginResponse>("Invalid email or password");
            }
            var roles = await _userManager.GetClaimsAsync(user);
            var token = await _jwtService.GenerateTokenAsync(user);
            var response = new LoginResponse
            {
                Token = token,
                UserId = user.Id,
                Email = user.Email,
            };
            return Success(response);
        }
    }
}
