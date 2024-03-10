using System.Data;
using System.Data.SqlClient;

namespace Odev
{
    public partial class MainForm : Form
    {
        // Ba�lant� dizesi tan�mlanmas�
        private const string CONNECTION_STRING = @"Server=(local)\SQLEXPRESS;Database=Test;Trusted_Connection=True;";
        public MainForm()
        {
            InitializeComponent();
        }
        // Form y�klenirken �al��acak olan metod    
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Ba�lant� olu�turulmas�
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                // STK tablosundan MalKodu ve MalAdi alanlar� al�nmas�
                var command = new SqlCommand("SELECT MalKodu, MalAdi FROM STK", connection);
                // Veri tablosu ve veri adapt�r�n�n olu�turulmas�
                var dataTable = new DataTable();
                var dataAdapter = new SqlDataAdapter();
                // Komut belirlenmesi ve veri adapt�r�ne atanmas�
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataTable);
                // Veri tablosunun veri kayna�� olarak belirlenmesi
                comboMalAd.DataSource = dataTable;
                // G�sterilecek de�erin MalAdi olarak belirlenmesi
                comboMalAd.DisplayMember = "MalAdi";
                // Arka planda saklanacak de�erin MalKodu olarak belirlenmesi
                comboMalAd.ValueMember = "MalKodu";
                // Ba�lant� kapat�lmas�
                connection.Close();
            }
        }
        // Stok ekstresi getir butonuna t�kland���nda �al��acak olan metod
        private void btnStokEkstreGetir_Click(object sender, EventArgs e)
        {
            // Se�ilen tarihlerin al�n�p int'e �evrilmesi ve mal kodunun al�n�p string'e �evrilmesi
            var baslangicTarih = Convert.ToInt32(dtpBaslangic.Value.ToOADate());
            var bitisTarih = Convert.ToInt32(dtpBitis.Value.ToOADate());
            var malKod = comboMalAd.SelectedValue.ToString();

            // Ba�lant� olu�turulmas�
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                // Komut olu�turuluyor.
                var command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "StokEkstreGetir";
                command.CommandType = CommandType.StoredProcedure;

                // Parametrelerin olu�turulmas� ve de�erlerin atanmas�
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

                // Ba�lant� a��lmas�
                connection.Open();
                // Veri tablosunun ve veri adapt�r�n�n olu�turulmas�
                var dataTable = new DataTable();
                var dataAdapter = new SqlDataAdapter();
                // Komut belirlenmesi ve data adapt�r�ne atanmas�
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataTable);
                // Veri tablosu grid'e veri kayna�� olarak belirlenmesi
                grid.DataSource = dataTable;
                // Ba�lant� kapat�lmas�
                connection.Close();
            }
        }
    }
}
