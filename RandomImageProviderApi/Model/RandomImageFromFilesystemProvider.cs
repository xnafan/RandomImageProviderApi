using System;

namespace RandomImageProviderApi.Model
{
    public class RandomImageFromFilesystemProvider : IImageProvider
    {
        private static Random _random = new();
        public string AbsoluteImageFolderPath { get; private set; }

        public RandomImageFromFilesystemProvider(string absoluteImageFolderPath)
        {
            AbsoluteImageFolderPath = absoluteImageFolderPath;
        }

        public FileObject GetImage()
        {
            return GetRandomFile();
        }

        private FileObject GetRandomFile()
        {   
            string[] files = Directory.GetFiles(AbsoluteImageFolderPath);
            string file = files[_random.Next(files.Length)];
            return new FileObject(file, FileExtensionToMimeType(Path.GetExtension(file)));

        }

        private string FileExtensionToMimeType(string fileExtension)
        {
            fileExtension = fileExtension.ToLower();
            if (fileExtension.Contains("jp")) { return "image/jpg"; }
            if (fileExtension.Contains("png")) { return "image/png"; }
            return "image/" + fileExtension;
        }
    }
}