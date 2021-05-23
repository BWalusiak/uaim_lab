using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Contoso.App.ViewModels;
using Microsoft.Toolkit.Uwp.Helpers;
using Microsoft.Toolkit.Uwp.UI.Controls;


namespace Contoso.App.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PatientListPage : Page
    {
        public PatientListPage()
        {
            this.InitializeComponent();
            Window.Current.SizeChanged += CurrentWindow_SizeChanged;
        }

        /// <summary>
        /// Gets the app-wide ViewModel instance.
        /// </summary>
        public MainViewModel ViewModel => App.ViewModel;

        /// <summary>
        /// Adjust the command bar label positions depending on the window width.
        /// </summary>
        private void CurrentWindow_SizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            if (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily != "Windows.Mobile" &&
                e.Size.Width >= (double)App.Current.Resources["MediumWindowSnapPoint"])
            {
                mainCommandBar.DefaultLabelPosition = CommandBarDefaultLabelPosition.Right;
            }
            else
            {
                mainCommandBar.DefaultLabelPosition = CommandBarDefaultLabelPosition.Bottom;
            }
        }

        /// <summary>
        /// Initializes the AutoSuggestBox portion of the search box.
        /// </summary>
        private void PatientSearchBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (PatientSearchBox != null)
            {
                PatientSearchBox.AutoSuggestBox.QuerySubmitted += CustomerSearchBox_QuerySubmitted;
                PatientSearchBox.AutoSuggestBox.TextChanged += CustomerSearchBox_TextChanged;
                PatientSearchBox.AutoSuggestBox.PlaceholderText = "Search patients...";
            }
        }



        /// <summary>
        /// Updates the search box items source when the user changes the search text.
        /// </summary>
        private async void CustomerSearchBox_TextChanged(AutoSuggestBox sender,
            AutoSuggestBoxTextChangedEventArgs args)
        {
            // We only want to get results when it was a user typing,
            // otherwise we assume the value got filled in by TextMemberPath
            // or the handler for SuggestionChosen.
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                // If no search query is entered, refresh the complete list.
                if (String.IsNullOrEmpty(sender.Text))
                {
                    await DispatcherHelper.ExecuteOnUIThreadAsync(async () =>
                        await ViewModel.GetPatientListAsync());
                    sender.ItemsSource = null;
                }
                else
                {
                    string[] parameters = sender.Text.Split(new char[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);
                    sender.ItemsSource = ViewModel.Patients
                        .Where(patient => parameters.Any(parameter =>
                            patient.Name.StartsWith(parameter, StringComparison.OrdinalIgnoreCase) ||
                            patient.Sex.StartsWith(parameter, StringComparison.OrdinalIgnoreCase) ||
                            patient.Pesel.StartsWith(parameter, StringComparison.OrdinalIgnoreCase) ||
                            patient.Id.StartsWith(parameter, StringComparison.OrdinalIgnoreCase)))
                        .OrderByDescending(patient => parameters.Count(parameter =>
                            patient.Name.StartsWith(parameter, StringComparison.OrdinalIgnoreCase) ||
                            patient.Sex.StartsWith(parameter, StringComparison.OrdinalIgnoreCase) ||
                            patient.Pesel.StartsWith(parameter, StringComparison.OrdinalIgnoreCase) ||
                            patient.Id.StartsWith(parameter, StringComparison.OrdinalIgnoreCase)))
                        .Select(patient => $"{patient.Name}");
                }
            }
        }

        /// <summary>
        /// Filters the customer list based on the search text.
        /// </summary>
        private async void CustomerSearchBox_QuerySubmitted(AutoSuggestBox sender,
            AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (String.IsNullOrEmpty(args.QueryText))
            {
                await DispatcherHelper.ExecuteOnUIThreadAsync(async () =>
                    await ViewModel.GetPatientListAsync());
            }
            else
            {
                string[] parameters = sender.Text.Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                var matches = ViewModel.Patients.Where(patient => parameters
                    .Any(parameter =>
                        patient.Name.StartsWith(parameter, StringComparison.OrdinalIgnoreCase) ||
                        patient.Sex.StartsWith(parameter, StringComparison.OrdinalIgnoreCase) ||
                        patient.Pesel.StartsWith(parameter, StringComparison.OrdinalIgnoreCase) ||
                        patient.Id.StartsWith(parameter, StringComparison.OrdinalIgnoreCase)))
                    .OrderByDescending(patient => parameters.Count(parameter =>
                        patient.Name.StartsWith(parameter, StringComparison.OrdinalIgnoreCase) ||
                        patient.Sex.StartsWith(parameter, StringComparison.OrdinalIgnoreCase) ||
                        patient.Pesel.StartsWith(parameter, StringComparison.OrdinalIgnoreCase) ||
                        patient.Id.StartsWith(parameter, StringComparison.OrdinalIgnoreCase)))
                    .ToList();

                await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
                {
                    ViewModel.Patients.Clear();
                    foreach (var match in matches)
                    {
                        ViewModel.Patients.Add(match);
                    }
                });
            }
        }

        /// <summary>
        /// Reverts all changes to the row if the row has changes but a cell is not currently in edit mode.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Escape &&
                ViewModel.SelectedPatient != null &&
                ViewModel.SelectedPatient.IsModified &&
                !ViewModel.SelectedPatient.IsInEdit)
            {
                (sender as DataGrid).CancelEdit(DataGridEditingUnit.Row);
            }
        }

        /// <summary>
        /// Selects the tapped customer. 
        /// </summary>
        private void DataGrid_RightTapped(object sender, RightTappedRoutedEventArgs e) =>
            ViewModel.SelectedPatient = (e.OriginalSource as FrameworkElement).DataContext as PatientViewModel;


        /// <summary>
        /// Workaround to support earlier versions of Windows.
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
        }



        /// <summary>
        /// Menu flyout click control for selecting a customer and displaying details.
        /// </summary>
        private void ViewDetails_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.SelectedPatient != null)
            {
                App.Client.RemovePatientById(ViewModel.SelectedPatient.Model.Id);
                App.ViewModel.Sync();
            }
        }

        /// <summary>
        /// Navigates to a blank customer details page for the user to fill in.
        /// </summary>
        private void CreatePatient_Click(object sender, RoutedEventArgs e) =>
            Frame.Navigate(typeof(PatientsAddPage), null, new DrillInNavigationTransitionInfo());


        /// <summary>
        /// Sorts the data in the DataGrid.
        /// </summary>
        private void DataGrid_Sorting(object sender, DataGridColumnEventArgs e) =>
            (sender as DataGrid).Sort(e.Column, ViewModel.Patients.Sort);

    }
}
