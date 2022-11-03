using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeloWorldSystem.GpxProcessing.Models;

namespace VeloWorldSystem.GpxProcessing
{
    public interface IGpxService
    {
        Task<Gpx> Get(string xml);
    }
}
