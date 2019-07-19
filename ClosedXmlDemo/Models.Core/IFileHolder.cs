namespace Models.Core
{
    public interface IFileHolder<T>
    {
        T CurrentFile { get; }
        string FileName { get; }
    }
}