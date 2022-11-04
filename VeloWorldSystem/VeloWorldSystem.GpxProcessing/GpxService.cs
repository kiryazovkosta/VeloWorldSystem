namespace VeloWorldSystem.GpxProcessing
{
    using System.Text.RegularExpressions;
    using System.Xml.Serialization;
    using VeloWorldSystem.GpxProcessing.Models;

    public class GpxService : IGpxService
    {
        public async Task<Gpx> Get(string xml)
        {
            var gpx = await DeserializeAsync(xml, "gpx");
            return gpx; 
        }

        private async Task<Gpx> DeserializeAsync(string inputXml, string rootName)
        {
            Gpx gpx = new Gpx();
            await Task.Run(() =>
            {
                XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Gpx), xmlRoot);

                using (var reader = new StringReader(RemoveAllXmlNamespace(inputXml)))
                {
                    gpx = (Gpx)xmlSerializer.Deserialize(reader)!;
                }
            });

            return gpx;
        }

        public string RemoveAllXmlNamespace(string xmlData)
        {
            string xmlnsPattern = "\\s+xmlns\\s*(:\\w)?\\s*=\\s*\\\"(?<url>[^\\\"]*)\\\"";
            MatchCollection matchCol = Regex.Matches(xmlData, xmlnsPattern);

            foreach (Match m in matchCol)
            {
                xmlData = xmlData.Replace(m.ToString(), "");
            }
            return xmlData;
        }
    }
}