using System.ComponentModel.DataAnnotations;

namespace Wiki.App.Entities
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;


        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }


        public DateTime Birthday { get; set; }
        public int Age => DateTime.Now.Year - Birthday.Year;
        public string Status { get; set; } = string.Empty;
        public string Quote { get; set; } = string.Empty;
        public string PortraitUrl { get; set; } = string.Empty;

        //public List<Character> Family { get; set; } = new List<Character>();
        //public List<Character> Relationship { get; set; } = new List<Character>();
    }
}
