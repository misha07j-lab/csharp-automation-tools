using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvJsonConverter.Domain;
using System.Text.Json;

namespace CsvJsonConverter.Infrastructure
{
    // <summary>
    // Writes DataTableModel into a JSON file.
    // Produces a JSON array of objects.
    // </summary>
    public class JsonWriter
    {
        public void Write(string filePath, DataTableModel table)
        {
            if (table.Headers.Count == 0)
            {
                throw new InvalidOperationException("Table has no headers.");
            }

            var list = new List<Dictionary<string, string>>();

            foreach (var row in table.Rows)
            {
                var obj = new Dictionary<string, string>();

                for (int i = 0; i < table.Headers.Count; i++)
                {
                    var header = table.Headers[i];
                    var value = i < row.Count ? row[i] : string.Empty;

                    obj[header] = value;
                }

                list.Add(obj);
            }

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var json = JsonSerializer.Serialize(list, options);

            File.WriteAllText(filePath, json);
        }
    }
}

