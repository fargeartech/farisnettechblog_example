using BenchmarkDotNet.Attributes;

namespace BenchmarkDotNetExample
{
    [MemoryDiagnoser]
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
    }
}
