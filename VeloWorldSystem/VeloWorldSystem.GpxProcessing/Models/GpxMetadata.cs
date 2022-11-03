namespace VeloWorldSystem.GpxProcessing.Models
{
    using System.Xml.Serialization;

    [XmlType("metadata")]
    public class GpxMetadata
    {
        [XmlElement("name")]
        public string Name { get; set; } = null!;

        [XmlElement("time")]
        public DateTime Time { get; set; }
    }
}