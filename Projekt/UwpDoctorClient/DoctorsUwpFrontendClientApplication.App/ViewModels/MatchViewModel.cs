using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorsApp.Web.Application.Dtos;

namespace Contoso.App.ViewModels
{
    public class MatchViewModel : BindableBase
    {
        public MatchViewModel(PatientDoctorDto model = null) => Model = model ?? new PatientDoctorDto();

        private PatientDoctorDto _model;

        public PatientDoctorDto Model
        {
            get => _model;
            set
            {
                if (_model != value)
                {
                    _model = value;

                    // Raise the PropertyChanged event for all properties.
                    OnPropertyChanged(string.Empty);
                }
            }
        }

        public string DoctorId
        {
            get => Model.Doctor.Id.ToString();
            set
            {
                if (value != Model.Doctor.Id.ToString())
                {
                    Model.Doctor.Id = Convert.ToInt32(value);
                    IsModified = true;
                    OnPropertyChanged();
                }
            }
        }

        public string DoctorName
        {
            get => Model.Doctor.Name;
            set
            {
                if (value != Model.Doctor.Name)
                {
                    Model.Doctor.Name = value;
                    IsModified = true;
                    OnPropertyChanged();
                }
            }
        }

        public string DoctorSpecializations
        {
            get => string.Join(",", Model.Doctor.Specializations);
            set
            {
                if (value != string.Join(",", Model.Doctor.Specializations))
                {
                    Model.Doctor.Specializations = stringToSpecializationDtos(value);
                    OnPropertyChanged();
                }
            }
        }

        public string PatientId
        {
            get => Model.Patient.Id.ToString();
            set
            {
                if (value != Model.Patient.Id.ToString())
                {
                    Model.Patient.Id = Convert.ToInt32(value);
                    IsModified = true;
                    OnPropertyChanged();
                }
            }
        }

        public string PatientName
        {
            get => Model.Patient.Name;
            set
            {
                if (value != Model.Patient.Name)
                {
                    Model.Patient.Name = value;
                    IsModified = true;
                    OnPropertyChanged();
                }
            }
        }

        public string PatientConditions
        {
            get => string.Join(",", Model.Patient.Conditions);
            set
            {
                if (value != string.Join(",", Model.Patient.Conditions))
                {
                    Model.Patient.Conditions = stringToConditionDtos(value);
                    OnPropertyChanged();
                }
            }
        }

        private static IEnumerable<ConditionDto> stringToConditionDtos(string value)
        {
            var conditions = new List<ConditionDto>();
            if (value != null)
            {
                try
                {
                    var conds = value.Split(",");
                    conditions.AddRange(conds
                        .Select(spec => spec.Split("-"))
                        .Select(specData =>
                            new ConditionDto(
                                Convert.ToInt32(specData.First()),
                                Convert.ToDateTime(specData.Last())
                            )
                        )
                    );
                }
                catch (Exception e) { }
            }
            return conditions;
        }

        private static IEnumerable<SpecializationDto> stringToSpecializationDtos(string value)
        {
            var specializations = new List<SpecializationDto>();
            if (value != null)
            {
                try
                {
                    var specs = value.Split(",");
                    specializations.AddRange(specs
                        .Select(spec => spec.Split("-"))
                        .Select(specData =>
                            new SpecializationDto(
                                Convert.ToInt32(specData.First()),
                                Convert.ToDateTime(specData.Last())
                            )
                        )
                    );
                    var debug = specializations;
                }
                catch (Exception e) { }
            }
            return specializations;
        }

        /// <summary>
        /// Gets or sets a value that indicates whether the underlying model has been modified. 
        /// </summary>
        /// <remarks>
        /// Used when sync'ing with the server to reduce load and only upload the models that have changed.
        /// </remarks>
        public bool IsModified { get; set; }

        private bool _isLoading;

        /// <summary>
        /// Gets or sets a value that indicates whether to show a progress bar. 
        /// </summary>
        public bool IsLoading
        {
            get => _isLoading;
            set => Set(ref _isLoading, value);
        }

        private bool _isNewMatch;

        /// <summary>
        /// Gets or sets a value that indicates whether this is a new customer.
        /// </summary>
        public bool IsNewMatch
        {
            get => _isNewMatch;
            set => Set(ref _isNewMatch, value);
        }

        private bool _isInEdit = false;

        /// <summary>
        /// Gets or sets a value that indicates whether the customer data is being edited.
        /// </summary>
        public bool IsInEdit
        {
            get => _isInEdit;
            set => Set(ref _isInEdit, value);
        }

        /// <summary>
        /// Saves customer data that has been edited.
        /// </summary>
        public async Task SaveAsync()
        {
            IsInEdit = false;
            IsModified = false;
            if (IsNewMatch)
            {
                IsNewMatch = false;
                App.ViewModel.Matches.Add(this);
            }

            //await App.Client.Doctors.UpsertAsync(Model);
        }

        /// <summary>
        /// Raised when the user cancels the changes they've made to the customer data.
        /// </summary>
        public event EventHandler AddNewPatientCanceled;

        /// <summary>
        /// Cancels any in progress edits.
        /// </summary>
        public async Task CancelEditsAsync()
        {
            if (IsNewMatch)
            {
                AddNewPatientCanceled?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                await RevertChangesAsync();
            }
        }

        /// <summary>
        /// Discards any edits that have been made, restoring the original values.
        /// </summary>
        public async Task RevertChangesAsync()
        {
            IsInEdit = false;
            if (IsModified)
            {
                await RefreshCustomerAsync();
                IsModified = false;
            }
        }

        /// <summary>
        /// Enables edit mode.
        /// </summary>
        public void StartEdit() => IsInEdit = true;

        /// <summary>
        /// Reloads all of the customer data.
        /// </summary>
        public async Task RefreshCustomerAsync() { }


        /// <summary>
        /// Called when a bound DataGrid control causes the customer to enter edit mode.
        /// </summary>
        public void BeginEdit()
        {
            // Not used.
        }

        /// <summary>
        /// Called when a bound DataGrid control cancels the edits that have been made to a customer.
        /// </summary>
        public async void CancelEdit() => await CancelEditsAsync();

        /// <summary>
        /// Called when a bound DataGrid control commits the edits that have been made to a customer.
        /// </summary>
        public async void EndEdit() => await SaveAsync();
    }
}
