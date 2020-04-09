using System.Collections.Generic;

namespace Bridge.Application.Interfaces
{
    public interface ICurrentUserService
    {
        string UserId { get; }
        bool IsAuthenticated { get; }
        List<string> RoleList { get; }
    }
}