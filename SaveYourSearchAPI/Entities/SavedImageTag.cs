using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaveYourSearchAPI.Entities
{
    public class SavedImageTag
    {
        public int SavedImageTagId { get; set; }
        public int SavedImageId { get; set; }
        public string Tag { get; set; }
    }
}
