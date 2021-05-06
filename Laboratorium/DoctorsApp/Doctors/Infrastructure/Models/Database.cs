namespace Doctors.Infrastructure.Models
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("Database", Namespace = "")]
    public class Database
    {
        public List<Doctor> Doctors { get; set; }
    }
}