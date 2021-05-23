using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Contoso.App.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Contoso.App.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PatientsAddPage : Page
    {
        public PatientsAddPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Used to bind the UI to the data.
        /// </summary>
        public PatientViewModel ViewModel { get; set; }

        /// <summary>
        /// Navigate to the previous page when the user cancels the creation of a new customer record.
        /// </summary>
        private void AddNewDoctorCanceled(object sender, EventArgs e) => Frame.GoBack();

        /// <summary>
        /// Displays the selected customer data.
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter == null)
            {
                ViewModel = new PatientViewModel()
                {
                    IsNewDoctor = true,
                    IsInEdit = true
                };
                ViewModel.Model.Id = App.ViewModel.GetNewPatientId();
            }
            else
            {
                ViewModel = App.ViewModel.Patients.First(patient => patient.Model.Id == (int)e.Parameter);
            }

            ViewModel.AddNewPatientCanceled += AddNewDoctorCanceled;
            base.OnNavigatedTo(e);
        }

        /// <summary>
        /// Disconnects the AddNewCustomerCanceled event handler from the ViewModel 
        /// when the parent frame navigates to a different page.
        /// </summary>
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            ViewModel.AddNewPatientCanceled -= AddNewDoctorCanceled;
            base.OnNavigatedFrom(e);
        }



        /// <summary>
        /// Navigates to a blank customer details page for the user to fill in.
        /// </summary>
        private void AddPatient_Click(object sender, RoutedEventArgs e)
        {
            App.Client.AddPatient(ViewModel.Model);
            Frame.Navigate(typeof(PatientListPage), null, new DrillInNavigationTransitionInfo());
        }

        /// <summary>
        /// Adjust the command bar button label positions for optimimum viewing.
        /// </summary>
        private void CommandBar_Loaded(object sender, RoutedEventArgs e)
        {
            if (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
            {
                (sender as CommandBar).DefaultLabelPosition = CommandBarDefaultLabelPosition.Bottom;
            }
            else
            {
                (sender as CommandBar).DefaultLabelPosition = CommandBarDefaultLabelPosition.Right;
            }

            // Disable dynamic overflow on this page. There are only a few commands, and it causes
            // layout problems when save and cancel commands are shown and hidden.
            (sender as CommandBar).IsDynamicOverflowEnabled = false;
        }
    }
}
