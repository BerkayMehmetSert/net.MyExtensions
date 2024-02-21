# Net My Extension

## Description

This is a project of functions that I have created to help me with my projects. I have decided to make it public in case
anyone else finds it useful.

## Installation

1. Clone the repository

```bash
git clone https://github.com/BerkayMehmetSert/net.MyExtensions.git
```

2. Install the dependencies

```bash
dotnet restore
```

3. Test the project

```bash
dotnet test
```

## Appsettings.json

```json
{
  // Benchmark settings for controlling test execution
  "BenchmarkSettings": {
    // Set to true to run all benchmark tests, false to run only specific ones
    "RunAllTests": false,

    // If running specific tests, specify the file extension here (e.g., "json", "list", etc.)
    "TestFile": "json"
  }
}
```


