namespace Models.Core
{
    public class ColumnItem
    {
        public ColumnItem(string columnValue)
        {
            Value = columnValue ?? throw new System.ArgumentNullException(nameof(columnValue));
        }
        public readonly string Value;
    }
}