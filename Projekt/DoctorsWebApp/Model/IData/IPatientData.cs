namespace Model.IData
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Data;

    public interface IPatientData : INotifyPropertyChanged
    {
        List<PatientData> PatientList { get; }

        string SearchTextDeletePatientId { get; set; }

        string SearchTextDeletePatientPesel { get; set; }

        PatientData NewPatient { get; set; }

        List<string> Sexes { get; }

        ConditionData NewCondition { get; set; }

        ObservableCollection<ConditionData> NewConditionList { get; set; }
    }
}