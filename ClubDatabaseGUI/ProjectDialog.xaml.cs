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
    public sealed partial class ProjectDialog : ContentDialog
    {
        List<String> data;

        public ProjectDialog()
        {
            this.InitializeComponent();
            FixButtonStyle();
        }

        public ProjectDialog(List<String> data)
        {
            this.InitializeComponent();
            this.data = data;
            PopulateTextBoxes();
            FixButtonStyle();
        }

        public void PopulateTextBoxes()
        {
            pProjectIdTextBox.Text = data[0];
            pOrgIdTextBox.Text = data[1];
            pTitleTextBox.Text = data[2];
            pParticipantsTextBox.Text = data[3];
            pAboutTextBox.Text = data[4];
        }

        private void FixButtonStyle()
        {
            this.PrimaryButtonStyle = (Style)Application.Current.Resources["AllButtonStyle"];
            this.CloseButtonStyle = (Style)Application.Current.Resources["AllButtonStyle"];
        }

        public bool GenerateAddQuery(MySqlCommand cmd)
        {
            bool success = true;
            cmd.Parameters.Add(new MySqlParameter("statement_type", "insert"));

            if (!pProjectIdTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_project_id", pProjectIdTextBox.Text));
            }
            else
            {
                success = false;
            }
            if (!pOrgIdTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_org_id", pOrgIdTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_org_id", null));
            }
            if (!pTitleTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_title", pTitleTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_title", null));
            }
            if (!pParticipantsTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_total_participants", pParticipantsTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_total_participants", null));
            }
            if (!pAboutTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_about", pAboutTextBox.Text));
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

            if (pProjectIdTextBox.Text.Equals(data[0]))
            {
                cmd.Parameters.Add(new MySqlParameter("statement_type", "update"));
                cmd.Parameters.Add(new MySqlParameter("new_project_id", pProjectIdTextBox.Text));

                if (!pOrgIdTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_org_id", pOrgIdTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_org_id", null));
                }
                if (!pTitleTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_title", pTitleTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_title", null));
                }
                if (!pParticipantsTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_total_participants", pParticipantsTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_total_participants", null));
                }
                if (!pAboutTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_about", pAboutTextBox.Text));
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
