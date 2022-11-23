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
    public sealed partial class FacultyDialog : ContentDialog
    {
        List<String> data;

        public FacultyDialog()
        {
            this.InitializeComponent();
            FixButtonStyle();
        }

        public FacultyDialog(List<String> data)
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
            fFNameTextBox.Text = data[0];
            fLNameTextBox.Text = data[1];
            fEagleIdTextBox.Text = data[2];
            fDeptTextBox.Text = data[3];
            fPhoneTextBox.Text = data[4];
            fOfficeTextBox.Text = data[5];
            fEmailTextBox.Text = data[6];
        }

        public bool GenerateAddQuery(MySqlCommand cmd)
        {
            bool success = true;
            cmd.Parameters.Add(new MySqlParameter("statement_type", "insert"));

            if (!fFNameTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_first_name", fFNameTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_first_name", null));
            }
            if (!fLNameTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_last_name", fLNameTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_last_name", null));
            }
            if (!fEagleIdTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_eagle_id", fEagleIdTextBox.Text));
            }
            else
            {
                success = false;
            }
            if (!fDeptTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_department", fDeptTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_department", null));
            }
            if (!fPhoneTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_phone", fPhoneTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_phone", null));
            }
            if (!fOfficeTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_office_num", fOfficeTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_office_num", null));
            }
            if (!fEmailTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_email", fEmailTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_email", null));
            }

            return success;
        }

        public bool GenerateModifyQuery(MySqlCommand cmd)
        {
            bool success = true;
            if (fEagleIdTextBox.Text.Equals(data[2]))
            {
                cmd.Parameters.Add(new MySqlParameter("statement_type", "update"));
                cmd.Parameters.Add(new MySqlParameter("new_eagle_id", fEagleIdTextBox.Text));

                if (!fFNameTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_first_name", fFNameTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_first_name", null));
                }
                if (!fLNameTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_last_name", fLNameTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_last_name", null));
                }
                if (!fDeptTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_department", fDeptTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_department", null));
                }
                if (!fPhoneTextBlock.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_phone", fPhoneTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_phone", null));
                }
                if (!fOfficeTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_office_num", fOfficeTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_office_num", null));
                }
                if (!fEmailTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_email", fEmailTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_email", null));
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
