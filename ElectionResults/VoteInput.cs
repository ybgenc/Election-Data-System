using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ElectionResults
{
    public partial class VoteInput : Form
    {
        public VoteInput()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=YUSUF;Initial Catalog=SELECTION_DB;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand comm = new SqlCommand("insert into TABLE_SELECTION (DISTRICT_NAME,AIR_PARTY,WATER_PARTY,FIRE_PARTY,EARTH_PARTY,WOOD_PARTY) values" +
                "(@p1,@p2,@p3,@p4,@p5,@p6)", conn);
            comm.Parameters.AddWithValue("@p1", DıstrıctInput.Text);
            comm.Parameters.AddWithValue("@p2", AirPartyInput.Text);
            comm.Parameters.AddWithValue("@p3", WaterPartyInput.Text);
            comm.Parameters.AddWithValue("@p4", FirePartyInput.Text);
            comm.Parameters.AddWithValue("@p5", WoodPartyInput.Text);
            comm.Parameters.AddWithValue("@p6", EarthPartyInput.Text);
            comm.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Votes have been successfully saved");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void GraphsButton_Click(object sender, EventArgs e)
        {
            Graphs frm = new Graphs();
            frm.Show();
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}