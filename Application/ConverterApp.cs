using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvJsonConverter.Domain;
using CsvJsonConverter.Infrastructure;

namespace CsvJsonConverter.Application
{
    /// <summary>
    /// Application entry logic.
    /// Parses command line arguments and runs conversion.
    /// </summary>
    public static class ConverterApp
    {
        public static void Run(string[] args)
        {
            if (args.Length < 3)
            {
                PrintUsage();
                return;
            }

            var mode = args[0].ToLower();
            var inputPath = args[1];
            var outputPath = args[2];

            try
            {
                DataTableModel table = mode switch
                {
                    "csv2json" => ReadCsv(inputPath),
                    "json2csv" => ReadJson(inputPath),
                    _ => throw new InvalidOperationException($"Unknown mode: {mode}")
                };

                // Clean data
                table.Clean();

                // Write output
                switch (mode)
                {
                    case "csv2json":
                        WriteJson(outputPath, table);
                        break;

                    case "json2csv":
                        WriteCsv(outputPath, table);
                        break;
                }

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:");
                Console.WriteLine(ex.Message);
            }
        }

        private static DataTableModel ReadCsv(string path)
        {
            var reader = new CsvReader();
            return reader.Read(path);
        }

        private static DataTableModel ReadJson(string path)
        {
            var reader = new JsonReader();
            return reader.Read(path);
        }

        private static void WriteCsv(string path, DataTableModel table)
        {
            var writer = new CsvWriter();
            writer.Write(path, table);
        }

        private static void WriteJson(string path, DataTableModel table)
        {
            var writer = new JsonWriter();
            writer.Write(path, table);
        }

        private static void PrintUsage()
        {
            Console.WriteLine("CSV ⇄ JSON Converter");
            Console.WriteLine();
            Console.WriteLine("Usage:");
            Console.WriteLine("  csv2json <input.csv> <output.json>");
            Console.WriteLine("  json2csv <input.json> <output.csv>");
        }
    }
}


