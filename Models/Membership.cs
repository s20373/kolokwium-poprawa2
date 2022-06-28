namespace kolokwium_poprawa.Models
{
    public class Membership
    {
        public int MemberID { get; set; }
        public int TeamID { get; set; }
        public DateTime MembershipDate { get; set; }

        public virtual Team Team { get; set; } = null!;
        public virtual Member Member { get; set; } = null!;
    }
}
