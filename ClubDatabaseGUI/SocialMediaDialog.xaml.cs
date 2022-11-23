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
    public sealed partial class SocialMediaDialog : ContentDialog
    {
        List<String> data;

        public SocialMediaDialog()
        {
            this.InitializeComponent();
            FixButtonStyle();
        }

        public SocialMediaDialog(List<String> data)
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
            smOrgIdTextBox.Text = data[0];
            smUrlTextBox.Text = data[1];
            smUsernameTextBox.Text = data[2];
            smPostNumTextBox.Text = data[3];
            smViewNumTextBox.Text = data[4];
        }

        public bool GenerateAddQuery(MySqlCommand cmd)
        {
            bool success = true;
            cmd.Parameters.Add(new MySqlParameter("statement_type", "insert"));

            if (!smOrgIdTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_org_id", smOrgIdTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_org_id", null));
            }
            if (!smUrlTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_url", smUrlTextBox.Text));
            }
            else
            {
                success = false;
            }
            if (!smUsernameTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_username", smUsernameTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_username", null));
            }
            if (!smPostNumTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_num_of_posts", smPostNumTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_num_of_posts", null));
            }
            if (!smViewNumTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_num_of_views", smViewNumTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_num_of_views", null));
            }
            return success;
        }

        public bool GenerateModifyQuery(MySqlCommand cmd)
        {
            bool success = true;
            if (smUrlTextBox.Text.Equals(data[1]))
            {
                cmd.Parameters.Add(new MySqlParameter("statement_type", "update"));
                cmd.Parameters.Add(new MySqlParameter("new_url", smUrlTextBox.Text));

                if (!smOrgIdTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_org_id", smOrgIdTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_org_id", null));
                }
                if (!smUsernameTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_username", smUsernameTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_username", null));
                }
                if (!smPostNumTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_num_of_posts", smPostNumTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_num_of_posts", null));
                }
                if (!smViewNumTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_num_of_views", smViewNumTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_num_of_views", null));
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
