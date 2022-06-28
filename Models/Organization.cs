namespace kolokwium_poprawa.Models
{
    public class Organization
    {
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; } = null!;
        public string OrganizationDomain { get; set; } = null!;

        public virtual ICollection<Team> Teams { get; set; } = null!;
        public virtual ICollection<Member> Members { get; set; } = null!;
    }
}
