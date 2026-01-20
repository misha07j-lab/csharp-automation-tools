using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvJsonConverter.Domain;

namespace CsvJsonConverter.Infrastructure
{
    /// <summary>
    /// Reads CSV files and converts them into DataTableModel.
    /// </summary>
    public class CsvReader
    {
        private readonly char _delimiter;

        public CsvReader(char delimiter = ',')
        {
            _delimiter = delimiter;
        }

        public DataTableModel Read(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"CSV file not found: {filePath}");
            }

            var lines = File.ReadAllLines(filePath);

            if (lines.Length == 0)
            {
                throw new InvalidOperationException("CSV file is empty.");
            }

            var table = new DataTableModel();

            // Headers
            var headers = lines[0].Split(_delimiter);
            foreach (var header in headers)
            {
                table.Headers.Add(header.Trim());
            }

            // Rows
            for (int i = 1; i < lines.Length; i++)
            {
                var values = lines[i].Split(_delimiter);
                table.Rows.Add(values.Select(v => v.Trim()).ToList());
            }

            return table;
        }
    }
}

