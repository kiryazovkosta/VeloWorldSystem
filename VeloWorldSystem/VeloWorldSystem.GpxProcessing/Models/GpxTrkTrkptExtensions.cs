using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VeloWorldSystem.GpxProcessing.Models
{
    [XmlType("extensions")]
    public  class GpxTrkTrkptExtensions
    {
        [XmlElement("power")]
        public ushort Power { get; set; }

        [XmlElement("TrackPointExtension")]
        public TrackPointExtension TrackPointExtension { get; set; } = null!;
    }
}
