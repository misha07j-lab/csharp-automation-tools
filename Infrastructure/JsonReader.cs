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
    // Reads JSON files and converts them into DataTableModel.
    // Supports JSON array of objects.
    // </summary>
    public class JsonReader
    {
        public DataTableModel Read(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"JSON file not found: {filePath}");
            }

            var json = File.ReadAllText(filePath);

            var document = JsonDocument.Parse(json);

            if (document.RootElement.ValueKind != JsonValueKind.Array)
            {
                throw new InvalidOperationException("JSON root element must be an array.");
            }

            var table = new DataTableModel();

            bool headersInitialized = false;

            foreach (var element in document.RootElement.EnumerateArray())
            {
                if (element.ValueKind != JsonValueKind.Object)
                {
                    throw new InvalidOperationException("JSON array elements must be objects.");
                }

                var row = new List<string>();

                foreach (var property in element.EnumerateObject())
                {
                    if (!headersInitialized)
                    {
                        table.Headers.Add(property.Name);
                    }

                    row.Add(property.Value.ToString());
                }

                headersInitialized = true;
                table.Rows.Add(row);
            }

            return table;
        }
    }
}
