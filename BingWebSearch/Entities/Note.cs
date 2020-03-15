using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BingWebSearch.Entities
{
    public class Note
    {
        public string noteId { get; set; }
        public string noteHeadLine{ get; set; }
        public string notesInfo { get; set; }
        public string createdDate { get; set; }
        public string moreInfo { get; set; }
        public string bufferColumn { get; set; }
    }
}
