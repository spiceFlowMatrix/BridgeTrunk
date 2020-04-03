namespace Bridge.Domain.Entities
{
    public class EmployeeTerritory
    {
        public string EmployeeId { get; set; }
        public string TerritoryId { get; set; }

        public Employee Employee { get; set; }
        public Territory Territory { get; set; }
    }
}
