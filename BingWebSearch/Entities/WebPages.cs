using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BingWebSearch.Entities
{
    public class RootObject
    {
        public string _type { get; set; }
        public QueryContext queryContext { get; set; }

        public WebPages WebPages { get; set; }
        public images images { get; set; }
        public news news { get; set; }
        public videos videos { get; set; }
      //  public rankingResponse rankingResponse { get; set; }


    }
    public class QueryContext
    {
        public string OriginalQuery { get; set; }
    }
    public class WebPages
    {
        public string webSearchUrl { get; set; }
        public int totalEstimatedMatches { get; set; }
        public List<value> value { get; set; }
      

    }
    public class images
    {
        public string id { get; set; }
        public string readLink { get; set; }
        public string webSearchUrl { get; set; }
        public bool isFamilyFriendly { get; set; }
    }
    public class news
    {
        public string id { get; set; }
        public string readLink { get; set; }
    }
    public class videos
    {
        public string id { get; set; }
        public string readLink { get; set; }
        public string webSearchUrl { get; set; }
        public string scenario { get; set; }
        public bool isFamilyFriendly;
    }
    public class value
    {
        public string userid { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public bool isFamilyFriendly;
        public string displayUrl { get; set; }
        public string snippet { get; set; }
        public DateTime dateLastCrawled { get; set; }

        public string language { get; set; }
        public bool isNavigational { get; set; }

    }

}
