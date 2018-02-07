//------------------------------------------------------------------------------
// <copyright file="MainForm.cs" company="Appliberated">
// Copyright (C) 2016-2018 Appliberated. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
//------------------------------------------------------------------------------

namespace KnownColorLister
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;

#pragma warning disable SA1124

    /// <summary>
    /// The Main Form class.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            // Set the form's font to the default operating system font (Segoe UI on Vista)
            this.Font = SystemFonts.MessageBoxFont;

            // Required method for designer support
            this.InitializeComponent();
        }

        /// <summary>
        /// Update the Ui html code with the color lists, and display it in the Ui web browser.
        /// </summary>
        private void ShowUpdatedUi()
        {
            var assembly = Assembly.GetExecutingAssembly();

            Stream stream = null;
            try
            {
                stream = assembly.GetManifestResourceStream(Properties.Resources.UiHtmlFile);
                using (StreamReader reader = new StreamReader(stream))
                {
                    stream = null;

                    // Read the Ui html code from the resource file
                    string uiHtml = reader.ReadToEnd();

                    // Update it with the actual known color lists
                    uiHtml = KnownColorListsGenerator.InsertInto(uiHtml);

                    // Update it with the current product version
                    uiHtml = uiHtml.Replace(Properties.Resources.ProductVersionPlaceholder, Application.ProductVersion);

                    // Display it in the Ui web browser
                    this.uiWebBrowser.DocumentText = uiHtml;
                }
            }
            finally
            {
                if (stream != null)
                {
                    stream.Dispose();
                }
            }
        }

        #region Events

        /// <summary>
        /// Update the Ui with the actual known color lists before the form is displayed for the first time.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Empty event data.</param>
        private void EventMainFormLoad(object sender, EventArgs e)
        {
            this.ShowUpdatedUi();

            try
            {
                // Set the form icon to the executable file icon, to avoid storing a duplicate icon
                this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            }
            catch (Exception)
            {
                // Ignore
            }
        }

        private void EventUiWebBrowserPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            this.uiWebBrowser.WebBrowserShortcutsEnabled = true;

            // Enable scrolling with arrow keys in the web browser (see http://stackoverflow.com/a/23911083/220039)
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;
                return;
            }

            if (e.KeyCode == Keys.F5)
            {
                this.uiWebBrowser.WebBrowserShortcutsEnabled = false;
            }
        }

        /// <summary>
        /// Ensure the Ui web browser gets input focus when the form is activated in code or by the user.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">Empty event data.</param>
        private void EventMainFormActivated(object sender, EventArgs e)
        {
            // Give input focus to the web browser (based on https://goo.gl/36wOFV)
            if ((this.uiWebBrowser.Document != null) && (this.uiWebBrowser.Document.Body != null))
            {
                this.uiWebBrowser.Document.Body.Focus();
            }
        }

        #endregion
    }
}
