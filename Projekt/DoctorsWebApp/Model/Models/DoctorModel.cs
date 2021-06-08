using System.Collections.ObjectModel;
using System.Linq;

namespace Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Data;
    using Service;

    public partial class Model
    {
        private List<DoctorData> _doctorList = new List<DoctorData>();

        private List<MatchData> _matchList = new List<MatchData>();

        private List<MatchData> _sexMatchList = new List<MatchData>();

        private DoctorData _doctorBest = new DoctorData();

        private string _searchTextBestDoctor;

        private DoctorData _selectedDoctor = new DoctorData();

        private DoctorData _newDoctor = new DoctorData()
        {
            Specializations = new List<SpecializationData>()
        };

        private SpecializationData _newSpecialization = new SpecializationData();

        private ObservableCollection<SpecializationData> _newSpecializationList = new ObservableCollection<SpecializationData>();


        public DoctorData NewDoctor
        {
            get => _newDoctor;
            set
            {
                _newDoctor = value;
                RaisePropertyChanged("NewDoctor");
            }
        }

        public SpecializationData NewSpecialization
        {
            get => _newSpecialization;
            set
            {
                _newSpecialization = value;
                RaisePropertyChanged("NewSpecialization");
            }
        }

        public ObservableCollection<SpecializationData> NewSpecializationList
        {
            get => _newSpecializationList;
            set
            {
                _newSpecializationList = value;
                RaisePropertyChanged("NewSpecializationList");
            }
        }

        public string SearchTextBestDoctor
        {
            get => _searchTextBestDoctor;
            set
            {
                _searchTextBestDoctor = value;
                RaisePropertyChanged("SearchTextBestDoctor");
            }
        }

        public string SearchTextDeleteDoctorId
        {
            get => _searchTextDeleteIdPatient;
            set
            {
                _searchTextDeleteIdPatient = value;
                RaisePropertyChanged("SearchTextDeleteIdDoctor");
            }
        }

        public string SearchTextDeleteDoctorPesel
        {
            get => _searchTextDeletePeselPatient;
            set
            {
                _searchTextDeletePeselPatient = value;
                RaisePropertyChanged("SearchTextDeleteDoctor");
            }
        }

        public List<DoctorData> DoctorList
        {
            get => _doctorList;
            private set
            {
                _doctorList = value;
                RaisePropertyChanged("DoctorList");
            }
        }

        public List<MatchData> MatchList
        {
            get => _matchList;
            private set
            {
                _matchList = value;
                RaisePropertyChanged("MatchList");
            }
        }

        public List<MatchData> SexMatchList
        {
            get => _sexMatchList;
            private set
            {
                _sexMatchList = value;
                RaisePropertyChanged("SexMatchList");
            }
        }

        public DoctorData DoctorBest
        {
            get => _doctorBest;
            private set
            {
                _doctorBest = value;
                RaisePropertyChanged("DoctorBest");
            }
        }

        public DoctorData SelectedDoctor
        {
            get => _selectedDoctor;
            set
            {
                _selectedDoctor = value;
                RaisePropertyChanged("SelectedDoctor");
            }
        }


        public void LoadDoctorList()
        {
            var t = Task.Run(() =>
            {
                var networkClient = NetworkClientFactory.GetNetworkClient(_configuration);
                try
                {
                    var matchList = networkClient.GetAllDoctors();
                    DoctorList = matchList.Result;
                }
                catch (Exception)
                {
                    // ignored
                }
            });
        }


        public void LoadMatchList()
        {
            var t = Task.Run(() =>
            {
                var networkClient = NetworkClientFactory.GetNetworkClient(_configuration);
                try
                {
                    var matchList = networkClient.GetMatches();
                    MatchList = matchList.Result;
                }
                catch (Exception)
                {
                    // ignored
                }
            });
        }


        public void LoadSexMatchList()
        {
            var t = Task.Run(() =>
            {
                var networkClient = NetworkClientFactory.GetNetworkClient(_configuration);
                try
                {
                    var matchList = networkClient.GetSexMatches();
                    SexMatchList = matchList.Result;
                }
                catch (Exception)
                {
                    // ignored
                }
            });
        }

        public void DeleteDoctorById()
        {
            var t = Task.Run(() =>
            {
                var networkClient = NetworkClientFactory.GetNetworkClient(_configuration);
                try
                {
                    networkClient.DeleteDoctorById(int.Parse(SearchTextDeleteDoctorId));
                }
                catch (Exception)
                {
                    // ignored
                }
            });
        }

        public void DeleteDoctorByPesel()
        {
            var t = Task.Run(() =>
            {
                var networkClient = NetworkClientFactory.GetNetworkClient(_configuration);
                try
                {
                    networkClient.DeleteDoctorByPesel(SearchTextDeleteDoctorPesel);
                }
                catch (Exception)
                {
                    // ignored
                }
            });
        }

        public void AddDoctor()
        {
            var t = Task.Run(() =>
            {
                var networkClient = NetworkClientFactory.GetNetworkClient(_configuration);
                try
                {
                    NewDoctor.Specializations = NewSpecializationList.ToList();
                    networkClient.AddDoctor(NewDoctor);
                }
                catch (Exception)
                {
                    // ignored
                }
            });
        }

        public void AddSpecializationToNewDoctor()
        {
            var t = Task.Run(() =>
            {
                var newSpecializationList = NewSpecializationList.ToList();
                newSpecializationList.Add(new SpecializationData
                {
                    Type = NewSpecialization.Type,
                    CertificationDate = NewSpecialization.CertificationDate
                });
                NewSpecializationList = new ObservableCollection<SpecializationData>(newSpecializationList);
            });
            t.Wait();
        }
    }
}