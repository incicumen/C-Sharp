using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HastKayit
{
    public partial class Form1 : Form
    {

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-5BO4AIJ;Initial Catalog=HastaKayit;Integrated Security=True");
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sehirekle();
        }

        public void HastaKayitEkle()
        {


            baglanti.Open();
            string kayit = "insert into Htablo (TId,HId,HAd,HSoyad,HDogumTarih,HTel,HAdres,HEmail,HSehir,HIlce) values (@pt,@pıd,@pad,@psyad,@pdt,@ptel,@padr,@pe,@ps,@pıl)";
            SqlCommand ekle = new SqlCommand(kayit, baglanti);
            ekle.Parameters.AddWithValue("@pt", textBox3.Text);
            ekle.Parameters.AddWithValue("@pıd", textBox4.Text);
            ekle.Parameters.AddWithValue("@pad", textBox1.Text);
            ekle.Parameters.AddWithValue("@psyad", textBox6.Text);
            ekle.Parameters.AddWithValue("@pdt", dateTimePicker1.Value);
            ekle.Parameters.AddWithValue("@ptel", textBox5.Text);
            ekle.Parameters.AddWithValue("@padr", textBox7.Text);
            ekle.Parameters.AddWithValue("@pe", textBox2.Text);
            ekle.Parameters.AddWithValue("@ps", comboBox1.Text);
            ekle.Parameters.AddWithValue("@pıl", comboBox2.Text);



            ekle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İşleminiz başarıyla kaydedildi.");

        }

        public void dataGridDoldur()
        {
            FormcTemizle();
            SqlDataAdapter adapter;
            DataTable tablo;


            adapter = new SqlDataAdapter("select * from Htablo ", baglanti);
            tablo = new DataTable();
            baglanti.Open();
            adapter.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();


        }

        public void FormcTemizle()
        {
            textBox1.Clear();
            textBox6.Clear();
            textBox5.Clear();
            textBox4.Clear();
            textBox3.Clear();
            textBox2.Clear();
            textBox7.Clear();
            dateTimePicker1.Value = DateTime.Now;




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            HastaKayitEkle();
            dataGridDoldur();
        }

        public void sehirekle()
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("select * from ILLER ", baglanti);
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr[1]);
            }
            baglanti.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox1.Text = " ";


            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from ILCELER where sehirid=@p1 ", baglanti);
            komut.Parameters.AddWithValue("@p1", comboBox1.SelectedIndex + 1);


            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[1]);
            }
            baglanti.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridDoldur();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          

        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string kayit = "delete Htablo where TId = @ptıd";
            SqlCommand sil = new SqlCommand(kayit, baglanti);
            sil.Parameters.AddWithValue("@ptıd", textBox3.Text);


            sil.ExecuteNonQuery();
            baglanti.Close();
            dataGridDoldur();
            MessageBox.Show("İşleminiz başarıyla silindi.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            baglanti.Open();
            string kayit = "Update Htablo SET HId = @pıd, HAd = @pad, HSoyad = @psyad, HDogumTarih = @pdt, HTel = @ptel, HAdres = @padr, HEmail = @pe, HSehir = @ps, HIlce = @pı  where TId = @ptıd";
            SqlCommand guncelle = new SqlCommand(kayit, baglanti);
            guncelle.Parameters.AddWithValue("@ptıd", textBox3.Text);
            guncelle.Parameters.AddWithValue("@pıd", textBox4.Text);
            guncelle.Parameters.AddWithValue("@pad", textBox1.Text);
            guncelle.Parameters.AddWithValue("@psyad", textBox6.Text);
            guncelle.Parameters.AddWithValue("@pdt", dateTimePicker1.Value);
            guncelle.Parameters.AddWithValue("@ptel", textBox5.Text);
            guncelle.Parameters.AddWithValue("@padr", textBox7.Text);
            guncelle.Parameters.AddWithValue("@pe", textBox2.Text);
            guncelle.Parameters.AddWithValue("@ps", comboBox1.Text);
            guncelle.Parameters.AddWithValue("@pı", comboBox2.Text);

            guncelle.ExecuteNonQuery();
            baglanti.Close();

            dataGridDoldur();
            MessageBox.Show("İşleminiz başarıyla güncellendi.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Select TId,HId,HAd,HSoyad,HDogumTarih,HTel,HAdres,HEmail,HSehir,HIlce from Htablo where TId = @reg_ID", baglanti);
            cmd.Parameters.AddWithValue("@reg_ID", textBox7.Text);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                textBox1.Text = rdr.GetValue(2).ToString();
                textBox6.Text = rdr.GetValue(3).ToString();
                textBox5.Text = rdr.GetValue(5).ToString();
                textBox4.Text = rdr.GetValue(1).ToString();
                textBox3.Text = rdr.GetValue(7).ToString();
                textBox2.Text = rdr.GetValue(6).ToString();
                dateTimePicker1.Text = rdr.GetValue(4).ToString();
                comboBox1.Text = rdr.GetValue(8).ToString();
                comboBox2.Text = rdr.GetValue(9).ToString();
                textBox7.Text = rdr.GetValue(0).ToString();

            }

            baglanti.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void comboBox1_SelectedValueChanged_1(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox1.Text = " ";


            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from ILCELER where sehirid=@p1 ", baglanti);
            komut.Parameters.AddWithValue("@p1", comboBox1.SelectedIndex + 1);


            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[1]);
            }
            baglanti.Close();

        }
    }
}
