namespace kolokwium_poprawa.Models
{
    public class Member
    {
        public int MemberID { get; set; }
        public int OrganizationID { get; set; }
        public string MemberName { get; set; } = null!;
        public string MemberSurname { get; set; } = null!;
        public string? MemberNickName { get; set; }

        public virtual Organization Organization { get; set; } = null!;
        public virtual ICollection<Membership> Memberships { get; set; } = null!;
    }
}
