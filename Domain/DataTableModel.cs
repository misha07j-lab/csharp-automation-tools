using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvJsonConverter.Domain
{
    /// <summary>
    /// Universal table-like data structure.
    /// Used as an internal representation for CSV and JSON formats.
    /// </summary>
    public class DataTableModel
    {
        /// <summary>
        /// Column names (headers).
        /// </summary>
        public List<string> Headers { get; } = new();

        /// <summary>
        /// Data rows.
        /// Each row is a list of values aligned with Headers.
        /// </summary>
        public List<List<string>> Rows { get; } = new();

        /// <summary>
        /// Removes empty rows and trims whitespace in all cells.
        /// </summary>
        public void Clean()
        {
            for (int i = Rows.Count - 1; i >= 0; i--)
            {
                var row = Rows[i];

                for (int j = 0; j < row.Count; j++)
                {
                    row[j] = row[j].Trim();
                }

                if (row.All(string.IsNullOrWhiteSpace))
                {
                    Rows.RemoveAt(i);
                }
            }
        }
    }
}
