namespace kolokwium_poprawa.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        public int OrganizationID { get; set; }
        public string TeamName { get; set; } = null!;
        public string? TeamDescription { get; set; }

        public virtual Organization Organization { get; set; } = null!;
        public virtual ICollection<File> Files { get; set; } = null!;
        public virtual ICollection<Membership> Memberships { get; set; } = null!;
    }
}
