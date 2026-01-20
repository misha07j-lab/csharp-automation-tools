using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvJsonConverter.Domain;

namespace CsvJsonConverter.Infrastructure
{
    /// <summary>
    /// Writes DataTableModel into a CSV file.
    /// </summary>
    public class CsvWriter
    {
        private readonly char _delimiter;

        public CsvWriter(char delimiter = ',')
        {
            _delimiter = delimiter;
        }

        public void Write(string filePath, DataTableModel table)
        {
            if (table.Headers.Count == 0)
            {
                throw new InvalidOperationException("Table has no headers.");
            }

            var sb = new StringBuilder();

            // Write headers
            sb.AppendLine(string.Join(_delimiter, table.Headers));

            // Write rows
            foreach (var row in table.Rows)
            {
                sb.AppendLine(string.Join(_delimiter, row));
            }

            File.WriteAllText(filePath, sb.ToString());
        }
    }
}

