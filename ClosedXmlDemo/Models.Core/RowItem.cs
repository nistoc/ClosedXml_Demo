using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.Core
{

    public class RowItem
    {
        private readonly ColumnItem[] columns;

        public RowItem(int columnCount)
        {
            if (columnCount < 1)
                throw new ArgumentOutOfRangeException($"The argument {columnCount} is less then 1");

            columns = new ColumnItem[columnCount];
        }

        public void SetValue(int index, string value)
        {
            if (index < 0 && index > (columns.Length - 1))
                throw new ArgumentOutOfRangeException($"The argument {index} is less then 1");
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (columns[index] != null)
                return;

            columns[index] = new ColumnItem(value);
        }

        public List<ColumnItem> Columns => ((ColumnItem[])columns.Clone()).ToList();

    }
}