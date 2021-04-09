namespace ExaminationRoomsSelector.Test.Providers
{
    using System;
    using Bogus;
    using Web.Application.Dtos;

    public static class ExaminationRoomDtoProvider
    {
        public static readonly Faker<ExaminationRoomDto> Faker;
        private static int _index;

        static ExaminationRoomDtoProvider()
        {
            Randomizer.Seed = new Random();
            Faker = new Faker<ExaminationRoomDto>()
                .StrictMode(true)
                .RuleFor(o => o.Certifications, f => f.Random.Digits(6))
                .RuleFor(o => o.Number, f => f.Random.Replace("*##") + _index++);
        }
    }
}