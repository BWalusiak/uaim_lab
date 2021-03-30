namespace ExaminationRooms.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using Domain.Aggregate;

    public class ExaminationRoomsRepository : IExaminationRoomsRepository
    {
        public IEnumerable<ExaminationRoom> GetAll()
        {
            var document = XDocument.Load("Resources/database.xml");

            var xmlSerializer = new XmlSerializer(typeof(Database));

            var database = xmlSerializer.Deserialize(document.CreateReader()) as Database;
            return database?.ExaminationRooms;
        }

        public IEnumerable<ExaminationRoom> GetByCertificationType(int certificationType)
        {
            var document = XDocument.Load("Resources/database.xml");

            var xmlSerializer = new XmlSerializer(typeof(Database));

            var database = xmlSerializer.Deserialize(document.CreateReader()) as Database;
            return database?.ExaminationRooms.Where(it => it.Certifications.Any(s => s.Type == certificationType));
        }
    }
}