using TaskTracker.Enums;

namespace TaskTracker.App
{
    public class FileMetadata
    {
        public string Filename { get; init; }
        public string Extension { get; init; }

        public FileMetadata(string filename, FileExtension extension)
        {
            Filename = filename;
            Extension = extension.ToString().ToLower();
        }

        public string FullPath() => Filename + Extension;

    }
}