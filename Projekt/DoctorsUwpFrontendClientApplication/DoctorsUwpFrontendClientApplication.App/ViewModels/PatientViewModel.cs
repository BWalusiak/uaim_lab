using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorsApp.Web.Application.Dtos;

namespace Contoso.App.ViewModels
{
    public class PatientViewModel : BindableBase
    {
        /// <summary>
        /// Initializes a new instance of the CustomerViewModel class that wraps a Customer object.
        /// </summary>
        public PatientViewModel(PatientDto model = null) => Model = model ?? new PatientDto();

        private PatientDto _model;

        /// <summary>
        /// Gets or sets the underlying Customer object.
        /// </summary>
        public PatientDto Model
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



        /// <summary>
        /// Gets or sets the customer's first name.
        /// </summary>
        public string Id
        {
            get => Model.Id.ToString();
            set
            {
                if (value != Model.Id.ToString())
                {
                    Model.Id = Convert.ToInt32(value);
                    IsModified = true;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets the customer's first name.
        /// </summary>
        public string Name
        {
            get => Model.Name;
            set
            {
                if (value != Model.Name)
                {
                    Model.Name = value;
                    IsModified = true;
                    OnPropertyChanged();
                }
            }
        }

        public string Pesel
        {
            get => Model.Pesel;
            set
            {
                if (value != Model.Pesel)
                {
                    Model.Pesel = value;
                    IsModified = true;
                    OnPropertyChanged();
                }
            }
        }

        public string Sex
        {
            get => Model.Sex;
            set
            {
                if (value != Model.Sex)
                {
                    Model.Sex = value;
                    IsModified = true;
                    OnPropertyChanged();
                }
            }
        }

        public string Conditions
        {
            get => string.Join(",", Model.Conditions);
            set
            {
                if (value != string.Join(",", Model.Conditions))
                {
                    Model.Conditions = stringToConditionDtos(value);
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

        private bool _isNewDoctor;

        /// <summary>
        /// Gets or sets a value that indicates whether this is a new customer.
        /// </summary>
        public bool IsNewDoctor
        {
            get => _isNewDoctor;
            set => Set(ref _isNewDoctor, value);
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
            if (IsNewDoctor)
            {
                IsNewDoctor = false;
                App.ViewModel.Patients.Add(this);
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
            if (IsNewDoctor)
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
        public async Task RefreshCustomerAsync()
        {
            Model = await App.Client.GetPatientById(Model.Id);
        }


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
