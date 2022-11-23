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
    public sealed partial class StudentDialog : ContentDialog
    {
        List<String> data;

        public StudentDialog()
        {
            this.InitializeComponent();
            FixButtonStyle();
        }

        public StudentDialog(List<String> data)
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
            sFNameTextBox.Text = data[0];
            sMInitTextBox.Text = data[1];
            sLNameTextBox.Text = data[2];
            sEagleIdTextBox.Text = data[3];
            sClassTextBox.Text = data[4];
            sPositionTextBox.Text = data[5];
            sPhoneTextBox.Text = data[6];
            sMembershipTextBox.Text = data[7];
        }

        public bool GenerateAddQuery(MySqlCommand cmd)
        {
            bool success = true;
            cmd.Parameters.Add(new MySqlParameter("statement_type", "insert"));

            if (!sFNameTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_first_name", sFNameTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_first_name", null));
            }
            if (!sMInitTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_m_init", sMInitTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_m_init", null));
            }
            if (!sLNameTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_last_name", sLNameTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_last_name", null));
            }
            if (!sEagleIdTextBox.Text.Equals("")) 
            {
                cmd.Parameters.Add(new MySqlParameter("new_eagle_id", sEagleIdTextBox.Text));
            }
            else
            {
                success = false;
            }
            if (!sClassTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_class", sClassTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_class", null));
            }
            if (!sPositionTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_position", sPositionTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_position", null));
            }
            if (!sPhoneTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_phone", sPhoneTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_phone", null));
            }
            if (!sMembershipTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_membership", sMembershipTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_membership", null));
            }

            return success;
        }

        public bool GenerateModifyQuery(MySqlCommand cmd)
        {
            bool success = true;
            if (sEagleIdTextBox.Text.Equals(data[3]))
            {
                cmd.Parameters.Add(new MySqlParameter("statement_type", "update"));
                cmd.Parameters.Add(new MySqlParameter("new_eagle_id", sEagleIdTextBox.Text));

                if (!sFNameTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_first_name", sFNameTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_first_name", null));
                }
                if (!sMInitTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_m_init", sMInitTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_m_init", null));
                }
                if (!sLNameTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_last_name", sLNameTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_last_name", null));
                }
                if (!sClassTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_class", sClassTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_class", null));
                }
                if (!sPositionTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_position", sPositionTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_position", null));
                }
                if (!sPhoneTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_phone", sPhoneTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_phone", null));
                }
                if (!sMembershipTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_membership", sMembershipTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_membership", null));
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
