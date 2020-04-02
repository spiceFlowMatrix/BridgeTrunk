namespace Bridge.Domain.Entities
{
    public class GroupMember //: EntityBase, IGroupMember
    {
        public long Id { get; set; }
        public long GroupId { get; set; }
        public long UserId { get; set; }
    }
}
