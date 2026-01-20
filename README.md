# CSV ⇄ JSON Converter (C# Console Tool)

## Problem
Many teams need a fast way to convert and clean data files
between CSV and JSON formats for reports, automation or integrations.

## Solution
A lightweight C# console tool that converts CSV ↔ JSON
and performs basic data cleaning.

## Features
- CSV to JSON conversion
- JSON to CSV conversion
- Removes empty rows
- Trims whitespace
- Simple command-line interface

## Usage

### CSV to JSON
dotnet run -- csv2json input.csv output.json

### JSON to CSV
dotnet run -- json2csv input.json output.csv

## Input formats
CSV:
Name,Age
Alex,30
Maria,25

JSON:
[
  { "Name": "Alex", "Age": "30" },
  { "Name": "Maria", "Age": "25" }
]

## Use cases
- Data preparation
- Automation pipelines
- Reports
- API integrations

## Tech stack
- C#
- .NET
- Console Application

## Extensibility
The project is designed for easy extension:
- custom delimiters
- additional cleaning rules
- Excel / API support
