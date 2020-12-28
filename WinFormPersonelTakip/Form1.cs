using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormPersonelTakip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        string connectionString = "Data Source = DESKTOP-VM4R1FF\\SQLEXPRESS; Initial Catalog = PersonelDb; Integrated Security = SSPI;";

        private void Form1_Load(object sender, EventArgs e)
        {
            birimLoad();
        }
        void birimLoad()
        {
            try
            {
                con = new SqlConnection(connectionString);
                cmd = new SqlCommand("Select * From birimler", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach(DataRow row in dt.Rows)
                {
                    cbbBirim.Items.Add(row["birim"].ToString());
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }
    }
}
