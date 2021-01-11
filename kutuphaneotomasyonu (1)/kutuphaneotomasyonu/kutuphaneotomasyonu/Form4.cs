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


namespace kutuphaneotomasyonu
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-FDG2M56\\SQLEXPRESS;Initial Catalog=kütüphane;Integrated Security=True");
        public void verilerimigoster()
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        
      
        public void verilerigoster()
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("select * from misafir", baglantı);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);//sanal tabloyu getirir.
            dataGridView1.DataSource = ds.Tables[0];
            baglantı.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
             
                    baglantı.Open();
                //bağlantıyı kontrol ediyoruz açık değilse açıyor kendilerii
                string kayit = "insert into misafir(isim,tc,telno,sifre) values (@isim,@tc,@telno,@sifre)";
                // misafir tablomuzun ilgili alanlarına kayıt ekleme işlemini gerçekleştirecek sorgumuz.
                SqlCommand komut = new SqlCommand(kayit, baglantı);
                //sorguyu ve bağlantıyı parametre olarak sql nesnesi oluşturduk.
                komut.Parameters.AddWithValue("@isim", textBox1.Text);
                komut.Parameters.AddWithValue("@tc", textBox2.Text);
                komut.Parameters.AddWithValue("@telno", textBox3.Text);
                komut.Parameters.AddWithValue("@sifre", textBox4.Text);
                komut.ExecuteNonQuery();
                //Veritabanında değişiklik yapacak komut işlemi bu satırda gerçekleşiyor.
                baglantı.Close();
                MessageBox.Show("Misafir girişi başarıyla kaydedildi.");

            }
            catch(Exception hata)
            {
                MessageBox.Show("İşlem sırasında hata oluştu"+ hata.Message);

            }
            finally 
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();

                baglantı.Close();
                verilerigoster();
            }

    
               

        }
    }
}
