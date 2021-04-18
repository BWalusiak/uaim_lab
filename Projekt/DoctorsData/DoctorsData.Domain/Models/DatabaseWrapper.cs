namespace DoctorsData.Domain.Models
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("Database", Namespace = "")]
    public class DatabaseWrapper
    {
        public List<Doctor> Doctors { get; set; }
    }
}