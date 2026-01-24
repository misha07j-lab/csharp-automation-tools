# CsvJsonConverter – Automation-Ready CSV ⇄ JSON CLI Tool (C#)

A lightweight C# command-line tool designed for data automation workflows.

This utility enables fast and reliable conversion between CSV and JSON formats,
making it suitable for scripting, batch processing, and system integrations.

Built using clean layered architecture:
Domain / Application / Infrastructure.

--

## 🚀 Designed for Automation

This tool is built with automation scenarios in mind:

- Integration into CI/CD pipelines
- Data preprocessing before CRM/ERP imports
- Batch transformations in Windows environments
- Local scripting and scheduled jobs
- Lightweight ETL-style workflows

--

## 📦 Download

A ready-to-use Windows executable (.exe) is available
in the Releases section.

No .NET SDK installation required.

Simply download and run.

--

## 🔧 Features

- CSV → JSON conversion
- JSON → CSV conversion
- CLI-based execution
- Structured error handling
- Automatic removal of empty rows
- Proper exit codes (0 = success, 1 = error)
- Clean and extensible architecture

--

## ▶ Usage

``bash
CsvJsonConverter.exe csv2json input.csv output.json
CsvJsonConverter.exe json2csv input.json output.csv


Id,Product,Price
1,Coffee,2.5
2,Tea,1.8

[
  {
    "Id": "1",
    "Product": "Coffee",
    "Price": "2.5"
  }
]

