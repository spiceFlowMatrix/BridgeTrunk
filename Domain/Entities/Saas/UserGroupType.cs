using Bridge.Domain.Enums.Saas;

namespace Bridge.Domain.Entities.Saas
{
    // TODO: This must be a static list. The list should have a set of entries that corresponds to the set of options listed for enum: EUserGroupType
    public class UserGroupType
    {
        public int Id { get; set; }
        public EUserGroupType TypeName { get; set; }
        public int MembersMin { get; set; }
        public int MembersMax { get; set; }

        // Users get or lose this permission (in auth infrastructure) when they join (or are added to) or leave (or are removed from) a group.
        public string NormalizedAuthPermissionName { get; set; }
    }
}
