using BenchmarkDotNet.Running;
using NewsAggregator.News.Benchmarks.Services.Parsers;

BenchmarkRunner.Run<NewsParserBenchmarks>();
BenchmarkRunner.Run<NewsUrlsParserBenchmarks>();