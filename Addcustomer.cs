using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_Management_System
{
    public partial class Addcustomer : Form
    {
        string path = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\project\\Database\\RestaurantDB.accdb";
        public Addcustomer()
        {
            InitializeComponent();
        }

        private void btsave_Click(object sender, EventArgs e)
        {
            try
            {

                using (OleDbConnection con = new OleDbConnection(path))
                {
                    con.Open();
                    using (OleDbCommand cmd = new OleDbCommand("INSERT INTO CustomTb ([CutomerName], [Address], [Dob], [Phoneno], [EmailID], [Gender]) VALUES (@CustomeName, @Address, @Dob, @Phoneno, @EmailID, @Gender)", con))
                    {
                        cmd.Parameters.AddWithValue("@CustomeName", txtCustomnm.Text);
                        cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                        cmd.Parameters.AddWithValue("@Dob", dobpicker.Text);
                        cmd.Parameters.AddWithValue("@Phoneno", txtphoneno.Text);
                        cmd.Parameters.AddWithValue("@EmailID", txtemailid.Text);
                        cmd.Parameters.AddWithValue("@Gender", txtgender.Text);
                       

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data Inserted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Something Went Wrong! Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
