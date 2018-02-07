//------------------------------------------------------------------------------
// <copyright file="KnownColorListsGenerator.cs" company="Appliberated">
// Copyright (C) 2016-2018 Appliberated. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
//------------------------------------------------------------------------------

namespace KnownColorLister
{
    using System;
    using System.Drawing;
    using System.Globalization;
    using System.Text;

    /// <summary>
    /// Provides a static method that generates and replaces placeholders with the html code for the known color lists.
    /// </summary>
    internal static class KnownColorListsGenerator
    {
        /// <summary>
        /// Replace the color lists placeholders with the actual color lists in the Ui html code.
        /// </summary>
        /// <param name="html">The initial Ui html code with lists placeholders.</param>
        /// <returns>The Ui html code with the replaced color lists.</returns>
        public static string InsertInto(string html)
        {
            StringBuilder systemColorsList = new StringBuilder();
            StringBuilder namedColorsList = new StringBuilder();

            // Enumerate each KnownColor
            foreach (KnownColor knownColor in Enum.GetValues(typeof(KnownColor)))
            {
                Color color = Color.FromKnownColor(knownColor);
                string colorHtml = GetColorItemHtml(color);

                if (color.IsSystemColor)
                {
                    // The color is a System Color, so append it to the System Colors list
                    systemColorsList.AppendLine(colorHtml);
                }
                else
                {
                    // The color is a System Color, so append it to the Named Colors List
                    namedColorsList.AppendLine(colorHtml);
                }
            }

            // Replace the lists placeholders with the html code of the color lists, and return the result
            return html.Replace(Properties.Resources.SystemColorsListPlaceholder, systemColorsList.ToString())
                .Replace(Properties.Resources.NamedColorsListPlaceholder, namedColorsList.ToString());
        }

        /// <summary>
        /// Coverts a Color object to a hexadecimal color string.
        /// </summary>
        /// <param name="color">A Color object.</param>
        /// <returns>The hexadecimal color string representation of the Color object.</returns>
        public static string Color2Hex(Color color)
        {
            return string.Format(CultureInfo.CurrentCulture, "#{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B);
        }

        /// <summary>
        /// Converts a Color object to a html list item to be displayed in the Ui.
        /// </summary>
        /// <param name="color">A Color object.</param>
        /// <returns>The html code of a color list item.</returns>
        private static string GetColorItemHtml(Color color)
        {
            string colorHex = Color2Hex(color);
            return string.Format(Properties.Resources.ColorListItemHtml, colorHex, color.Name);
        }
    }
}
