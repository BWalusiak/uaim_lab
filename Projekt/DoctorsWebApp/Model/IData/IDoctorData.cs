using System.Collections.ObjectModel;

namespace Model.IData
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Data;

    public interface IDoctorData : INotifyPropertyChanged
    {
        List<DoctorData> DoctorList { get; }

        List<MatchData> MatchList { get; }

        List<MatchData> SexMatchList { get; }

        string SearchTextDeleteDoctorId { get; set; }

        string SearchTextDeleteDoctorPesel { get; set; }

        DoctorData NewDoctor { get; set; }

        SpecializationData NewSpecialization { get; set; }

        ObservableCollection<SpecializationData> NewSpecializationList { get; set; }
    }
}