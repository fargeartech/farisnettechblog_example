using BenchmarkDotNet.Attributes;

namespace EmptyCollectionBenchmark
{
    [MemoryDiagnoser]
    public class BenchmarkEmptyCollection
    {
        private IEnumerable<Student> _students;
        [Benchmark(Baseline = true)]
        public void ReturnNew()
        {
            _students = new List<Student>();
        }

        [Benchmark]
        public void ReturnEmtpy()
        {
            _students = Enumerable.Empty<Student>();
        }

    }
}