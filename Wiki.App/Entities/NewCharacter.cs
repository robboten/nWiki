using System.ComponentModel.DataAnnotations;

namespace Wiki.App.Entities
{
    public class NewCharacter
    {
        public string Name { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Quote { get; set; } = string.Empty;
        public string PortraitUrl { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;

        //public List<Character> Family { get; set; } = new List<Character>();
        //public List<Character> Relationship { get; set; } = new List<Character>();
    }
}
