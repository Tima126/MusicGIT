namespace API_Music.Contacts
{
    public class ReleaseListCreate
    {
        
        public string Name { get; set; } = null!;
        public int Band { get; set; }
        public int Genre { get; set; }
        public int Type { get; set; }
        public int Year { get; set; }
        public int SongAmmount { get; set; }
    }
}
