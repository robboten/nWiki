namespace Wiki.Api
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Birthday { get; set; } = DateTime.Now;
        public int Age => DateTime.Now.Year-Birthday.Year;
        public string Status { get; set; } = string.Empty;
        public string Quote { get; set; } = string.Empty;
        public string? PortraitUrl { get; set; } = string.Empty;
        //public List<string> Aliases { get; set; }
        //public List<string> Species { get; set; }
        //public List<Character> Family { get; set; }
        //public List<Character> Relationship { get; set; }
    }
}