using Application.Authentication.CommonService;
using Bridge.Application.Interfaces;
using Bridge.Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Authentication.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, object>
    {
        private readonly IBridgeDbContext _dbContext;
        private readonly ICurrentUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public LoginUserCommandHandler(IBridgeDbContext dbContext, ICurrentUserService userService,
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration)
        {
            _dbContext = dbContext;
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<object> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);

            if (result.Succeeded)
            {
                var appUser = _userManager.Users.SingleOrDefault(r => r.Email == request.Email);
                IList<string> roles = await _userManager.GetRolesAsync(appUser);
                CommonHelpers helper = new CommonHelpers(_configuration);
                return await helper.GenerateJwtToken(request.Email, appUser, roles);
            }

            throw new ApplicationException("INVALID_LOGIN_ATTEMPT");
        }
    }
}
