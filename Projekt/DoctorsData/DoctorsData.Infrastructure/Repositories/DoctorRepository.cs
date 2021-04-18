namespace DoctorsData.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using Domain.Models;

    public class DoctorRepository : IDoctorRepository
    {
        private const string DatabasePath = "Resources/database.xml";
        private static readonly object Lock = new();
        private static DatabaseWrapper Database { get; set; }

        static DoctorRepository()
        {
            LoadDatabase();
        }

        private static void LoadDatabase()
        {
            var document = XDocument.Load(DatabasePath);
            var xmlSerializer = new XmlSerializer(typeof(DatabaseWrapper));
            Database = xmlSerializer.Deserialize(document.CreateReader()) as DatabaseWrapper;
        }

        private static void SaveDatabase()
        {
            var xmlSerializer = new XmlSerializer(typeof(DatabaseWrapper));
            using var writer = new StreamWriter(DatabasePath);
            xmlSerializer.Serialize(writer, Database);
        }

        public IEnumerable<Doctor> GetAll()
        {
            lock (Lock)
            {
                var document = XDocument.Load(DatabasePath);
                var xmlSerializer = new XmlSerializer(typeof(DatabaseWrapper));
                var database = xmlSerializer.Deserialize(document.CreateReader()) as DatabaseWrapper;
                return database?.Doctors;
            }
        }

        public IEnumerable<Doctor> GetByType(int type)
        {
            lock (Lock)
            {
                return Database?.Doctors.Where(x => x.Specializations.Any(s => s.Type == type));
            }
        }


        public Doctor GetById(int id)
        {
            lock (Lock)
            {
                return Database?.Doctors.Find(x => x.Id == id);
            }
        }

        public Doctor GetByPesel(string pesel)
        {
            lock (Lock)
            {
                return Database?.Doctors.Find(x => x.Pesel == pesel);
            }
        }

        public void AddDoctor(Doctor doctor)
        {
            lock (Lock)
            {
                Database.Doctors.Add(doctor);
                SaveDatabase();
            }
        }
    }
}