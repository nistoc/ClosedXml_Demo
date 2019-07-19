using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Models.Core
{
    public interface IFileHolder<T>
    {
        T CurrentFile { get; }
        string FileName { get; }

        FileRowList FileRowList{ get; }
    }
}