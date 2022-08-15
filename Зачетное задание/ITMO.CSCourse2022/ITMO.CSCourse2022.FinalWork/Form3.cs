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
    enum RowState1
    {
        //Existed,
        //New,
        //Modified,
        //ModifiedNew,
        Deleted
    }
    public partial class Form3 : Form
    {
        DataBase dataBase = new DataBase();

        int selectedRow;
        private readonly object loginUser;
        private readonly object passUser;
        public Form3()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns()
        {
            dataGridView2.Columns.Add("PropId", "Порядковый номер");
            dataGridView2.Columns.Add("nCanonId", "Номер показателя");
            dataGridView2.Columns.Add("nTerOtdelenie", "ID региона");
            dataGridView2.Columns.Add("nTerPodrazdel", "ID отделения");
            dataGridView2.Columns.Add("vProcent", "Значение показателя");
            dataGridView2.Columns.Add("New", String.Empty);

        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(
                record.GetInt64(0), record.GetInt32(1), record.GetInt32(2), record.GetInt32(3), record.GetDecimal(4));
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from NashaBaza.OurTable";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView2);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[selectedRow];

                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[3].Value.ToString();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            New1 addfrm = new New1();
            addfrm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView2);
        }

        private void deleteRow()
        {
            int index = dataGridView2.CurrentCell.RowIndex;
            dataGridView2.Rows[index].Visible = false;

            if (dataGridView2.Rows[index].Cells[0].Value.ToString() == String.Empty)
            {
                dataGridView2.Rows[index].Cells[5].Value = RowState.Deleted;
                return;
            }

            dataGridView2.Rows[index].Cells[5].Value = RowState.Deleted;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            deleteRow();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Update();
            MessageBox.Show("Не успел написать сохранение удаления строки в БД GreatDB", "", MessageBoxButtons.OK);
        }
    }
}
