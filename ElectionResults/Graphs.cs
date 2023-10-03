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
    public partial class Graphs : Form
    {
        public Graphs()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=YUSUF;Initial Catalog=SELECTION_DB;Integrated Security=True");

        private void Graphs_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command = new SqlCommand("Select DISTRICT_NAME from TABLE_SELECTION",conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) 
            {
                districtCB.Items.Add(reader.GetString(0));
            }
            conn.Close();

            conn.Open ();
            SqlCommand command2 = new SqlCommand("Select SUM(AIR_PARTY),SUM(WATER_PARTY),SUM(FIRE_PARTY),SUM(EARTH_PARTY),SUM(WOOD_PARTY) " +
                "FROM TABLE_SELECTION",conn);
            SqlDataReader reader2 = command2.ExecuteReader();
            while(reader2.Read())
            {
                chart1.Series["Partys"].Points.AddXY("AIR_PARTY", reader2[0]);
                chart1.Series["Partys"].Points.AddXY("WATER_PARTY", reader2[1]);
                chart1.Series["Partys"].Points.AddXY("FIRE_PARTY", reader2[2]);
                chart1.Series["Partys"].Points.AddXY("EARTH_PARTY", reader2[3]);
                chart1.Series["Partys"].Points.AddXY("WOOD_PARTY", reader2[4]);
            }
            conn.Close ();

        }

        private void districtCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand command3 = new SqlCommand("Select * from TABLE_SELECTION where DISTRICT_NAME=@p1",conn);
            command3.Parameters.AddWithValue("@p1", districtCB.Text);
            SqlDataReader reader2 = command3.ExecuteReader();  
            while (reader2.Read())
            {
                progressBarAır.Value = int.Parse(reader2[2].ToString());
                progressBarWater.Value = int.Parse(reader2[3].ToString());
                progressBarFire.Value = int.Parse(reader2[4].ToString());
                progressBarEarth.Value = int.Parse(reader2[5].ToString());
                progressBarWood.Value = int.Parse(reader2[6].ToString());

                AirVotes.Text = reader2[2].ToString();
                WaterVotes.Text = reader2[3].ToString();
                FireVotes.Text = reader2[4].ToString();
                EarthVotes.Text = reader2[5].ToString();
                WoodVotes.Text = reader2[6].ToString();
            }
            conn.Close();
        }

        private void progressBarWood_Click(object sender, EventArgs e)
        {

        }
    }
}
