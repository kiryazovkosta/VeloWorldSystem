namespace VeloWorldSystem.GpxProcessing.Models
{
    using System.Xml.Serialization;

    [XmlType("trkpt")]
    public class GpxTrkTrkpt
    {
        [XmlAttribute("lat")]
        public decimal Latitude { get; set; }

        [XmlAttribute("lon")]
        public decimal Longitude { get; set; }

        [XmlElement("ele")]
        public decimal? Elevation { get; set; }

        [XmlElement("time")]
        public DateTime Time { get; set; }

        [XmlElement("extensions")]
        public GpxTrkTrkptExtensions Extensions { get; set; } = null!;
    }
}