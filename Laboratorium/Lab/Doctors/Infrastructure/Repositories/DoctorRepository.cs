namespace Doctors.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using Models;
    using Web.Applictaion.Dtos;

    public class DoctorRepository : IDoctorRepository
    {

        public IEnumerable<Doctor> GetBySpecialization(int specialization)
        {
            var document = XDocument.Load("Resources/database.xml");

            var xmlSerializer = new XmlSerializer(typeof(Database));

            var database = xmlSerializer.Deserialize(document.CreateReader()) as Database;
            return database?.Doctors.Where(it => it.Specializations.Contains(specialization));
        }

        public IEnumerable<Doctor> GetAll()
        {
            var document = XDocument.Load("Resources/database.xml");

            var xmlSerializer = new XmlSerializer(typeof(Database));

            var database = xmlSerializer.Deserialize(document.CreateReader()) as Database;
            return database?.Doctors;
        }

        public bool AddDoctor(DoctorDto doctorDto)
        {
            try
            {
                var document = XDocument.Load("Resources/database.xml");

                var xmlSerializer = new XmlSerializer(typeof(Database));

                var database = xmlSerializer.Deserialize(document.CreateReader()) as Database;
                if (database?.Doctors != null)
                {
                    if (database.Doctors.Any(doctor => doctor.Id == doctorDto.Id))
                    {
                        return false;
                    }

                    database?.Doctors.Add(new Doctor(doctorDto));
                }

                var writer = new StreamWriter("Resources/database.xml");
                xmlSerializer.Serialize(writer, database);

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }

    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetBySpecialization(int specialization);
        IEnumerable<Doctor> GetAll();

        bool AddDoctor(DoctorDto doctorDto);
    }
}