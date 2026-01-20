# CsvJsonConverter — CSV ⇄ JSON Converter (C# Console Tool)

Консольная утилита на C# для конвертации данных между форматами CSV и JSON.

Проект реализован с использованием многослойной архитектуры:
Domain / Application / Infrastructure.

## Возможности
- Конвертация CSV → JSON
- Конвертация JSON → CSV
- Работа с файлами через консоль (CLI)
- Чистая архитектура, легко расширяется

## Пример использования

```bash
CsvJsonConverter.exe csv-to-json input.csv output.json
CsvJsonConverter.exe json-to-csv input.json output.csv
```

## Архитектура проекта
- **Domain** — бизнес-модели и интерфейсы
- **Application** — сценарии использования и логика приложения
- **Infrastructure** — работа с файлами и форматами данных
- **Program.cs** — точка входа приложения


## Технологии
- C#
- .NET
- System.Text.Json

---

## Назначение проекта
Проект создан как основа для automation-инструментов и может быть
адаптирован под реальные бизнес-задачи (обработка данных, интеграции, отчёты).
