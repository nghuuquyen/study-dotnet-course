using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Order_Application
{
    public partial class Form1 : Form
    {
        private DataTable table = new DataTable();

        public Form1()
        {
            InitializeComponent();
            InitialFoodTable();
            InitialTableCombox();
        }

        private void InitialTableCombox()
        {
            String[] tables = { "Table 1", "Table 2", "Table 3", "Table 4", "Table 5" };
            tableComboBox.Items.AddRange(tables);
        }

        private void InitialFoodTable()
        {
            table.Columns.Add("FoodName");
            table.Columns.Add(new DataColumn("Quantity", typeof(int)));
            foodDataGrid.DataSource = table;
        }

        private void OnSelectedFood(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null)
                return;

            String SelectedFoodName = btn.Text;
            bool isExitsFood = false;

            // Checking whether food name is already exits on table.
            foreach (DataRow row in table.Rows)
            {
                if (row["FoodName"].ToString() == SelectedFoodName)
                {
                    isExitsFood = true;
                    row["Quantity"] = (int)row["Quantity"] + 1;
                }
            }

            if (!isExitsFood)
            {
                DataRow r = table.NewRow();
                r["FoodName"] = btn.Text;
                r["Quantity"] = 1;

                table.Rows.Add(r);
            }
        }

        private String getTableOrderMessage(DataTable table)
        {
            String result = "";
            result += "MÃ BÀN : " + tableComboBox.Text + "\n\n";

            foreach (DataRow row in table.Rows)
            {
                result += row["FoodName"].ToString()
                       + "\nSố lượng: " + row["Quantity"].ToString()
                       + "\n--------"
                       + "\n";
            }
            return result;
        }

        private bool isValidOrderForm()
        {
            // Verify table code.
            if (tableComboBox.Text == "")
            {
                MessageBox.Show("Please select table from combo box." ,"Message");
                return false;
            }

            // verify food numbers.
            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Please select at least one food.", "Message");
                return false;
            }
            return true;
        }

        private void OnSubmitOrder(object sender, EventArgs e)
        {
            if (isValidOrderForm())
                MessageBox.Show(getTableOrderMessage(table), "Order Information Detail");

        }


        private void CleanOrderForm(object sender, EventArgs e)
        {
            table.Clear();
            tableComboBox.Text = "";
        }
    }
}
