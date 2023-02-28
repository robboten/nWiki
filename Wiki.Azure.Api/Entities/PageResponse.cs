//using Microsoft.AspNetCore.Components;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using static Wiki.Azure.Api.Entities.AzureTableItems;

//namespace Wiki.Azure.Api.Entities
//{
//    public class PageResponse<T>
//    {
//        public string Id { get; set; }
//        public string Title { get; set; }
//        public MarkupString Content { get; set; }
//        public DateTime Created { get; set; }
//        public DateTime? Updated { get; set; }
//        public IEnumerable<T> WikiPages { get; set; } = Enumerable.Empty<T>();

//        public static PageResponse<T> FromWikiPageTable(WikiPageTable wikiPage)
//        {
//            if (wikiPage == null)
//            {
//                return null!;
//            }

//            return new PageResponse<T>
//            {
//                Id = wikiPage.RowKey,
//                Title = wikiPage.Name,
//                Content = wikiPage.Content,
//                Created = wikiPage.Created,
//                Updated = wikiPage.Updated
//            };
//        }

//        public static IEnumerable<PageResponse<T>> FromWikiPageTables(IEnumerable<WikiPageTable> wikiPages)
//        {
//            if (wikiPages == null)
//            {
//                return null!;
//            }

//            return wikiPages.Select(wp => FromWikiPageTable(wp));
//        }
//    }

//}
