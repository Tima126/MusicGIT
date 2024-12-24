namespace API_Music.Contacts
{
    public class BandListCreate
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Genre { get; set; }
        public int Lang { get; set; }
        public int Country { get; set; }
    }
}
