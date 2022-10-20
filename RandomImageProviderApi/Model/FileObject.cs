namespace RandomImageProviderApi.Model
{
    public class FileObject
    {
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public string AbsolutePath { get; set; }

        public FileObject(string absolutePath, string mimeType)
        {
            AbsolutePath = absolutePath;
            MimeType = mimeType;
            FileName = Path.GetFileName(AbsolutePath);
        }
        public byte[] GetContentsAsByteArray()
        {
            return File.ReadAllBytes(AbsolutePath);
        }
    }
}