﻿using System;
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
using Windows.UI.Xaml.Navigation;
using Contoso.App.ViewModels;
using Microsoft.Toolkit.Uwp.Helpers;
using Microsoft.Toolkit.Uwp.UI.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Contoso.App.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SexMatchListPage : Page
    {
        public SexMatchListPage()
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
        private void SexMatchSearchBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (SexMatchSearchBox != null)
            {
                SexMatchSearchBox.AutoSuggestBox.QuerySubmitted += SexMatchSearchBox_QuerySubmitted;
                SexMatchSearchBox.AutoSuggestBox.TextChanged += SexMatchSearchBox_TextChanged;
                SexMatchSearchBox.AutoSuggestBox.PlaceholderText = "Search matches...";
            }
        }



        /// <summary>
        /// Updates the search box items source when the user changes the search text.
        /// </summary>
        private async void SexMatchSearchBox_TextChanged(AutoSuggestBox sender,
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
                        await ViewModel.GetSexMatchListAsync());
                    sender.ItemsSource = null;
                }
                else
                {
                    string[] parameters = sender.Text.Split(new char[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);
                    sender.ItemsSource = ViewModel.SexMatches
                        .Where(match => parameters.Any(parameter =>
                            match.DoctorName.StartsWith(parameter, StringComparison.OrdinalIgnoreCase) ||
                            match.PatientName.StartsWith(parameter, StringComparison.OrdinalIgnoreCase) ||
                            match.DoctorSex.StartsWith(parameter, StringComparison.OrdinalIgnoreCase) ||
                            match.PatientSex.StartsWith(parameter, StringComparison.OrdinalIgnoreCase)))
                        .OrderByDescending(match => parameters.Count(parameter =>
                            match.DoctorName.StartsWith(parameter, StringComparison.OrdinalIgnoreCase) ||
                            match.PatientName.StartsWith(parameter, StringComparison.OrdinalIgnoreCase) ||
                            match.DoctorSex.StartsWith(parameter, StringComparison.OrdinalIgnoreCase) ||
                            match.PatientSex.StartsWith(parameter, StringComparison.OrdinalIgnoreCase)))
                        .Select(match => $"{match.DoctorName}");
                }
            }
        }

        /// <summary>
        /// Filters the customer list based on the search text.
        /// </summary>
        private async void SexMatchSearchBox_QuerySubmitted(AutoSuggestBox sender,
            AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (String.IsNullOrEmpty(args.QueryText))
            {
                await DispatcherHelper.ExecuteOnUIThreadAsync(async () =>
                    await ViewModel.GetSexMatchListAsync());
            }
            else
            {
                string[] parameters = sender.Text.Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                var matches = ViewModel.SexMatches.Where(match => parameters
                    .Any(parameter =>
                        match.DoctorName.StartsWith(parameter, StringComparison.OrdinalIgnoreCase) ||
                        match.PatientName.StartsWith(parameter, StringComparison.OrdinalIgnoreCase) ||
                        match.DoctorSex.StartsWith(parameter, StringComparison.OrdinalIgnoreCase) ||
                        match.PatientSex.StartsWith(parameter, StringComparison.OrdinalIgnoreCase)))
                    .OrderByDescending(match => parameters.Count(parameter =>
                        match.DoctorName.StartsWith(parameter, StringComparison.OrdinalIgnoreCase) ||
                        match.PatientName.StartsWith(parameter, StringComparison.OrdinalIgnoreCase) ||
                        match.DoctorSex.StartsWith(parameter, StringComparison.OrdinalIgnoreCase) ||
                        match.PatientSex.StartsWith(parameter, StringComparison.OrdinalIgnoreCase)))
                    .ToList();

                await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
                {
                    ViewModel.SexMatches.Clear();
                    foreach (var match in matches)
                    {
                        ViewModel.SexMatches.Add(match);
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
                ViewModel.SelectedSexMatch != null &&
                ViewModel.SelectedSexMatch.IsModified &&
                !ViewModel.SelectedSexMatch.IsInEdit)
            {
                (sender as DataGrid).CancelEdit(DataGridEditingUnit.Row);
            }
        }

        /// <summary>
        /// Selects the tapped customer. 
        /// </summary>
        private void DataGrid_RightTapped(object sender, RightTappedRoutedEventArgs e) =>
            ViewModel.SelectedSexMatch = (e.OriginalSource as FrameworkElement).DataContext as SexMatchViewModel;


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
            if (ViewModel.SelectedSexMatch != null)
            {
                App.ViewModel.Sync();
            }
        }


        /// <summary>
        /// Sorts the data in the DataGrid.
        /// </summary>
        private void DataGrid_Sorting(object sender, DataGridColumnEventArgs e) =>
            (sender as DataGrid).Sort(e.Column, ViewModel.SexMatches.Sort);

    }
}
