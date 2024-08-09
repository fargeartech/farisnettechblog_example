using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace StringEqualBenchDemo
{
    [MemoryDiagnoser]
    [SimpleJob(runtimeMoniker: RuntimeMoniker.Net80)]
    public class Benchy
    {
        private readonly string compare1 = "my_compare";
        private readonly string compare2 = "my_compare";

        [Benchmark(Baseline = true)]
        public bool DirectEqual()
        {
            return compare1 == compare2;
        }

        [Benchmark]
        public bool ToLower()
        {
            return compare1.ToLower() == compare2.ToLower();
        }

        [Benchmark]
        public bool CompareEqual()
        {
            return string.Equals(compare1, compare2);
        }

        [Benchmark]
        public bool CompareEqualWithIgnoreCase()
        {
            return string.Equals(compare1, compare2, StringComparison.OrdinalIgnoreCase);
        }

    }
}
