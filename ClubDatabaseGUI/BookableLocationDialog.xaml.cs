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
    public sealed partial class BookableLocationDialog : ContentDialog
    {
        List<String> data;

        public BookableLocationDialog()
        {
            this.InitializeComponent();
            FixButtonStyle();
        }

        public BookableLocationDialog(List<String> data)
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
            campusTextBox.Text = data[0];
            locationTextBox.Text = data[1];
            typeTextBox.Text = data[2];
            capacityTextBox.Text = data[3];
        }

        public bool GenerateAddQuery(MySqlCommand cmd)
        {
            bool success = true;
            cmd.Parameters.Add(new MySqlParameter("statement_type", "insert"));

            if (!campusTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_campus", campusTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_campus", null));
            }

            if (!locationTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_location", locationTextBox.Text));
            }
            else
            {
                success = false;
            }
            if (!typeTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_type", typeTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_type", null));
            }
            if (!capacityTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_capacity", capacityTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_capacity", null));
            }

            return success;
        }

        public bool GenerateModifyQuery(MySqlCommand cmd)
        {
            bool success = true;
            if (locationTextBox.Text.Equals(data[1]))
            {
                cmd.Parameters.Add(new MySqlParameter("statement_type", "update"));
                cmd.Parameters.Add(new MySqlParameter("new_location", locationTextBox.Text));

                if (!campusTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_campus", campusTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_campus", null));
                }
                if (!typeTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_type", typeTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_type", null));
                }
                if (!capacityTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_capacity", capacityTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_capacity", null));
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
