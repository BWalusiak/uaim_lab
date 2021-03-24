namespace ExaminationRooms.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Aggregate;

    public class ExaminationRoomsRepository : IExaminationRoomsRepository
    {
        private static readonly ExaminationRoom[] ExaminationRooms = {
            new(1, "01", new List<Certification> {new(1, DateTime.UtcNow, 1)}),
            new(2, "02"),
            new(3, "03",
                new List<Certification> {new(2, DateTime.UtcNow, 5), new(3, DateTime.UtcNow, 7)}),
            new(4, "101",
                new List<Certification>
                    {new(4, DateTime.UtcNow, 6), new(5, DateTime.UtcNow, 3), new(6, DateTime.UtcNow, 5)}),
            new(5, "102", new List<Certification> {new(7, DateTime.UtcNow, 3), new(8, DateTime.UtcNow, 2)}),
            new(6, "103",
                new List<Certification>
                    {new(9, DateTime.UtcNow, 2), new(10, DateTime.UtcNow, 1), new(11, DateTime.UtcNow, 5)}),
            new(7, "104", new List<Certification> {new(12, DateTime.UtcNow, 5)}),
            new(8, "105a", new List<Certification> {new(13, DateTime.UtcNow, 12)}),
            new(9, "105b",
                new List<Certification>
                    {new(14, DateTime.UtcNow, 7), new(15, DateTime.UtcNow, 6), new(16, DateTime.UtcNow, 5)}),
            new(10, "201",
                new List<Certification>
                    {new(17, DateTime.UtcNow, 9), new(18, DateTime.UtcNow, 7), new(19, DateTime.UtcNow, 8)}),
            new(11, "202", new List<Certification> {new(20, DateTime.UtcNow, 10), new(21, DateTime.UtcNow, 1)}),
            new(12, "203", new List<Certification> {new(22, DateTime.UtcNow, 1)}),
            new(13, "204a", new List<Certification> {new(23, DateTime.UtcNow, 4)}),
            new(14, "204b", new List<Certification> {new(24, DateTime.UtcNow, 7), new(25, DateTime.UtcNow, 6)}),
            new(15, "301", new List<Certification> {new(26, DateTime.UtcNow, 6), new(27, DateTime.UtcNow, 5)}),
            new(16, "302", new List<Certification> {new(28, DateTime.UtcNow, 5), new(29, DateTime.UtcNow, 4)}),
            new(17, "303", new List<Certification> {new(30, DateTime.UtcNow, 5), new(31, DateTime.UtcNow, 3)}),
            new(18, "401",
                new List<Certification>
                    {new(32, DateTime.UtcNow, 8), new(33, DateTime.UtcNow, 1), new(34, DateTime.UtcNow, 2)}),
            new(19, "402"),
            new(20, "403", new List<Certification> {new(35, DateTime.UtcNow, 10)})
        };

        public IEnumerable<ExaminationRoom> GetAll()
        {
            return ExaminationRooms;
        }

        public IEnumerable<ExaminationRoom> GetByCertificationType(int certificationType)
        {
            return ExaminationRooms?.Where(ld => ld.Certifications.Any(s => s.Type == certificationType));
        }
    }
}