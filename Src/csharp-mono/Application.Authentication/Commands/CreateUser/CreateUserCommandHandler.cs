using Application.Authentication.CommonService;
using Application.Interfaces;
using Bridge.Application.Interfaces;
using Bridge.Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Authentication.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, object>
    {
        private readonly IBridgeDbContext _dbContext;
        private readonly ICurrentUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public CreateUserCommandHandler(IBridgeDbContext dbContext, ICurrentUserService userService, 
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration)
        {
            _dbContext = dbContext;
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<object> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = new ApplicationUser
                {
                    UserName = request.Email,
                    Email = request.Email
                };

                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);

                    IList<string> roles = await _userManager.GetRolesAsync(user);

                    CommonHelpers helpers = new CommonHelpers(_configuration);
                    return await helpers.GenerateJwtToken(request.Email, user, roles);
                }

                throw new ApplicationException("UNKNOWN_ERROR");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
