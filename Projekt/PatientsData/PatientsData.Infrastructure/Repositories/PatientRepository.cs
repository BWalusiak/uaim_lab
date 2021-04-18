namespace PatientsData.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using Domain.Models;

    public class PatientRepository : IPatientRepository
    {
        private const string Path = "Resources/database.xml";
        private static readonly object PatientLock = new();
        private readonly PatientsList _patientsList;

        public PatientRepository()
        {
            var document = XDocument.Load(Path);
            var xmlSerializer = new XmlSerializer(typeof(PatientsList));
            _patientsList = xmlSerializer.Deserialize(document.CreateReader()) as PatientsList;
        }

        public IEnumerable<Patient> GetAll()
        {
            lock (PatientLock)
            {
                return _patientsList?.Patients;
            }
        }

        public IEnumerable<Patient> GetByType(int type)
        {
            lock (PatientLock)
            {
                return _patientsList?.Patients.Where(x => x.Conditions.Any(s => s.Type == type));
            }
        }


        public Patient GetById(int id)
        {
            lock (PatientLock)
            {
                return _patientsList?.Patients.Find(x => x.Id == id);
            }
        }

        public Patient GetByPesel(string pesel)
        {
            lock (PatientLock)
            {
                return _patientsList?.Patients.Find(x => x.Pesel == pesel);
            }
        }

        public void AddPatient(Patient patient)
        {
            lock (PatientLock)
            {
                try
                {
                    var xmlSerializer = new XmlSerializer(typeof(PatientsList));
                    if (_patientsList?.Patients == null || _patientsList.Patients.Any(d => d.Id == patient.Id))
                        return;
                    _patientsList.Patients.Add(patient);
                    using var writer = new StreamWriter(Path);
                    xmlSerializer.Serialize(writer, _patientsList);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}