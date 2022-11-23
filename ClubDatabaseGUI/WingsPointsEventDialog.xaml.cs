// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ClubDatabaseGUI
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WingsPointsEventDialog : ContentDialog
    {
        List<String> data;
        private String date, time;

        public WingsPointsEventDialog()
        {
            this.InitializeComponent();
            FixButtonStyle();
        }

        public WingsPointsEventDialog(List<String> data)
        {
            this.InitializeComponent();
            this.data = data;
            PopulateTextBoxes();
            FixButtonStyle();
        }

        private void FixButtonStyle()
        {
            this.PrimaryButtonStyle = (Style)Application.Current.Resources["AllButtonStyle"];
            this.CloseButtonStyle = (Style)Application.Current.Resources["AllButtonStyle"];
        }

        public void PopulateTextBoxes()
        {
            wTitleTextBox.Text = data[0];
            wHostingOrgIdTextBox.Text = data[1];
            wValueTextBox.Text = data[2];
            wDatePicker.Content = data[3];
            wLocationTextBox.Text = data[4];
            wAboutTextBox.Text = data[5];

            if (data[3] != null)
            {
                char[] delimiters = { ' ', '/', ':' };
                String[] dateTimeData = data[3].Split(delimiters);
                int[] dateIntegers = new int[3];

                for (int i = 0; i < dateIntegers.Length; i++)
                {
                    dateIntegers[i] = Convert.ToInt32(dateTimeData[i]);
                }
                wDate.SelectedDate = new DateTimeOffset(new DateTime(dateIntegers[2], dateIntegers[0], dateIntegers[1]));
                date = dateTimeData[0] + "/" + dateTimeData[1] + "/" + dateTimeData[2];

                if (dateTimeData[6].Equals("PM") && !dateTimeData[3].Equals("12"))
                {
                    dateTimeData[3] = (Convert.ToInt32(dateTimeData[3]) + 12).ToString();
                }

                if (dateTimeData[6].Equals("AM") && dateTimeData[3].Equals("12"))
                {
                    dateTimeData[3] = "0";
                }

                wTime.SelectedTime = TimeSpan.Parse(dateTimeData[3] + ":" + dateTimeData[4]);
                time = wTime.SelectedTime.ToString();

                wDateFlyout_Closing(null, null);
            }
        }

        private void wDateFlyout_Closing(FlyoutBase sender, FlyoutBaseClosingEventArgs args)
        {
            if (wDate.SelectedDate != null)
            {
                String dateData = wDate.SelectedDate.ToString();
                String[] dateArray = dateData.Split(" ");
                date = dateArray[0];
            }

            if (wTime.SelectedTime != null)
            {
                time = wTime.SelectedTime.ToString();
            }

            String fullDate;
            if (date != null)
            {
                if (time != null)
                {
                    fullDate = date + " " + time;
                }
                else
                {
                    fullDate = date + " " + "12:00:00 AM";
                }
                wDatePicker.Content = fullDate;
            }
        }

        public bool GenerateAddQuery(MySqlCommand cmd)
        {
            bool success = true;
            cmd.Parameters.Add(new MySqlParameter("statement_type", "insert"));

            if (!wTitleTextBox.Text.Equals("")) // Populate list based on textboxes
            {
                cmd.Parameters.Add(new MySqlParameter("new_title", wTitleTextBox.Text));
            }
            else
            {
                success = false;
            }
            if (!wHostingOrgIdTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_hosting_org_id", wHostingOrgIdTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_hosting_org_id", null));
            }
            if (!wValueTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_points_value",wValueTextBox.Text ));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_points_value", null));
            }
            if (!wDatePicker.Content.ToString().Equals("Choose A Date/Time"))
            {
                cmd.Parameters.Add(new MySqlParameter("new_date", MainWindow.DateParser(wDatePicker.Content.ToString())));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_date", null));
            }
            if (!wLocationTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_location", wLocationTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_location", null));
            }
            if (!wAboutTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_about", wAboutTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_about", null));
            }

            return success;
        }

        public bool GenerateModifyQuery(MySqlCommand cmd)
        {
            bool success = true;
            if (wTitleTextBox.Text.Equals(data[0]))
            {
                cmd.Parameters.Add(new MySqlParameter("statement_type", "update"));
                cmd.Parameters.Add(new MySqlParameter("new_title", wTitleTextBox.Text));

                if (!wHostingOrgIdTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_hosting_org_id", wHostingOrgIdTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_hosting_org_id", null));
                }
                if (!wValueTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_points_value", wValueTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_points_value", null));
                }
                if (!wDatePicker.Content.ToString().Equals("Choose A Date/Time"))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_date", MainWindow.DateParser(wDatePicker.Content.ToString())));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_date", null));
                }
                if (!wLocationTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_location", wLocationTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_location", null));
                }
                if (!wAboutTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_about", wAboutTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_about", null));
                }
            }
            else
            {
                success = false;
            }

            return success;
        }
    }
}
