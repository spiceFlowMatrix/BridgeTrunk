using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Authentication.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<object>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
