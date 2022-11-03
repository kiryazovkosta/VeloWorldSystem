namespace VeloWorldSystem.GpxProcessing.Models
{
    using System.Xml.Serialization;

    [XmlType("trk")]
    public class GpxTrk
    {
        [XmlElement("name")]
        public string Name { get; set; } = null!;

        [XmlElement("type")]
        public byte Type { get; set; }

        [XmlElement("desc")]
        public string Description { get; set; } = null!;

        [XmlArray("trkseg")]

        public GpxTrkTrkpt[] Trkseg { get; set; } = null!;
    }
}
