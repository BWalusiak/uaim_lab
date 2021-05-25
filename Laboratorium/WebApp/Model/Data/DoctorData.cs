namespace Model.Data
{
    using System.Collections.Generic;

    public class DoctorData
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Sex { get; set; }

        public IEnumerable<int> Specializations { get; set; }
    }
}