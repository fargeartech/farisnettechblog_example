using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace SealKeywordBencMark
{
    [SimpleJob(runtimeMoniker:RuntimeMoniker.Net80)]
    [MemoryDiagnoser]
    public class BenchMarkSealClass
    {
        private NonSealTypClass _nonSealTypClass;
        private SealTypeClass _sealTypeClass;

        [GlobalSetup]
        public void Setup()
        {
            _nonSealTypClass = new NonSealTypClass();
            _sealTypeClass = new SealTypeClass();
        }

        [Benchmark]
        public void NonSeal()
        {
            _nonSealTypClass.GetStringValue();
        }

        [Benchmark]
        public void WithSeal()
        {
            _sealTypeClass.GetStringValue();
        }

    }
}
