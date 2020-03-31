namespace Bridge.Infrastructure.Identity
{
    public class AuthManagementApiConnectionOptions
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string ClientAudience { get; set; }
        public string TenantDomain { get; set; }
        public string DatabaseConnectionId { get; set; }
    }
}