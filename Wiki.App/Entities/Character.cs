namespace Wiki.App.Entities
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public int Age { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Quote { get; set; } = string.Empty;

        public BasicInfo BasicInfo { get; set; } = new BasicInfo();
        public string PortraitUrl { get; set; } = string.Empty; 
        public string Text { get; set; } = string.Empty;
        public List<string> Aliases { get; set; } = new List<string>();
        public List<string> Species { get; set; } = new List<string>();
        //public List<Character> Family { get; set; } = new List<Character>();
        //public List<Character> Relationship { get; set; } = new List<Character>();
    }
}
