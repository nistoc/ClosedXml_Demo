using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Models.Core
{
    public class FileRowList
    {

        private List<RowItem> dataInFile = new List<RowItem>();
        public ReadOnlyCollection<RowItem> DataInFile
        {
            get
            {
                return dataInFile.AsReadOnly();
            }
        }

        public void AddRow(RowItem rowItem)
        {
            dataInFile.Add(rowItem);
        }
    }
}