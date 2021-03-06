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

using Contoso.App.Views;
using Contoso.App.ViewModels;
using DoctorsUwpFrontendClientApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Globalization;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;
using DoctorsUwpFrontendClientApplication.Controller.Rest;

namespace Contoso.App
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Gets the app-wide MainViewModel singleton instance.
        /// </summary>
        public static MainViewModel ViewModel { get; } = new MainViewModel();

        /// <summary>
        /// Pipeline for interacting with backend service or database.
        /// </summary>

        public static INetworkClient Client { get; private set; }

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App() => InitializeComponent();

        /// <summary>
        /// Invoked when the application is launched normally by the end user.
        /// </summary>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            UseRest();

            // Prepare the app shell and window content.
            AppShell shell = Window.Current.Content as AppShell ?? new AppShell();
            shell.Language = ApplicationLanguages.Languages[0];
            Window.Current.Content = shell;

            if (shell.AppFrame.Content == null)
            {
                // When the navigation stack isn't restored, navigate to the first page
                // suppressing the initial entrance animation.
                shell.AppFrame.Navigate(typeof(DoctorListPage), null,
                    new SuppressNavigationTransitionInfo());
            }

            Window.Current.Activate();
        }

        /// <summary>
        /// Configures the app to use the REST data source. For convenience, a read-only source is provided. 
        /// You can also deploy your own copy of the REST service locally or to Azure. See the README for details.
        /// </summary>
        public static void UseRest()
        {
            Client = new NetworkClient("http://localhost:42069");
        }
    }
}