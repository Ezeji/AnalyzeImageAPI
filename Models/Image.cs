using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DetectFacesAPI.Models
{
    public class Image
    {
        public int ImageID { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DetectedDate { get; set; }

        public Image()
        {
            DetectedDate = DateTime.UtcNow;
        }

    }
}
