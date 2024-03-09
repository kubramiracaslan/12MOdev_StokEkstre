using System.Data;
using System.Data.SqlClient;

namespace Odev
{
    public partial class MainForm : Form
    {

        private const string CONNECTION_STRING = @"Server=(local)\SQLEXPRESS;Database=Test;Trusted_Connection=True;";
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                var command = new SqlCommand("SELECT MalKodu, MalAdi FROM STK", connection);
                var dataTable = new DataTable();
                var dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataTable);
                comboMalAd.DataSource = dataTable;
                comboMalAd.DisplayMember = "MalAdi";
                comboMalAd.ValueMember = "MalKodu";
                connection.Close();
            }
        }
    }
}
