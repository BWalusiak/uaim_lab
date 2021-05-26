namespace Model.Data
{
    using System.Collections.Generic;

    public class DoctorData
    {
        public string Name { get; set; }

        public IEnumerable<int> Specializations { get; set; }
    }
}