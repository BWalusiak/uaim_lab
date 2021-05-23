//  ---------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
// 
//  The MIT License (MIT)
// 
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
// 
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
// 
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//  ---------------------------------------------------------------------------------

using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.Helpers;

namespace Contoso.App.ViewModels
{
    /// <summary>
    /// Provides data and commands accessible to the entire app.  
    /// </summary>
    public class MainViewModel : BindableBase
    {
        /// <summary>
        /// Creates a new MainViewModel.
        /// </summary>
        public MainViewModel()
        {
            Task.Run(GetDoctorListAsync);
            Task.Run(GetPatientListAsync);
            Task.Run(GetMatchListAsync);
            Task.Run(GetSexMatchListAsync);
        }


        /// <summary>
        /// The collection of patients in the list. 
        /// </summary>
        public ObservableCollection<DoctorViewModel> Doctors { get; }
            = new ObservableCollection<DoctorViewModel>();


        /// <summary>
        /// The collection of patients in the list. 
        /// </summary>
        public ObservableCollection<PatientViewModel> Patients { get; }
            = new ObservableCollection<PatientViewModel>();

        /// <summary>
        /// The collection of patients in the list. 
        /// </summary>
        public ObservableCollection<MatchViewModel> Matches { get; }
            = new ObservableCollection<MatchViewModel>();

        /// <summary>
        /// The collection of patients in the list. 
        /// </summary>
        public ObservableCollection<SexMatchViewModel> SexMatches { get; }
            = new ObservableCollection<SexMatchViewModel>();
        private DoctorViewModel _selectedDoctor;
        private PatientViewModel _selectedPatient;
        private MatchViewModel _selectedMatch;
        private SexMatchViewModel _selectedSexMatch;

        public int GetNewDoctorId()
        {
            var topId = 1;
            foreach (var doctor in Doctors)
            {
                if (doctor.Model.Id >= topId)
                {
                    topId = doctor.Model.Id + 1;
                }
            }

            return topId;
        }

        public int GetNewPatientId()
        {
            var topId = 1;
            foreach (var patient in Patients)
            {
                if (patient.Model.Id >= topId)
                {
                    topId = patient.Model.Id + 1;
                }
            }

            return topId;
        }

        /// <summary>
        /// Gets or sets the selected doctor, or null if no doctor is selected. 
        /// </summary>
        public DoctorViewModel SelectedDoctor
        {
            get => _selectedDoctor;
            set => Set(ref _selectedDoctor, value);
        }

        /// <summary>
        /// Gets or sets the selected patient, or null if no doctor is selected. 
        /// </summary>
        public PatientViewModel SelectedPatient
        {
            get => _selectedPatient;
            set => Set(ref _selectedPatient, value);
        }

        /// <summary>
        /// Gets or sets the selected match, or null if no doctor is selected. 
        /// </summary>
        public MatchViewModel SelectedMatch
        {
            get => _selectedMatch;
            set => Set(ref _selectedMatch, value);
        }

        /// <summary>
        /// Gets or sets the selected sexMatch, or null if no doctor is selected. 
        /// </summary>
        public SexMatchViewModel SelectedSexMatch
        {
            get => _selectedSexMatch;
            set => Set(ref _selectedSexMatch, value);
        }

        private bool _isLoading = false;

        /// <summary>
        /// Gets or sets a value indicating whether the Customers list is currently being updated. 
        /// </summary>
        public bool IsLoading
        {
            get => _isLoading; 
            set => Set(ref _isLoading, value);
        }



        /// <summary>
        /// Gets the complete list of doctors from the database.
        /// </summary>
        public async Task GetDoctorListAsync()
        {
            await DispatcherHelper.ExecuteOnUIThreadAsync(() => IsLoading = true);

            var doctors = await App.Client.GetAllDoctors();
            if (doctors == null)
            {
                return;
            }

            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                Doctors.Clear();
                foreach (var c in doctors)
                {
                    Doctors.Add(new DoctorViewModel(c));
                }
                IsLoading = false;
            });
        }



        /// <summary>
        /// Gets the complete list of doctors from the database.
        /// </summary>
        public async Task GetPatientListAsync()
        {
            await DispatcherHelper.ExecuteOnUIThreadAsync(() => IsLoading = true);

            var patients = await App.Client.GetAllPatient();
            if (patients == null)
            {
                return;
            }

            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                Patients.Clear();
                foreach (var c in patients)
                {
                    Patients.Add(new PatientViewModel(c));
                }
                IsLoading = false;
            });
        }



        /// <summary>
        /// Gets the complete list of doctors from the database.
        /// </summary>
        public async Task GetMatchListAsync()
        {
            await DispatcherHelper.ExecuteOnUIThreadAsync(() => IsLoading = true);

            var matches = await App.Client.GetBestPatientDoctorMatches();
            if (matches == null)
            {
                return;
            }

            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                Matches.Clear();
                foreach (var c in matches)
                {
                    Matches.Add(new MatchViewModel(c));
                }
                IsLoading = false;
            });
        }



        /// <summary>
        /// Gets the complete list of doctors from the database.
        /// </summary>
        public async Task GetSexMatchListAsync()
        {
            await DispatcherHelper.ExecuteOnUIThreadAsync(() => IsLoading = true);

            var matches = await App.Client.GetMatchDoctorSexWithPatientSex();
            if (matches == null)
            {
                return;
            }

            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                SexMatches.Clear();
                foreach (var c in matches)
                {
                    SexMatches.Add(new SexMatchViewModel(c));
                }
                IsLoading = false;
            });
        }

        /// <summary>
        /// Saves any modified customers and reloads the customer list from the database.
        /// </summary>
        public void Sync()
        {
            Task.Run(async () =>
            {
                await GetDoctorListAsync();
                await GetPatientListAsync();
                await GetMatchListAsync();
                await GetSexMatchListAsync();
                IsLoading = false;
            });
        }
    }
}
