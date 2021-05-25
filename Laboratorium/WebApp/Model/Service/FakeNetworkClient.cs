namespace Model.Service
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;

    public class FakeNetworkClient : INetwork
    {
        private static readonly MatchData[] MatchDataList =
        {
            new MatchData
            {
                Doctor = new DoctorData
                {
                    FirstName = "Marcin", LastName = "Dadura", Sex = "male", Specializations = new List<int>
                    {
                        1, 2, 4
                    }
                },
                Room = new ExaminationRoomData
                {
                    Number = "68b", Certifications = new List<int>
                    {
                        1, 2, 4
                    }
                }
            },
            new MatchData
            {
                Doctor = new DoctorData
                {
                    FirstName = "Maciej", LastName = "Włodarczyk", Sex = "female", Specializations = new List<int>
                    {
                        1, 2, 3
                    }
                },
                Room = new ExaminationRoomData
                {
                    Number = "69b", Certifications = new List<int>
                    {
                        1, 2, 5
                    }
                }
            }
        };

        public MatchData[] GetMatches()
        {
            return MatchDataList.ToArray();
        }
    }
}