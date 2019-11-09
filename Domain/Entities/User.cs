using System;

namespace Bridge.Domain.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneVerified { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }
        public string Picture { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public bool Blocked { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
    }
}