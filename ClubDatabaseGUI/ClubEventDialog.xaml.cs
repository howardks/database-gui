// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
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
    public sealed partial class ClubEventDialog : ContentDialog
    {
        List<String> data;
        private String date, time;

        public ClubEventDialog()
        {
            this.InitializeComponent();
            FixButtonStyle();
        }

        public ClubEventDialog(List<String> data)
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
            ceEventIdTextBox.Text = data[0];
            ceHostingOrgIdTextBox.Text = data[1];
            ceDatePicker.Content = data[2];
            ceLocationTextBox.Text = data[3];
            ceAboutTextBox.Text = data[4];

            if (data[2] != null)
            {
                char[] delimiters = { ' ', '/', ':' };
                String[] dateTimeData = data[2].Split(delimiters);
                int[] dateIntegers = new int[3];

                for (int i = 0; i < dateIntegers.Length; i++)
                {
                    dateIntegers[i] = Convert.ToInt32(dateTimeData[i]);
                }
                ceDate.SelectedDate = new DateTimeOffset(new DateTime(dateIntegers[2], dateIntegers[0], dateIntegers[1]));
                date = dateTimeData[0] + "/" + dateTimeData[1] + "/" + dateTimeData[2];

                if (dateTimeData[6].Equals("PM") && !dateTimeData[3].Equals("12"))
                {
                    dateTimeData[3] = (Convert.ToInt32(dateTimeData[3]) + 12).ToString();
                }

                if (dateTimeData[6].Equals("AM") && dateTimeData[3].Equals("12"))
                {
                    dateTimeData[3] = "0";
                }

                ceTime.SelectedTime = TimeSpan.Parse(dateTimeData[3] + ":" + dateTimeData[4]);
                time = ceTime.SelectedTime.ToString();

                ceDateFlyout_Closing(null, null);
            }
        }

        private void ceDateFlyout_Closing(FlyoutBase sender, FlyoutBaseClosingEventArgs args)
        {
            if (ceDate.SelectedDate != null)
            {
                String dateData = ceDate.SelectedDate.ToString();
                String[] dateArray = dateData.Split(" ");
                date = dateArray[0];
            }

            if (ceTime.SelectedTime != null)
            {
                time = ceTime.SelectedTime.ToString();
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
                ceDatePicker.Content = fullDate;
            }
        }

        public bool GenerateAddQuery(MySqlCommand cmd) 
        {
            bool success = true;
            cmd.Parameters.Add(new MySqlParameter("statement_type", "insert"));

            if (!ceEventIdTextBox.Text.Equals("")) // Populate list based on textboxes
            {
                cmd.Parameters.Add(new MySqlParameter("new_event_id", ceEventIdTextBox.Text));
            }
            else
            {
                success = false;
            }
            if (!ceHostingOrgIdTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_hosting_org_id", ceHostingOrgIdTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_hosting_org_id", null));
            }
            if (!ceDatePicker.Content.ToString().Equals("Choose A Date/Time"))
            {
                cmd.Parameters.Add(new MySqlParameter("new_date", MainWindow.DateParser(ceDatePicker.Content.ToString())));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_date", null));
            }
            if (!ceLocationTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_location", ceLocationTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_location", null));
            }
            if (!ceAboutTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_about", ceAboutTextBox.Text));
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
            if (ceEventIdTextBox.Text.Equals(data[0]))
            {
                cmd.Parameters.Add(new MySqlParameter("statement_type", "update"));
                cmd.Parameters.Add(new MySqlParameter("new_event_id", ceEventIdTextBox.Text));

                if (!ceHostingOrgIdTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_hosting_org_id", ceHostingOrgIdTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_hosting_org_id", null));
                }
                if (!ceDatePicker.Content.ToString().Equals("Choose A Date/Time"))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_date", MainWindow.DateParser(ceDatePicker.Content.ToString())));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_date", null));
                }
                if (!ceLocationTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_location", ceLocationTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_location", null));
                }
                if (!ceAboutTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_about", ceAboutTextBox.Text));
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
