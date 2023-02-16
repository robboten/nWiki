﻿namespace Wiki.App.Entities
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
        //public List<string> Aliases { get; set; }
        //public List<string> Species { get; set; }
        //public List<Character> Family { get; set; }
        //public List<Character> Relationship { get; set; }
    }
}
