namespace kolokwium_poprawa.Models
{
    public class File
    {
        public int FileID { get; set; }
        public int TeamID { get; set; }
        public string FileName { get; set; } = null!;
        public string FileExtension { get; set; } = null!;
        public int FileSize { get; set; }

        public virtual Team Team { get; set; } = null!;
    }
}
