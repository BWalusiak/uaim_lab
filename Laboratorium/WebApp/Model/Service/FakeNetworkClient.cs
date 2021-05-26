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
                    Name = "Boguchwał Hack-Polay", Specializations = new List<int>
                    {
                        1, 2, 4, 0
                    }
                },
                ExaminationRoom = new ExaminationRoomData
                {
                    Number = "420b", Certifications = new List<int>
                    {
                        1, 2, 4, 7
                    }
                }
            },
            new MatchData
            {
                Doctor = new DoctorData
                {
                    Name = "Bartosz Giga Walusiak Programmer", Specializations = new List<int>
                    {
                        1, 2, 3, 5, 6
                    }
                },
                ExaminationRoom = new ExaminationRoomData
                {
                    Number = "69c", Certifications = new List<int>
                    {
                        1, 2, 5, 9
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