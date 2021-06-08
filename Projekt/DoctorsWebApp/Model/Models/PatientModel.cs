namespace Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Service;

    public partial class Model
    {
        private List<PatientData> _patientList = new List<PatientData>();

        private string _searchTextDeleteIdPatient;

        private string _searchTextDeletePeselPatient;

        private PatientData _newPatient = new PatientData
        {
            Conditions = new List<ConditionData>()
        };

        private ConditionData _newCondition = new ConditionData();

        private ObservableCollection<ConditionData> _newConditionList = new ObservableCollection<ConditionData>();

        private ConditionData _conditionDelete = new ConditionData();

        public List<PatientData> PatientList
        {
            get => _patientList;
            private set
            {
                _patientList = value;
                RaisePropertyChanged("PatientList");
            }
        }
        public void LoadPatientList()
        {
            var t = Task.Run(() =>
            {
                var networkClient = NetworkClientFactory.GetNetworkClient(_configuration);
                try
                {
                    var matchList = networkClient.GetAllPatients();
                    PatientList = matchList.Result;
                }
                catch (Exception)
                {
                    // ignored
                }
            });
        }

        public string SearchTextDeletePatientId
        {
            get => _searchTextDeleteIdPatient;
            set
            {
                _searchTextDeleteIdPatient = value;
                RaisePropertyChanged("SearchTextDeleteIdPatient");
            }
        }

        public string SearchTextDeletePatientPesel
        {
            get => _searchTextDeletePeselPatient;
            set
            {
                _searchTextDeletePeselPatient = value;
                RaisePropertyChanged("SearchTextDeletePeselPatient");
            }
        }

        public PatientData NewPatient
        {
            get => _newPatient;
            set
            {
                _newPatient = value;
                RaisePropertyChanged("NewPatient");
            }
        }

        public List<string> Sexes
        {
            get => Enum.GetNames(typeof(SexData)).ToList();
        }

        public ConditionData NewCondition
        {
            get => _newCondition;
            set
            {
                _newCondition = value;
                RaisePropertyChanged("NewCondition");
            }
        }

        public ObservableCollection<ConditionData> NewConditionList
        {
            get => _newConditionList;
            set
            {
                _newConditionList = value;
                RaisePropertyChanged("NewConditionList");
            }
        }

        public ConditionData ConditionDelete
        {
            get => _conditionDelete;
            set
            {
                _conditionDelete = value;
                RaisePropertyChanged("ConditionDelete");
            }
        }

        public void AddPatient()
        {
            var t = Task.Run(() =>
            {
                var networkClient = NetworkClientFactory.GetNetworkClient(_configuration);
                try
                {
                    NewPatient.Conditions = NewConditionList.ToList();
                    networkClient.AddPatient(NewPatient);
                }
                catch (Exception)
                {
                    // ignored
                }
            });
        }

        public void AddConditionToNewPatient()
        {
            var t = Task.Run(() =>
            {
                var xd = NewConditionList.ToList();
                xd.Add(new ConditionData
                {
                    Type = NewCondition.Type,
                    DiagnosisDate = NewCondition.DiagnosisDate
                });
                NewConditionList = new ObservableCollection<ConditionData>(xd);
            });
            t.Wait();
        }

        public void DeletePatientById()
        {
            var t = Task.Run(() =>
            {
                var networkClient = NetworkClientFactory.GetNetworkClient(_configuration);
                try
                {
                    networkClient.DeletePatientById(int.Parse(SearchTextDeletePatientId));
                }
                catch (Exception)
                {
                    // ignored
                }
            });
        }

        public void DeletePatientByPesel()
        {
            var t = Task.Run(() =>
            {
                var networkClient = NetworkClientFactory.GetNetworkClient(_configuration);
                try
                {
                    networkClient.DeletePatientByPesel(SearchTextDeletePatientPesel);
                }
                catch (Exception)
                {
                    // ignored
                }
            });
        }
    }
}