namespace PatientsData.Domain.Models
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("PatientsList", Namespace = "")]
    public class PatientsList
    {
        public List<Patient> Patients { get; set; }
    }
}