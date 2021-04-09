namespace ExaminationRoomsSelector.Test.Providers
{
    using System;
    using Bogus;
    using Web.Application.Dtos;

    public static class DoctorDtoProvider
    {
        public static readonly Faker<DoctorDto> Faker;
        private static int _ids;

        static DoctorDtoProvider()
        {
            _ids = 0;
            Randomizer.Seed = new Random();
            Faker = new Faker<DoctorDto>()
                .StrictMode(true)
                .RuleFor(o => o.Id, f => _ids++)
                .RuleFor(o => o.Specializations, f => f.Random.Digits(4))
                .RuleFor(o => o.Name, f => f.Name.FullName());
        }
    }
}