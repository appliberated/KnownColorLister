//------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Appliberated">
// Copyright (C) 2016-2018 Appliberated. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
//------------------------------------------------------------------------------

namespace KnownColorLister
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// The main program class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
