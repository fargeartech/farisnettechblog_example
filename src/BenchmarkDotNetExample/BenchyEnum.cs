using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Reports;

namespace BenchmarkDotNetExample
{
    [MemoryDiagnoser]
    [Config(typeof(StyleConfig))]
    public class BenchyEnum
    {
        [Benchmark(Baseline = true)]
        public string NaiveEnumString()
        {
            return Enums.UserType.Admin.ToString();
        }

        [Benchmark]
        public string FastEnum()
        {
            return Enums.GetFastEnum(Enums.UserType.Admin);
        }

        private class StyleConfig : ManualConfig
        {
            public StyleConfig()
                => SummaryStyle = SummaryStyle.Default.WithRatioStyle(RatioStyle.Percentage);
        }
    }
}
