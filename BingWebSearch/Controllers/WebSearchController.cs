using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BingWebSearch.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations.Schema;


namespace BingWebSearch.Controllers
{
    [Route("api/WebSearch")]
    [ApiController]

   
    public class WebSearchController : ControllerBase
    {
        const string accessKey = "2097b581f59b420082726c89a81f36e6";
        const string uriBase = "https://api.cognitive.microsoft.com/bing/v7.0/search";
        const string searchTerm = "Microsoft Cognitive Services";
        // GET: api/WebSearch
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/WebSearch/5
        [HttpGet("{searchQuery}")]
        public IActionResult Get(string searchQuery)
        {


            // return "value";
            // Construct the search request URI.
            var uriQuery = uriBase + "?q=" + Uri.EscapeDataString(searchQuery);

            // Perform request and get a response.
            WebRequest request = HttpWebRequest.Create(uriQuery);
            request.Headers["Ocp-Apim-Subscription-Key"] = accessKey;
            HttpWebResponse response = (HttpWebResponse)request.GetResponseAsync().Result;
            string json = new StreamReader(response.GetResponseStream()).ReadToEnd();

            var result = JsonConvert.DeserializeObject<RootObject>(json);
            

            
            // Create a result object.
            var searchResult = new SearchResult()
            {
                jsonResult = json,
                relevantHeaders = new Dictionary<String, String>()
            };

            // Extract Bing HTTP headers.
            foreach (String header in response.Headers)
            {
                if (header.StartsWith("BingAPIs-") || header.StartsWith("X-MSEdge-"))
                    searchResult.relevantHeaders[header] = response.Headers[header];
            }
            return Ok(json);
        }
        struct SearchResult
        {
            public String jsonResult;
            public Dictionary<String, String> relevantHeaders;
        }

        // POST: api/WebSearch
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/WebSearch/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
