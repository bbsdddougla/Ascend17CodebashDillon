using EPiServer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiserverSite1.Business.SearchAnalyzation
{
    interface IImageAnalyzerService
    {
        string[] AnalyzeImage(ImageData document);
    }
}
