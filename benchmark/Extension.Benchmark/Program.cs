var config = ManualConfig.Create(DefaultConfig.Instance);
config = config.WithOptions(ConfigOptions.DisableOptimizationsValidator);

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false);
var configurationRoot = builder.Build();
var benchmarkVariable = configurationRoot.GetSection("BenchmarkVariable").Get<BenchmarkVariable>() ??
                        new BenchmarkVariable { IsAll = true };

if (string.IsNullOrWhiteSpace(benchmarkVariable.TestFile) || benchmarkVariable.IsAll)
    RunAllTests(config);
else
    RunSpecificTest(benchmarkVariable.TestFile, config);

static void RunAllTests(IConfig config)
{
    BenchmarkRunner.Run<ComparisonBenchmarks>(config);
    BenchmarkRunner.Run<ConversionBenchmarks>(config);
    BenchmarkRunner.Run<EnumerableBenchmarks>(config);
    BenchmarkRunner.Run<JsonBenchmarks>(config);
    BenchmarkRunner.Run<ListBenchmarks>(config);
    BenchmarkRunner.Run<StringBenchmarks>(config);
}

static void RunSpecificTest(string testCategory, IConfig config)
{
    switch (testCategory.ToLower(CultureInfo.CurrentCulture))
    {
        case "comparison":
            BenchmarkRunner.Run<ComparisonBenchmarks>(config);
            break;
        case "conversion":
            BenchmarkRunner.Run<ConversionBenchmarks>(config);
            break;
        case "enumerable":
            BenchmarkRunner.Run<EnumerableBenchmarks>(config);
            break;
        case "json":
            BenchmarkRunner.Run<JsonBenchmarks>(config);
            break;
        case "list":
            BenchmarkRunner.Run<ListBenchmarks>(config);
            break;
        case "string":
            BenchmarkRunner.Run<StringBenchmarks>(config);
            break;
        default:
            Console.WriteLine($"Unknown test category: {testCategory}");
            break;
    }
}
