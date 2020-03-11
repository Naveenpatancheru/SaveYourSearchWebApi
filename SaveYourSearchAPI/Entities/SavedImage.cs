using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaveYourSearchAPI.Entities
{
    public class SavedImage
    {
        public int SavedImageId { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public List<SavedImageTag> Tags { get; set; }
        public string StorageUrl { get; set; }
    }
}
