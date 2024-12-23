namespace API_Music.Contacts
{
    public class SongListCreate
    {
        
        public string Name { get; set; } = null!;
        public int Band { get; set; }
        public int Genre { get; set; }
        public int SongReleaseId { get; set; }
    }
}
