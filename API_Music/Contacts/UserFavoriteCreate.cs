namespace API_Music.Contacts
{
    public class UserFavoriteCreate
    {
        
        public int BandId { get; set; }
        public int ReleaseId { get; set; }
        public int SongId { get; set; }
        public string? Review { get; set; }
    }
}
