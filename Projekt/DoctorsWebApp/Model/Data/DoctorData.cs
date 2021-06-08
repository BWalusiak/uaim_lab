namespace Model.Data
{
    using System.Collections.Generic;

    public class DoctorData
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Sex { get; set; }

        public string Pesel { get; set; }

        public List<SpecializationData> Specializations { get; set; }
    }
}