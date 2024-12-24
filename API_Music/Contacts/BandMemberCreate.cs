namespace API_Music.Contacts
{
    public class BandMemberCreate
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Pseudonym { get; set; }
        public int? BandId { get; set; }
        public bool? IsInBand { get; set; }

    }
}
