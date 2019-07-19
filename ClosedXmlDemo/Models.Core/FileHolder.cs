namespace Models.Core
{
    public class FileHolder<T> : IFileHolder<T>
    {

        public FileHolder(string fileName, T file)
        {
            FileName = fileName;
            CurrentFile = file;
        }

        public T CurrentFile { get; }
        public string FileName { get; }

        public FileRowList FileRowList { get; } = new FileRowList();

    }
}
