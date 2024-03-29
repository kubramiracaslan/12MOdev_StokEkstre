using System.Data;
using System.Data.SqlClient;

namespace Odev
{
    public partial class MainForm : Form
    {
        // Bağlantı dizesinin tanımlanması
        private const string CONNECTION_STRING = @"Server=(local)\SQLEXPRESS;Database=Test;Trusted_Connection=True;";
        public MainForm()
        {
            InitializeComponent();
        }
        // Form yüklenirken çalışacak olan metod    
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Bağlantı oluşturulması
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                // STK tablosundan MalKodu ve MalAdi alanları alınması
                var command = new SqlCommand("SELECT MalKodu, MalAdi FROM STK", connection);
                // Veri tablosu ve veri adaptörünün oluşturulması
                var dataTable = new DataTable();
                var dataAdapter = new SqlDataAdapter();
                // Komut belirlenmesi ve veri adaptörüne atanması
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataTable);
                // Veri tablosunun veri kaynağı olarak belirlenmesi
                comboMalAd.DataSource = dataTable;
                // Gösterilecek değerin MalAdi olarak belirlenmesi
                comboMalAd.DisplayMember = "MalAdi";
                // Arka planda saklanacak değerin MalKodu olarak belirlenmesi
                comboMalAd.ValueMember = "MalKodu";
                // Bağlantı kapatılması
                connection.Close();
            }
        }
        // Stok ekstresi getir butonuna tıklandığında çalışacak olan metod
        private void btnStokEkstreGetir_Click(object sender, EventArgs e)
        {
            // Seçilen tarihlerin alınıp int'e çevrilmesi ve mal kodunun alınıp string'e çevrilmesi
            var baslangicTarih = Convert.ToInt32(dtpBaslangic.Value.ToOADate());
            var bitisTarih = Convert.ToInt32(dtpBitis.Value.ToOADate());
            var malKod = comboMalAd.SelectedValue.ToString();

            // Bağlantı oluşturulması
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                // Komut oluşturuluyor.
                var command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "StokEkstreGetir";
                command.CommandType = CommandType.StoredProcedure;

                // Parametrelerin oluşturulması ve değerlerin atanması
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

                // Bağlantı açılması
                connection.Open();
                // Veri tablosunun ve veri adaptörünün oluşturulması
                var dataTable = new DataTable();
                var dataAdapter = new SqlDataAdapter();
                // Komut belirlenmesi ve data adaptörüne atanması
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataTable);
                // Veri tablosu grid'e veri kaynağı olarak belirlenmesi
                grid.DataSource = dataTable;
                // Bağlantı kapatılması
                connection.Close();
            }
        }
    }
}
