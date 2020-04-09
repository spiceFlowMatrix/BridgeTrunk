using Bridge.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;

namespace Bridge.WebUI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            IsAuthenticated = UserId != null;
            RoleList = httpContextAccessor.HttpContext?.User?.Claims.Where(c => c.Type == "https://noon-online/roles").Select(c=> c.Value).ToList();
        }
        public string UserId { get; }

        public bool IsAuthenticated { get; }
        public List<string> RoleList { get; }
    }
}
