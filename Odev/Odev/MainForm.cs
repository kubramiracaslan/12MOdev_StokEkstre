using System.Data;
using System.Data.SqlClient;

namespace Odev
{
    public partial class MainForm : Form
    {
        // Baðlantý dizesi tanýmlanmasý
        private const string CONNECTION_STRING = @"Server=(local)\SQLEXPRESS;Database=Test;Trusted_Connection=True;";
        public MainForm()
        {
            InitializeComponent();
        }
        // Form yüklenirken çalýþacak olan metod    
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Baðlantý oluþturulmasý
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                // STK tablosundan MalKodu ve MalAdi alanlarý alýnmasý
                var command = new SqlCommand("SELECT MalKodu, MalAdi FROM STK", connection);
                // Veri tablosu ve veri adaptörünün oluþturulmasý
                var dataTable = new DataTable();
                var dataAdapter = new SqlDataAdapter();
                // Komut belirlenmesi ve veri adaptörüne atanmasý
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataTable);
                // Veri tablosunun veri kaynaðý olarak belirlenmesi
                comboMalAd.DataSource = dataTable;
                // Gösterilecek deðerin MalAdi olarak belirlenmesi
                comboMalAd.DisplayMember = "MalAdi";
                // Arka planda saklanacak deðerin MalKodu olarak belirlenmesi
                comboMalAd.ValueMember = "MalKodu";
                // Baðlantý kapatýlmasý
                connection.Close();
            }
        }
        // Stok ekstresi getir butonuna týklandýðýnda çalýþacak olan metod
        private void btnStokEkstreGetir_Click(object sender, EventArgs e)
        {
            // Seçilen tarihlerin alýnýp int'e çevrilmesi ve mal kodunun alýnýp string'e çevrilmesi
            var baslangicTarih = Convert.ToInt32(dtpBaslangic.Value.ToOADate());
            var bitisTarih = Convert.ToInt32(dtpBitis.Value.ToOADate());
            var malKod = comboMalAd.SelectedValue.ToString();

            // Baðlantý oluþturulmasý
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                // Komut oluþturuluyor.
                var command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "StokEkstreGetir";
                command.CommandType = CommandType.StoredProcedure;

                // Parametrelerin oluþturulmasý ve deðerlerin atanmasý
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

                // Baðlantý açýlmasý
                connection.Open();
                // Veri tablosunun ve veri adaptörünün oluþturulmasý
                var dataTable = new DataTable();
                var dataAdapter = new SqlDataAdapter();
                // Komut belirlenmesi ve data adaptörüne atanmasý
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataTable);
                // Veri tablosu grid'e veri kaynaðý olarak belirlenmesi
                grid.DataSource = dataTable;
                // Baðlantý kapatýlmasý
                connection.Close();
            }
        }
    }
}
