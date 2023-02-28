﻿using Microsoft.AspNetCore.Components;

namespace Wiki.App.Entities
{
    public class WikiPage
    {
       // public int Id { get; set; }
        public string Name { get; set; }  = string.Empty;
        public string Content { get; set; } = string.Empty;

        //public MarkupString Content { get; set; }
        public bool Published { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public Guid Guid { get; set; }
    }

    public record WikiPageR(string Name, string Content, bool Published, DateTime Created, DateTime Updated, Guid Guid)
    {
    }

    //public record WikiPageR(string Name, string Content, bool Published, DateTime Created, DateTime Updated, Guid Guid);
}
