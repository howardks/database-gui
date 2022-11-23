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
    public sealed partial class ClubDialog : ContentDialog
    {
        List<String> data;

        public ClubDialog()
        {
            this.InitializeComponent();
            FixButtonStyle();
        }

        public ClubDialog(List<String> data)
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
            cOrgIdTextBox.Text = data[0];
            cNameTextBox.Text = data[1];
            cAdvisorIdTextBox.Text = data[2];
            cAboutTextBox.Text = data[3];
        }

        public bool GenerateAddQuery(MySqlCommand cmd)
        {
            bool success = true;
            cmd.Parameters.Add(new MySqlParameter("statement_type", "insert"));

            if (!cOrgIdTextBox.Text.Equals("")) // Populate list based on textboxes
            {
                cmd.Parameters.Add(new MySqlParameter("new_org_id", cOrgIdTextBox.Text));
            }
            else
            {
                success = false;
            }
            if (!cNameTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_name", cNameTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_name", null));
            }
            if (!cAdvisorIdTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_advisor_id", cAdvisorIdTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_advisor_id", null));
            }
            if (!cAboutTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_about", cAboutTextBox.Text));
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
            if (cOrgIdTextBox.Text.Equals(data[0]))
            {
                cmd.Parameters.Add(new MySqlParameter("statement_type", "update"));
                cmd.Parameters.Add(new MySqlParameter("new_org_id", cOrgIdTextBox.Text));

                if (!cNameTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_name", cNameTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_name", null));
                }
                if (!cAdvisorIdTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_advisor_id", cAdvisorIdTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_advisor_id", null));
                }
                if (!cAboutTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_about", cAboutTextBox.Text));
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
