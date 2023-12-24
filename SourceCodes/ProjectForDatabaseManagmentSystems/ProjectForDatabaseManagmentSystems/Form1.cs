using Npgsql;
using NpgsqlTypes;
using System.Data;

namespace ProjectForDatabaseManagmentSystems
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NpgsqlConnection connection_Sql = new NpgsqlConnection("server = localHost; port = 5432; Database = proje; user ID = postgres; password = iskender2000");

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(connection_Sql.State == ConnectionState.Open))
            {
                connection_Sql.Open();
            }
            try
            {
                string find = "select * from " + "\"" + textBox1.Text + "\"";
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(find, connection_Sql);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];
            }
            catch (NpgsqlException wrong)
            {
                if (wrong.SqlState == "42P01")
                {
                    MessageBox.Show("Does Not Exist This Table", "Wrong Table Name", MessageBoxButtons.OK);
                }
            }
            if (connection_Sql.State == ConnectionState.Open)
            {
                connection_Sql.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!(connection_Sql.State == ConnectionState.Open))
            {
                connection_Sql.Open();
            }
            string find = "select column_name from information_schema.columns " +
                "where table_schema = 'public' and table_name = " + "'" + comboBox1.SelectedItem.ToString() + "'";
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(find, connection_Sql);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            DataTable dataTable = dataSet.Tables[0];
            comboBox2.Items.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                comboBox2.Items.AddRange(new string[] { row[0].ToString() });
            }
            if (connection_Sql.State == ConnectionState.Open)
            {
                connection_Sql.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!(connection_Sql.State == ConnectionState.Open))
            {
                connection_Sql.Open();
            }
            try
            {
                string find = "";
                find = "select * from " + "\"" + comboBox1.SelectedItem.ToString() + "\"" +
                    " where cast (" + "\"" + comboBox2.SelectedItem.ToString() + "\"" + " as text) like " + "'%" + textBox2.Text + "%'";
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(find, connection_Sql);
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];
            }
            catch (NpgsqlException Wrong)
            {
                if (Wrong.SqlState == "42703")
                {
                    MessageBox.Show("Does Not Exist This Columns In This Table", "Wrong Process", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (connection_Sql.State == ConnectionState.Open)
            {
                connection_Sql.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!(connection_Sql.State == ConnectionState.Open))
            {
                connection_Sql.Open();
            }
            string find = "select column_name from information_schema.columns " +
                "where table_schema = 'public' and table_name = " + "'" + comboBox3.SelectedItem.ToString() + "'";
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(find, connection_Sql);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            DataTable dataTable = dataSet.Tables[0];
            int indexForCounter = 0, counter = 0, index = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                indexForCounter++;
            }
            string[] strings = new string[indexForCounter];
            foreach (DataRow row in dataTable.Rows)
            {
                strings[index] = row[0].ToString();
                index++;
            }
            textBox3.PlaceholderText = ""; textBox4.PlaceholderText = ""; textBox5.PlaceholderText = "";
            textBox6.PlaceholderText = ""; textBox7.PlaceholderText = ""; textBox8.PlaceholderText = "";
            textBox9.PlaceholderText = "";
            if (indexForCounter > counter)
            {
                textBox3.PlaceholderText = strings[0];
                counter++;
            }
            if (indexForCounter > counter)
            {
                textBox4.PlaceholderText = strings[1];
                counter++;
            }
            if (indexForCounter > counter)
            {
                textBox5.PlaceholderText = strings[2];
                counter++;
            }
            if (indexForCounter > counter)
            {
                textBox6.PlaceholderText = strings[3];
                counter++;
            }
            if (indexForCounter > counter)
            {
                textBox7.PlaceholderText = strings[4];
                counter++;
            }
            if (indexForCounter > counter)
            {
                textBox8.PlaceholderText = strings[5];
                counter++;
            }
            if (indexForCounter > counter)
            {
                textBox9.PlaceholderText = strings[6];
                counter++;
            }
            if (connection_Sql.State == ConnectionState.Open)
            {
                connection_Sql.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!(connection_Sql.State == ConnectionState.Open))
            {
                connection_Sql.Open();
            }
            if (comboBox3.SelectedItem.ToString() == "Arac")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("insert into \"Arac\" (\"aracId\", \"aracMarka\", \"aracModel\", \"aracDurum\", \"tedarikciId\", \"aracYil\" )" +
                    "values (@p1,@p2,@p3,@p4,@p5,@p6)", connection_Sql);
                if (!(textBox3.Text == "" || textBox3.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox3.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox4.Text == "" || textBox4.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", textBox4.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                if (!(textBox5.Text == "" || textBox5.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", textBox5.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", DBNull.Value);
                }
                if (!(textBox6.Text == "" || textBox6.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", textBox6.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", DBNull.Value);
                }
                if (!(textBox7.Text == "" || textBox7.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p5", int.Parse(textBox7.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p5", DBNull.Value);
                }
                if (!(textBox8.Text == "" || textBox8.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p6", textBox8.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p6", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox3.SelectedItem.ToString() == "Calisan")
            {
                if (!(textBox8.Text == "" || textBox8.Text == null) && (textBox8.Text == "kp" || textBox8.Text == "mp" || textBox8.Text == "y"))
                {
                    NpgsqlCommand npgsqlCommand = new NpgsqlCommand("insert into \"Calisan\" (\"calisanId\", \"calisanIsim\", \"calisanSoyisim\", \"calisanTc\", \"calisanMaas\", \"calisanTipi\", \"calisanAdres\")" +
                        "values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", connection_Sql);
                    if (!(textBox3.Text == "" || textBox3.Text == null))
                    {
                        npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox3.Text));
                    }
                    else
                    {
                        npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                    }
                    if (!(textBox4.Text == "" || textBox4.Text == null))
                    {
                        npgsqlCommand.Parameters.AddWithValue("@p2", textBox4.Text.ToString());
                    }
                    else
                    {
                        npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                    }
                    if (!(textBox5.Text == "" || textBox5.Text == null))
                    {
                        npgsqlCommand.Parameters.AddWithValue("@p3", textBox5.Text.ToString());
                    }
                    else
                    {
                        npgsqlCommand.Parameters.AddWithValue("@p3", DBNull.Value);
                    }
                    if (!(textBox6.Text == "" || textBox6.Text == null))
                    {
                        npgsqlCommand.Parameters.AddWithValue("@p4", textBox6.Text.ToString());
                    }
                    else
                    {
                        npgsqlCommand.Parameters.AddWithValue("@p4", DBNull.Value);
                    }
                    if (!(textBox7.Text == "" || textBox7.Text == null))
                    {
                        npgsqlCommand.Parameters.AddWithValue("@p5", int.Parse(textBox7.Text));
                    }
                    else
                    {
                        npgsqlCommand.Parameters.AddWithValue("@p5", DBNull.Value);
                    }
                    if (!(textBox8.Text == "" || textBox8.Text == null))
                    {
                        npgsqlCommand.Parameters.AddWithValue("@p6", textBox8.Text.ToString());
                    }
                    else
                    {
                        npgsqlCommand.Parameters.AddWithValue("@p6", DBNull.Value);
                    }
                    if (!(textBox9.Text == "" || textBox9.Text == null))
                    {
                        npgsqlCommand.Parameters.AddWithValue("@p7", textBox9.Text.ToString());
                    }
                    else
                    {
                        npgsqlCommand.Parameters.AddWithValue("@p7", DBNull.Value);
                    }
                    npgsqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("calisanTipi must be not-null an one of the those: ('kp', 'mp', 'y')", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            if (comboBox3.SelectedItem.ToString() == "CalisanKisiSayiBilgi")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("insert into \"CalisanKisiSayiBilgi\" (\"calisanSayiId\", \"calisanSayisi\") " +
                    "values (@p1,@p2)", connection_Sql);
                if (!(textBox3.Text == "" || textBox3.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox3.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox4.Text == "" || textBox4.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", int.Parse(textBox4.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox3.SelectedItem.ToString() == "Kanal")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("insert into \"Kanal\" (\"kanalId\", \"kanalAdi\", \"kanalNo\", \"kanalMerkezKonum\", \"kanalYoneticiIsim\")" +
                    "values (@p1,@p2,@p3,@p4,@p5)", connection_Sql);
                if (!(textBox3.Text == "" || textBox3.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox3.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox4.Text == "" || textBox4.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", textBox4.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                if (!(textBox5.Text == "" || textBox5.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", int.Parse(textBox5.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", DBNull.Value);
                }
                if (!(textBox6.Text == "" || textBox6.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", textBox6.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", DBNull.Value);
                }
                if (!(textBox7.Text == "" || textBox7.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p5", textBox7.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p5", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox3.SelectedItem.ToString() == "KanalPersonel")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("insert into \"KanalPersonel\" (\"calisanId\", \"kanalGorev\", \"kanalId\")" +
                    "values (@p1,@p2,@p3)", connection_Sql);
                if (!(textBox3.Text == "" || textBox3.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox3.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox4.Text == "" || textBox4.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", textBox4.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                if (!(textBox5.Text == "" || textBox5.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", int.Parse(textBox5.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox3.SelectedItem.ToString() == "Magaza")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("insert into \"Magaza\" (\"magazaId\", \"magazaIsim\", \"magazaVergiNo\", \"magazaKonum\", \"magazaYoneticiIsim\", \"magazaCalisanSayisi\" )" +
                    "values (@p1,@p2,@p3,@p4,@p5,@p6)", connection_Sql);
                if (!(textBox3.Text == "" || textBox3.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox3.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox4.Text == "" || textBox4.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", textBox4.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                if (!(textBox5.Text == "" || textBox5.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", textBox5.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", DBNull.Value);
                }
                if (!(textBox6.Text == "" || textBox6.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", textBox6.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", DBNull.Value);
                }
                if (!(textBox7.Text == "" || textBox7.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p5", textBox7.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p5", DBNull.Value);
                }
                if (!(textBox8.Text == "" || textBox8.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p6", int.Parse(textBox8.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p6", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox3.SelectedItem.ToString() == "MagazaAdetBilgi")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("insert into \"MagazaAdetBilgi\" (\"magazaSayisiId\", \"magazaSayisi\") " +
                    "values (@p1,@p2)", connection_Sql);
                if (!(textBox3.Text == "" || textBox3.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox3.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox4.Text == "" || textBox4.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", int.Parse(textBox4.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox3.SelectedItem.ToString() == "MagazaPersonel")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("insert into \"MagazaPersonel\" (\"calisanId\", \"sirket\", \"sirketTel\", \"magazaId\")" +
                    "values (@p1,@p2,@p3,@p4)", connection_Sql);
                if (!(textBox3.Text == "" || textBox3.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox3.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox4.Text == "" || textBox4.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", textBox4.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                if (!(textBox5.Text == "" || textBox5.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", int.Parse(textBox5.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", DBNull.Value);
                }
                if (!(textBox6.Text == "" || textBox6.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", int.Parse(textBox6.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox3.SelectedItem.ToString() == "MagazaUrun")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("insert into \"MagazaUrun\" (\"magazaUrunId\", \"urunId\", \"magazaId\", \"bilgi\")" +
                    "values (@p1,@p2,@p3,@p4)", connection_Sql);
                if (!(textBox3.Text == "" || textBox3.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox3.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox4.Text == "" || textBox4.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", int.Parse(textBox4.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                if (!(textBox5.Text == "" || textBox5.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", int.Parse(textBox5.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", DBNull.Value);
                }
                if (!(textBox6.Text == "" || textBox6.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", textBox6.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox3.SelectedItem.ToString() == "Materyel")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("insert into \"Materyel\" (\"materyelId\", \"materyelIsim\") " +
                    "values (@p1,@p2)", connection_Sql);
                if (!(textBox3.Text == "" || textBox3.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox3.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox4.Text == "" || textBox4.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", textBox4.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox3.SelectedItem.ToString() == "MateryelAdetBilgi")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("insert into \"MateryelAdetBilgi\" (\"materyelSayiId\", \"materyelSayisi\") " +
                   "values (@p1,@p2)", connection_Sql);
                if (!(textBox3.Text == "" || textBox3.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox3.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox4.Text == "" || textBox4.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", int.Parse(textBox4.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox3.SelectedItem.ToString() == "Musteri")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("insert into \"Musteri\" (\"musteriId\", \"musteriAdi\", \"musteriSoyadi\", \"musteriKonum\", \"musteriYorum\")" +
                    "values (@p1,@p2,@p3,@p4,@p5)", connection_Sql);
                if (!(textBox3.Text == "" || textBox3.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox3.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox4.Text == "" || textBox4.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", textBox4.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                if (!(textBox5.Text == "" || textBox5.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", textBox5.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", DBNull.Value);
                }
                if (!(textBox6.Text == "" || textBox6.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", textBox6.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", DBNull.Value);
                }
                if (!(textBox7.Text == "" || textBox7.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p5", textBox7.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p5", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox3.SelectedItem.ToString() == "Reklam")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("insert into \"Reklam\" (\"reklamId\", \"reklamIsim\", \"reklamSure\", \"reklamHedefKitle\", \"reklamUlkeleri\", \"reklamFirmasi\", \"urunId\")" +
                    "values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", connection_Sql);
                if (!(textBox3.Text == "" || textBox3.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox3.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox4.Text == "" || textBox4.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", textBox4.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                if (!(textBox5.Text == "" || textBox5.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", textBox5.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", DBNull.Value);
                }
                if (!(textBox6.Text == "" || textBox6.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", textBox6.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", DBNull.Value);
                }
                if (!(textBox7.Text == "" || textBox7.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p5", textBox7.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p5", DBNull.Value);
                }
                if (!(textBox8.Text == "" || textBox8.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p6", textBox8.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p6", DBNull.Value);
                }
                if (!(textBox9.Text == "" || textBox9.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p7", int.Parse(textBox9.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p7", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox3.SelectedItem.ToString() == "ReklamKanal")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("insert into \"ReklamKanal\" (\"reklamKanalId\", \"reklamId\", \"kanalId\", \"reklaminKanaldaSonTarihi\")" +
                    "values (@p1,@p2,@p3,@p4)", connection_Sql);
                if (!(textBox3.Text == "" || textBox3.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox3.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox4.Text == "" || textBox4.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", int.Parse(textBox4.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                if (!(textBox5.Text == "" || textBox5.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", int.Parse(textBox5.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", DBNull.Value);
                }
                if (!(textBox6.Text == "" || textBox6.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", DateTime.Parse(textBox6.Text.ToString()));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox3.SelectedItem.ToString() == "Siparis")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("insert into \"Siparis\" (\"siparisId\", \"siparisYorum\", \"siparisKonum\", \"musteriId\", \"magazaId\")" +
                    "values (@p1,@p2,@p3,@p4,@p5)", connection_Sql);
                if (!(textBox3.Text == "" || textBox3.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox3.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox4.Text == "" || textBox4.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", textBox4.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                if (!(textBox5.Text == "" || textBox5.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", textBox5.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", DBNull.Value);
                }
                if (!(textBox6.Text == "" || textBox6.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", int.Parse(textBox6.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", DBNull.Value);
                }
                if (!(textBox7.Text == "" || textBox7.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p5", int.Parse(textBox7.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p5", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox3.SelectedItem.ToString() == "Tedarikci")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("insert into \"Tedarikci\" (\"tedarikciId\", \"tedarikciIsim\", \"tedarikciKonum\", \"urunId\")" +
                    "values (@p1,@p2,@p3,@p4)", connection_Sql);
                if (!(textBox3.Text == "" || textBox3.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox3.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox4.Text == "" || textBox4.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", textBox4.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                if (!(textBox5.Text == "" || textBox5.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", textBox5.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", DBNull.Value);
                }
                if (!(textBox6.Text == "" || textBox6.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", int.Parse(textBox6.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox3.SelectedItem.ToString() == "Urun")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("insert into \"Urun\" (\"urunId\", \"urunAdi\", \"urunRenk\", \"materyelId\")" +
                    "values (@p1,@p2,@p3,@p4)", connection_Sql);
                if (!(textBox3.Text == "" || textBox3.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox3.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox4.Text == "" || textBox4.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", textBox4.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                if (!(textBox5.Text == "" || textBox5.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", textBox5.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", DBNull.Value);
                }
                if (!(textBox6.Text == "" || textBox6.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", int.Parse(textBox6.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox3.SelectedItem.ToString() == "UrunAdetBilgi")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("insert into \"UrunAdetBilgi\" (\"urunSayisiId\", \"urunSayisi\") " +
                   "values (@p1,@p2)", connection_Sql);
                if (!(textBox3.Text == "" || textBox3.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox3.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox4.Text == "" || textBox4.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", int.Parse(textBox4.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox3.SelectedItem.ToString() == "Yonetici")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("insert into \"Yonetici\" (\"calisanId\", \"sirket\", \"bolum\")" +
                    "values (@p1,@p2,@p3)", connection_Sql);
                if (!(textBox3.Text == "" || textBox3.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox3.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox4.Text == "" || textBox4.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", textBox4.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                if (!(textBox5.Text == "" || textBox5.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", textBox5.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (connection_Sql.State == ConnectionState.Open)
            {
                connection_Sql.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!(connection_Sql.State == ConnectionState.Open))
            {
                connection_Sql.Open();
            }
            string find = "select column_name from information_schema.columns " +
                "where table_schema = 'public' and table_name = " + "'" + comboBox4.SelectedItem.ToString() + "'";
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(find, connection_Sql);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            DataTable dataTable = dataSet.Tables[0];
            int indexForCounter = 0, counter = 0, index = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                indexForCounter++;
            }
            string[] strings = new string[indexForCounter];
            foreach (DataRow row in dataTable.Rows)
            {
                strings[index] = row[0].ToString();
                index++;
            }
            textBox10.PlaceholderText = ""; textBox11.PlaceholderText = ""; textBox12.PlaceholderText = "";
            textBox13.PlaceholderText = ""; textBox14.PlaceholderText = ""; textBox15.PlaceholderText = "";
            textBox16.PlaceholderText = "";
            if (indexForCounter > counter)
            {
                textBox10.PlaceholderText = strings[0];
                counter++;
            }
            if (indexForCounter > counter)
            {
                textBox11.PlaceholderText = strings[1];
                counter++;
            }
            if (indexForCounter > counter)
            {
                textBox12.PlaceholderText = strings[2];
                counter++;
            }
            if (indexForCounter > counter)
            {
                textBox13.PlaceholderText = strings[3];
                counter++;
            }
            if (indexForCounter > counter)
            {
                textBox14.PlaceholderText = strings[4];
                counter++;
            }
            if (indexForCounter > counter)
            {
                textBox15.PlaceholderText = strings[5];
                counter++;
            }
            if (indexForCounter > counter)
            {
                textBox16.PlaceholderText = strings[6];
                counter++;
            }
            if (connection_Sql.State == ConnectionState.Open)
            {
                connection_Sql.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!(connection_Sql.State == ConnectionState.Open))
            {
                connection_Sql.Open();
            }
            if (comboBox4.SelectedItem.ToString() == "Arac")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("update \"Arac\" set \"aracId\" = @p1, \"aracMarka\" = @p2, \"aracModel\" = @p3, \"aracDurum\" = @p4, \"tedarikciId\" = @p5, \"aracYil\" = @p6 where \"aracId\" = " + textBox17.Text, connection_Sql);
                if (!(textBox10.Text == "" || textBox10.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox10.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox11.Text == "" || textBox11.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", textBox11.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                if (!(textBox12.Text == "" || textBox12.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", textBox12.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", DBNull.Value);
                }
                if (!(textBox13.Text == "" || textBox13.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", textBox13.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", DBNull.Value);
                }
                if (!(textBox14.Text == "" || textBox14.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p5", int.Parse(textBox14.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p5", DBNull.Value);
                }
                if (!(textBox15.Text == "" || textBox15.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p6", textBox15.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p6", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox4.SelectedItem.ToString() == "Calisan")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("update \"Calisan\" set \"calisanId\" = @p1, \"calisanIsim\" = @p2, \"calisanSoyisim\" = @p3, \"calisanTc\" = @p4, \"calisanMaas\" = @p5, \"calisanTipi\" = @p6, \"calisanAdres\" = @p7 where \"calisanId\" = " + textBox17.Text, connection_Sql);
                if (!(textBox10.Text == "" || textBox10.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox10.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox11.Text == "" || textBox11.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", textBox11.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                if (!(textBox12.Text == "" || textBox12.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", textBox12.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", DBNull.Value);
                }
                if (!(textBox13.Text == "" || textBox13.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", textBox13.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", DBNull.Value);
                }
                if (!(textBox14.Text == "" || textBox14.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p5", int.Parse(textBox14.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p5", DBNull.Value);
                }
                if (!(textBox15.Text == "" || textBox15.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p6", textBox15.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p6", DBNull.Value);
                }
                if (!(textBox16.Text == "" || textBox16.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p7", textBox16.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p7", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox4.SelectedItem.ToString() == "CalisanKisiSayiBilgi")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("update \"CalisanKisiSayiBilgi\" set \"calisanSayiId\" = @p1, \"calisanSayisi\" = @p2 where \"calisanSayiId\" = " + textBox17.Text, connection_Sql);
                if (!(textBox10.Text == "" || textBox10.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox10.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox11.Text == "" || textBox11.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", int.Parse(textBox11.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox4.SelectedItem.ToString() == "Kanal")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("update \"Kanal\" set \"kanalId\" = @p1, \"kanalAdi\" = @p2, \"kanalNo\" = @p3, \"kanalMerkezKonum\" = @p4, \"kanalYoneticiIsim\" = @p5 where \"kanalId\" = " + textBox17.Text, connection_Sql);
                if (!(textBox10.Text == "" || textBox10.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox10.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox11.Text == "" || textBox11.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", textBox11.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                if (!(textBox12.Text == "" || textBox12.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", int.Parse(textBox12.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", DBNull.Value);
                }
                if (!(textBox13.Text == "" || textBox13.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", textBox13.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", DBNull.Value);
                }
                if (!(textBox14.Text == "" || textBox14.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p5", textBox14.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p5", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox4.SelectedItem.ToString() == "KanalPersonel")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("update \"KanalPersonel\" set \"calisanId\" = @p1, \"kanalGorev\" = @p2, \"kanalId\" = @p3 where \"calisanId\" = " + textBox17.Text, connection_Sql);
                if (!(textBox10.Text == "" || textBox10.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox10.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox11.Text == "" || textBox11.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", textBox11.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                if (!(textBox12.Text == "" || textBox12.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", int.Parse(textBox12.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox4.SelectedItem.ToString() == "Magaza")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("update \"Magaza\" set \"magazaId\" = @p1, \"magazaIsim\" = @p2, \"magazaVergiNo\" = @p3, \"magazaKonum\" = @p4, \"magazaYoneticiIsim\" = @p5, \"magazaCalisanSayisi\" = @p6 where \"magazaId\" = " + textBox17.Text, connection_Sql);
                if (!(textBox10.Text == "" || textBox10.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox10.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox11.Text == "" || textBox11.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", textBox11.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                if (!(textBox12.Text == "" || textBox12.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", textBox12.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", DBNull.Value);
                }
                if (!(textBox13.Text == "" || textBox13.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", textBox13.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", DBNull.Value);
                }
                if (!(textBox14.Text == "" || textBox14.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p5", textBox14.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p5", DBNull.Value);
                }
                if (!(textBox15.Text == "" || textBox15.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p6", int.Parse(textBox15.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p6", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox4.SelectedItem.ToString() == "MagazaAdetBilgi")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("update \"MagazaAdetBilgi\" set \"magazaSayisiId\" = @p1, \"magazaSayisi\" = @p2 where \"magazaSayisiId\" = " + textBox17.Text, connection_Sql);
                if (!(textBox10.Text == "" || textBox10.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox10.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox11.Text == "" || textBox11.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", int.Parse(textBox11.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox4.SelectedItem.ToString() == "MagazaPersonel")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("update \"MagazaPersonel\" set \"calisanId\" = @p1, \"sirket\" = @p2, \"sirketTel\" = @p3, \"magazaId\" = @p4 where \"calisanId\" = " + textBox17.Text, connection_Sql);
                if (!(textBox10.Text == "" || textBox10.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox10.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox11.Text == "" || textBox11.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", textBox11.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                if (!(textBox12.Text == "" || textBox12.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", int.Parse(textBox12.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", DBNull.Value);
                }
                if (!(textBox13.Text == "" || textBox13.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", int.Parse(textBox13.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox4.SelectedItem.ToString() == "MagazaUrun")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("update \"MagazaUrun\" set \"magazaUrunId\" = @p1, \"urunId\" = @p2, \"magazaId\" = @p3, \"bilgi\" = @p4 where \"magazaUrunId\" = " + textBox17.Text, connection_Sql);
                if (!(textBox10.Text == "" || textBox10.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox10.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox11.Text == "" || textBox11.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", int.Parse(textBox11.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                if (!(textBox12.Text == "" || textBox12.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", int.Parse(textBox12.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", DBNull.Value);
                }
                if (!(textBox13.Text == "" || textBox13.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", textBox13.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox4.SelectedItem.ToString() == "Materyel")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("update \"Materyel\" set \"materyelId\" = @p1, \"materyelIsim\" = @p2 where \"materyelId\" = " + textBox17.Text, connection_Sql);
                if (!(textBox10.Text == "" || textBox10.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox10.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox11.Text == "" || textBox11.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", textBox11.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox4.SelectedItem.ToString() == "MateryelAdetBilgi")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("update \"MateryelAdetBilgi\" set \"materyelSayiId\" = @p1, \"materyelSayisi\" = @p2 where \"materyelSayiId\" = " + textBox17.Text, connection_Sql);
                if (!(textBox10.Text == "" || textBox10.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox10.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox11.Text == "" || textBox11.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", int.Parse(textBox11.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox4.SelectedItem.ToString() == "Musteri")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("update \"Musteri\" set \"musteriId\" = @p1, \"musteriAdi\" = @p2, \"musteriSoyadi\" = @p3, \"musteriKonum\" = @p4, \"musteriYorum\" = @p5 where \"musteriId\" = " + textBox17.Text, connection_Sql);
                if (!(textBox10.Text == "" || textBox10.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox10.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox11.Text == "" || textBox11.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", textBox11.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                if (!(textBox12.Text == "" || textBox12.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", textBox12.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", DBNull.Value);
                }
                if (!(textBox13.Text == "" || textBox13.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", textBox13.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", DBNull.Value);
                }
                if (!(textBox14.Text == "" || textBox14.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p5", textBox14.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p5", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox4.SelectedItem.ToString() == "Reklam")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("update \"Reklam\" set \"reklamId\" = @p1, \"reklamIsim\" = @p2, \"reklamSure\" = @p3, \"reklamHedefKitle\" = @p4, \"reklamUlkeleri\" = @p5, \"reklamFirmasi\" = @p6, \"urunId\" = @p7 where \"reklamId\" = " + textBox17.Text, connection_Sql);
                if (!(textBox10.Text == "" || textBox10.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox10.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox11.Text == "" || textBox11.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", textBox11.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                if (!(textBox12.Text == "" || textBox12.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", textBox12.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", DBNull.Value);
                }
                if (!(textBox13.Text == "" || textBox13.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", textBox13.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", DBNull.Value);
                }
                if (!(textBox14.Text == "" || textBox14.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p5", textBox14.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p5", DBNull.Value);
                }
                if (!(textBox15.Text == "" || textBox15.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p6", textBox15.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p6", DBNull.Value);
                }
                if (!(textBox16.Text == "" || textBox16.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p7", int.Parse(textBox16.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p7", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox4.SelectedItem.ToString() == "ReklamKanal")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("update \"ReklamKanal\" set \"reklamKanalId\" = @p1, \"reklamId\" = @p2, \"kanalId\" = @p3, \"reklaminKanaldaSonTarihi\" = @p4 where \"reklamKanalId\" = " + textBox17.Text, connection_Sql);
                if (!(textBox10.Text == "" || textBox10.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox10.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox11.Text == "" || textBox11.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", int.Parse(textBox11.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                if (!(textBox12.Text == "" || textBox12.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", int.Parse(textBox12.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", DBNull.Value);
                }
                if (!(textBox13.Text == "" || textBox13.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", textBox13.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox4.SelectedItem.ToString() == "Siparis")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("update \"Siparis\" set \"siparisId\" = @p1, \"siparisYorum\" = @p2, \"siparisKonum\" = @p3, \"musteriId\" = @p4, \"magazaId\" = @p5 where \"siparisId\" = " + textBox17.Text, connection_Sql);
                if (!(textBox10.Text == "" || textBox10.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox10.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox11.Text == "" || textBox11.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", textBox11.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                if (!(textBox12.Text == "" || textBox12.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", textBox12.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", DBNull.Value);
                }
                if (!(textBox13.Text == "" || textBox13.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", int.Parse(textBox13.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", DBNull.Value);
                }
                if (!(textBox14.Text == "" || textBox14.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p5", int.Parse(textBox14.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p5", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox4.SelectedItem.ToString() == "Tedarikci")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("update \"Tedarikci\" set \"tedarikciId\" = @p1, \"tedarikciIsim\" = @p2, \"tedarikciKonum\" = @p3, \"urunId\" = @p4 where \"tedarikciId\" = " + textBox17.Text, connection_Sql);
                if (!(textBox10.Text == "" || textBox10.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox10.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox11.Text == "" || textBox11.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", textBox11.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                if (!(textBox12.Text == "" || textBox12.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", textBox12.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", DBNull.Value);
                }
                if (!(textBox13.Text == "" || textBox13.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", int.Parse(textBox13.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox4.SelectedItem.ToString() == "Urun")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("update \"Urun\" set \"urunId\" = @p1, \"urunAdi\" = @p2, \"urunRenk\" = @p3, \"materyelId\" = @p4 where \"urunId\" = " + textBox17.Text, connection_Sql);
                if (!(textBox10.Text == "" || textBox10.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox10.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox11.Text == "" || textBox11.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", textBox11.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                if (!(textBox12.Text == "" || textBox12.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", textBox12.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", DBNull.Value);
                }
                if (!(textBox13.Text == "" || textBox13.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", int.Parse(textBox13.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p4", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox4.SelectedItem.ToString() == "UrunAdetBilgi")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("update \"UrunAdetBilgi\" set \"urunSayisiId\" = @p1, \"urunSayisi\" = @p2 where \"urunSayisiId\" = " + textBox17.Text, connection_Sql);
                if (!(textBox10.Text == "" || textBox10.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox10.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox11.Text == "" || textBox11.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", int.Parse(textBox11.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (comboBox4.SelectedItem.ToString() == "Yonetici")
            {
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("update \"Yonetici\" set \"calisanId\" = @p1, \"sirket\" = @p2, \"bolum\" = @p3 where \"calisanId\" = " + textBox17.Text, connection_Sql);
                if (!(textBox10.Text == "" || textBox10.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", int.Parse(textBox10.Text));
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p1", DBNull.Value);
                }
                if (!(textBox11.Text == "" || textBox11.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", textBox11.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p2", DBNull.Value);
                }
                if (!(textBox12.Text == "" || textBox12.Text == null))
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", textBox12.Text.ToString());
                }
                else
                {
                    npgsqlCommand.Parameters.AddWithValue("@p3", DBNull.Value);
                }
                npgsqlCommand.ExecuteNonQuery();
                MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (connection_Sql.State == ConnectionState.Open)
            {
                connection_Sql.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!(connection_Sql.State == ConnectionState.Open))
            {
                connection_Sql.Open();
            }
            string find = "select column_name from information_schema.columns " +
                "where table_schema = 'public' and table_name = " + "'" + comboBox5.SelectedItem.ToString() + "'";
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(find, connection_Sql);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            DataTable dataTable = dataSet.Tables[0];
            int indexForCounter = 0, index = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                indexForCounter++;
            }
            string[] strings = new string[indexForCounter];
            foreach (DataRow row in dataTable.Rows)
            {
                strings[index] = row[0].ToString();
                index++;
            }
            NpgsqlCommand command = new NpgsqlCommand("Delete from \"" + comboBox5.SelectedItem.ToString() + "\" where " + "\"" + strings[0] + "\" = @p1", connection_Sql);
            command.Parameters.AddWithValue("@p1", int.Parse(textBox18.Text.ToString()));
            command.ExecuteNonQuery();
            MessageBox.Show("Process Is Succesfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            if (connection_Sql.State == ConnectionState.Open)
            {
                connection_Sql.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!(connection_Sql.State == ConnectionState.Open))
            {
                connection_Sql.Open();
            }
            string find = "select * from func1('" + textBox19.Text.ToString() + "')";
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(find, connection_Sql);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
            if (connection_Sql.State == ConnectionState.Open)
            {
                connection_Sql.Close();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!(connection_Sql.State == ConnectionState.Open))
            {
                connection_Sql.Open();
            }
            string find = "select * from maastoplam()";
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(find, connection_Sql);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
            if (connection_Sql.State == ConnectionState.Open)
            {
                connection_Sql.Close();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (!(connection_Sql.State == ConnectionState.Open))
            {
                connection_Sql.Open();
            }
            string find = "select * from gecmisreklamlar()";
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(find, connection_Sql);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
            if (connection_Sql.State == ConnectionState.Open)
            {
                connection_Sql.Close();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (!(connection_Sql.State == ConnectionState.Open))
            {
                connection_Sql.Open();
            }
            string find = "select * from aracdurum('" + textBox19.Text.ToString() + "')";
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(find, connection_Sql);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            dataGridView1.DataSource = dataSet.Tables[0];
            if (connection_Sql.State == ConnectionState.Open)
            {
                connection_Sql.Close();
            }
        }
    }
}