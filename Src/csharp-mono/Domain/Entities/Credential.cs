﻿

namespace Bridge.Domain.Entities
{
    public class Credential //: AuditableEntity, ICredential
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CredentialTypeId { get; set; }
        public string Identifier { get; set; }
        public string Secret { get; set; }

        public virtual User User { get; set; }
        public virtual CredentialType CredentialType { get; set; }
    }
}
