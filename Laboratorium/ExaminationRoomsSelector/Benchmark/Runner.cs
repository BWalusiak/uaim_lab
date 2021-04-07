namespace ExaminationRoomsSelector.Benchmark
{
    using BenchmarkDotNet.Running;
    using Logic.Selectors;

    public class Runner
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<ExaminationRoomSelectorBenchmark>();
        }
    }
}