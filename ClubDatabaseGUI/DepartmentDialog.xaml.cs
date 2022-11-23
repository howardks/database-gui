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
    public sealed partial class DepartmentDialog : ContentDialog
    {
        List<String> data;

        public DepartmentDialog()
        {
            this.InitializeComponent();
            FixButtonStyle();
        }

        public DepartmentDialog(List<String> data)
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
            dNameTextBox.Text = data[0];
            dOfficeTextBox.Text = data[1];
            dPhoneTextBox.Text = data[2];
        }

        public bool GenerateAddQuery(MySqlCommand cmd)
        {
            bool success = true;
            cmd.Parameters.Add(new MySqlParameter("statement_type", "insert"));

            if (!dNameTextBlock.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_name", dNameTextBox.Text));
            }
            else
            {
                success = false;
            }
            if (!dOfficeTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_office_number", dOfficeTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_office_number", null));
            }
            if (!dPhoneTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_phone", dPhoneTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_phone", null));
            }
            return success;
        }

        public bool GenerateModifyQuery(MySqlCommand cmd)
        {
            bool success = true;

            if (dNameTextBox.Text.Equals(data[0]))
            {
                cmd.Parameters.Add(new MySqlParameter("statement_type", "update"));
                cmd.Parameters.Add(new MySqlParameter("new_name", dNameTextBox.Text));

                if (!dOfficeTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_office_number", dOfficeTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_office_number", null));
                }
                if (!dPhoneTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_phone", dPhoneTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_phone", null));
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
