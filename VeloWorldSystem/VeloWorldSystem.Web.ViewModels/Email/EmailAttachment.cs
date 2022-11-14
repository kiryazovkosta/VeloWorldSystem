namespace VeloWorldSystem.DtoModels.Email
{
    public class EmailAttachmentModel
    {
        public byte[] Content { get; set; } = null!;

        public string FileName { get; set; } = null!;

        public string MimeType { get; set; } = null!;
    }
}