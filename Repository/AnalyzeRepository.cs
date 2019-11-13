using DetectFacesAPI.Data;
using DetectFacesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetectFacesAPI.Repository
{
    public class AnalyzeRepository : IAnalyzeRepository
    {
        private AnalyzeImageDBContext detect;

        public AnalyzeRepository(AnalyzeImageDBContext detect)
        {
            this.detect = detect;
        }

        public async Task Save(Image image)
        {
           await detect.Image.AddAsync(image);
           await detect.SaveChangesAsync();
            
        }
    }
}
