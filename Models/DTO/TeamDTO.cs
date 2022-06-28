namespace kolokwium_poprawa.Models.DTO
{
    public class TeamDTO
    {
        public string TeamName { get; set; }
        public string OrganizationName { get; set; }
        public ICollection<Member> Members { get; set; }
        public string? TeamDescription { get; set; }
    }
}
