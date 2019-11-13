using DetectFacesAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetectFacesAPI.Data
{
    public class AnalyzeImageDBContext : DbContext
    {

        public AnalyzeImageDBContext(DbContextOptions<AnalyzeImageDBContext> options)
           : base(options)
        {
        }

        public DbSet<Image> Image { get; set; }

    }
}
