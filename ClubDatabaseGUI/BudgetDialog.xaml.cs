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
    public sealed partial class BudgetDialog : ContentDialog
    {
        List<String> data;

        public BudgetDialog()
        {
            this.InitializeComponent();
            FixButtonStyle();
        }

        public BudgetDialog(List<String> data)
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

        private void PopulateTextBoxes()
        {
            bOrgIdTextBox.Text = data[0];
            bFeeTextBox.Text = data[1];
            bIncomeTextBox.Text = data[2];
            bExpensesTextBox.Text = data[3];
        }

        public bool GenerateAddQuery(MySqlCommand cmd)
        {
            bool success = true;
            cmd.Parameters.Add(new MySqlParameter("statement_type", "insert"));

            if (!bOrgIdTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_org_id", bOrgIdTextBox.Text));
            }
            else
            {
                success = false;
            }
            if (!bFeeTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_fee_amount", bFeeTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_fee_amount", null));
            }
            if (!bIncomeTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_income", bIncomeTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_income", null));
            }
            if (!bExpensesTextBox.Text.Equals(""))
            {
                cmd.Parameters.Add(new MySqlParameter("new_expenses", bExpensesTextBox.Text));
            }
            else
            {
                cmd.Parameters.Add(new MySqlParameter("new_expenses", null));
            }

            return success;
        }

        public String GenerateAddQuery()
        {
            String query = "Insert into BUDGET values (";
            List<String> list = new List<String>();

            if (!bOrgIdTextBox.Text.Equals(""))
            {
                list.Add(bOrgIdTextBox.Text);
            }
            else
            {
                return null;
            }
            if (!bFeeTextBox.Text.Equals(""))
            {
                list.Add(bFeeTextBox.Text);
            }
            else
            {
                list.Add("null");
            }
            if (!bIncomeTextBox.Text.Equals(""))
            {
                list.Add(bIncomeTextBox.Text);
            }
            else
            {
                list.Add("null");
            }
            if (!bExpensesTextBox.Text.Equals(""))
            {
                list.Add(bExpensesTextBox.Text);
            }
            else
            {
                list.Add("null");
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (i == 0)
                {
                    query += list[i];
                }
                else if (i != list.Count - 1)
                {
                    query += ("," + list[i]);
                }
                else
                {
                    query += ("," + list[i] + ");");
                }
            }

            return query;
        }

        public bool GenerateModifyQuery(MySqlCommand cmd)
        {
            bool success = true;
            if (bOrgIdTextBox.Text.Equals(data[0]))
            {
                cmd.Parameters.Add(new MySqlParameter("statement_type", "update"));
                cmd.Parameters.Add(new MySqlParameter("new_org_id", bOrgIdTextBox.Text));

                if (!bFeeTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_fee_amount", bFeeTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_fee_amount", null));
                }
                if (!bIncomeTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_income", bIncomeTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_income", null));
                }
                if (!bExpensesTextBox.Text.Equals(""))
                {
                    cmd.Parameters.Add(new MySqlParameter("new_expenses", bExpensesTextBox.Text));
                }
                else
                {
                    cmd.Parameters.Add(new MySqlParameter("new_expenses", null));
                }
            }
            else
            {
                success = false;
            }
            return success;
        }

        public String GenerateModifyQuery()
        {
            if (bOrgIdTextBox.Text.Equals(data[0]))
            {
                String query = "update BUDGET set ";
                List<String> list = new List<String>();

                if (!bFeeTextBox.Text.Equals(""))
                {
                    list.Add("fee_amount = " + bFeeTextBox.Text);
                }
                else
                {
                    list.Add("fee_amount = null");
                }
                if (!bIncomeTextBox.Text.Equals(""))
                {
                    list.Add("income = " + bIncomeTextBox.Text);
                }
                else
                {
                    list.Add("income = null");
                }
                if (!bExpensesTextBox.Text.Equals(""))
                {
                    list.Add("expenses = " + bExpensesTextBox.Text);
                }
                else
                {
                    list.Add("expenses = null");
                }

                for (int i = 0; i < list.Count; i++)
                {
                    if (i < list.Count - 1)
                    {
                        query += (list[i] + ", ");
                    }
                    else
                    {
                        query += list[i];
                    }
                }

                query += (" where org_id = " + bOrgIdTextBox.Text + ";");
                return query;
            }
            else
            {
                return null;
            }
        }
    }
}
