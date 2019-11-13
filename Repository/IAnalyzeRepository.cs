using DetectFacesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetectFacesAPI.Repository
{
    public interface IAnalyzeRepository
    {

       Task Save(Image image);

    }
}
