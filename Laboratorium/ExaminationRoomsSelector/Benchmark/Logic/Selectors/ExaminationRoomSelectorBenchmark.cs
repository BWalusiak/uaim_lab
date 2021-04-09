namespace ExaminationRoomsSelector.Benchmark.Logic.Selectors
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Engines;
    using BenchmarkDotNet.Jobs;
    using Test.Providers;
    using Web.Logic.Selection;

    [SimpleJob(RuntimeMoniker.NetCoreApp50)]
    [RPlotExporter]
    [HtmlExporter]
    public class ExaminationRoomSelectorBenchmark
    {
        private ExaminationRoomSelector _selector;
        private Consumer _consumer;

        [Params(100, 500, 1000, 2500)] public int N;

        [GlobalSetup]
        public void Setup()
        {
            var doctors = DoctorDtoProvider.Faker.Generate(N);
            var rooms = ExaminationRoomDtoProvider.Faker.Generate(N);

            _selector = new ExaminationRoomSelector(rooms, doctors);
            _consumer = new Consumer();
        }

        [Benchmark]
        public void Run() => _selector.MatchDoctorsRooms().Consume(_consumer);
    }
}