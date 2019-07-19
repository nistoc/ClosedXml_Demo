using Models.Core;

namespace DemoApp.Services
{
    public interface IExcelProvider<T>
    {
        IFileHolder<T> GetFile(string fileName);
        void SaveFile(IFileHolder<T> fileHolder, string newFileName);
    }
}
