namespace ExaminationRooms.Domain.Aggregate
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot("Database", Namespace = "")]
    public class Database
    {
        public List<ExaminationRoom> ExaminationRooms { get; set; }
    }
}