using Bridge.Domain.Enums;

namespace Bridge.Domain.Entities
{
    public class UserGroupType
    {
        public int Id { get; set; }
        public UserGroupTypes TypeName { get; set; }
        public int MembersMin { get; set; }
        public int MembersMax { get; set; }

        // Users get or lose this permission when they join (or are added to) or leave (or are removed from) a group.
        public string NormalizedAuthPermissionName { get; set; }
    }
}
