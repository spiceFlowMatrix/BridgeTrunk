using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Authentication.Commands.CreateUser
{
    public class CreateUserCommand: IRequest<object>
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
