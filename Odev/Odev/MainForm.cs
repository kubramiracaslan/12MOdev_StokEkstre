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

        private void btnStokEkstreGetir_Click(object sender, EventArgs e)
        {
            var baslangicTarih = Convert.ToInt32(dtpBaslangic.Value.ToOADate());
            var bitisTarih = Convert.ToInt32(dtpBitis.Value.ToOADate());
            var malKod = comboMalAd.SelectedValue.ToString();

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "StokEkstreGetir";
                command.CommandType = CommandType.StoredProcedure;

                var malKodParameter = new SqlParameter();
                malKodParameter.ParameterName = "@MalKodu";
                malKodParameter.SqlDbType = SqlDbType.NVarChar;
                malKodParameter.Value = malKod;
                command.Parameters.Add(malKodParameter);

                var baslangicTarihParameter = new SqlParameter();
                baslangicTarihParameter.ParameterName = "@BaslangicTarih";
                baslangicTarihParameter.SqlDbType = SqlDbType.Int;
                baslangicTarihParameter.Value = baslangicTarih;
                command.Parameters.Add(baslangicTarihParameter);

                var bitisTarihParameter = new SqlParameter();
                bitisTarihParameter.ParameterName = "@BitisTarih";
                bitisTarihParameter.SqlDbType = SqlDbType.Int;
                bitisTarihParameter.Value = bitisTarih;
                command.Parameters.Add(bitisTarihParameter);

                connection.Open();
                var dataTable = new DataTable();
                var dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataTable);
                grid.DataSource = dataTable;
                connection.Close();
            }
        }
    }
}
