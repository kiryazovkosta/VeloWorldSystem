using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VeloWorldSystem.GpxProcessing.Models
{
    [XmlType("gpx")]
    public partial class Gpx
    {

        [XmlElement("metadata")]
        public GpxMetadata Metadata { get; set; } = null!;

        [XmlElement("trk")]
        public GpxTrk Trk { get; set; } = null!;
    }
}
