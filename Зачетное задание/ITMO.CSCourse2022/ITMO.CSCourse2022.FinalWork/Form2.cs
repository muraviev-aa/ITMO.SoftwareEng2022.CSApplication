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

namespace ITMO.CSCourse2022.FinalWork
{
    enum RowState 
    {
        Deleted
    }
    public partial class Form2 : Form
    {
        DataBase dataBase = new DataBase();

        int selectedRow;
        private readonly object loginUser;
        private readonly object passUser;

        public Form2()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns() 
        {
            dataGridView1.Columns.Add("LineId", "Порядковый номер");
            dataGridView1.Columns.Add("nPokazatelId", "Номер показателя");
            dataGridView1.Columns.Add("vPeriodType", "Период отчетности");
            dataGridView1.Columns.Add("vTerritoryId", "ID территории");
            dataGridView1.Columns.Add("nValue decimal", "Значение показателя");
            dataGridView1.Columns.Add("New", String.Empty);

        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(
                record.GetInt64(0)
                , record.GetInt64(1)
                , record.GetString(2)
                , record.GetString(3)
                , record.GetDecimal(4)
                );
        }

        private void RefreshDataGrid(DataGridView dgw) 
        {
            dgw.Rows.Clear();

            string queryString = $"select * from Istochnik.TableSource";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }


        private void button1_Click(object sender, EventArgs e)
        {

            SqlDataAdapter adapter1 = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select id_user, login_user, password_user from register where login_user = '{loginUser}' and password_user = '{passUser}'";

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());
            adapter1.SelectCommand = command;
            adapter1.Fill(table);

            Form3 frm3 = new Form3();
            this.Hide();
            frm3.ShowDialog();
            this.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[3].Value.ToString();

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            New addfrm = new New();
            addfrm.ShowDialog();
        }

        private void deleteRow() 
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[index].Visible = false;

            if(dataGridView1.Rows[index].Cells[0].Value.ToString() == String.Empty) 
            {
                dataGridView1.Rows[index].Cells[5].Value = RowState.Deleted;
                return;
            }

            dataGridView1.Rows[index].Cells[5].Value = RowState.Deleted;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            deleteRow();
        }

        private void Update() 
        { 
            //dataBase.openConnection();

            //for(int index = 0; index < dataGridView1.Rows.Count; index++) 
            //{
            //    var rowState = (RowState)dataGridView1.Rows[index].Cells[5].Value;

            //    //if (rowState == RowState.Existed)
            //    //    continue;

            //    if (rowState == RowState.Deleted) 
            //    {
            //        var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
            //        var deleteQuery = $"delete from GreatDB where id = {id}";

            //        var command = new SqlCommand(deleteQuery, dataBase.getConnection());
            //        command.ExecuteNonQuery();
            //    }
            //}
            //dataBase.closeConnection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Update();
            MessageBox.Show("Не успел написать сохранение удаления строки в БД GreatDB", "", MessageBoxButtons.OK);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
