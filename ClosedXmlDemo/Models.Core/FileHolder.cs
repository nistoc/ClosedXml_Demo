namespace Models.Core
{
    public class FileHolder<T> : IFileHolder<T>
    {

        public FileHolder(string fileName, T file)
        {
            FileName = fileName;
            CurrentFile = file;
        }

        public string FileName { get; }
        public T CurrentFile { get; }



    }
}
