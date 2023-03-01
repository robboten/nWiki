using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Shared.Entities
{
    public class WikiPageProp
    {
        public int Id { get; set; }
        public Guid PageGuid { get; set; }
        public string PropKey { get; set; } = string.Empty;
        public string PropValue { get; set; } = string.Empty;
    }
}
