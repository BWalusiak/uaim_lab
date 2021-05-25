namespace Model.Data
{
    using System.Collections.Generic;

    public class ExaminationRoomData
    {
        public string Number { get; set; }

        public IEnumerable<int> Certifications { get; set; }
    }
}