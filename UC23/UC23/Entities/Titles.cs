namespace UC23.Entities
{
    internal class Titles
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int ReleaseYear { get; set; }
        public string? AgeSertification { get; set; }
        public int Runtime { get; set; }
        public List<string>? Genres { get; set; }
        public string? ProductionCountry { get; set; }
        public int? Seasons { get; set; }
        public List<Credits>? TitleCredits { get; set; } = new List<Credits>();
    }
}
