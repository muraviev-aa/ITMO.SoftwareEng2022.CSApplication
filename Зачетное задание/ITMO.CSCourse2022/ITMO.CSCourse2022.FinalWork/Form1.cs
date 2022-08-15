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
    public partial class Form1 : Form
    {
        DataBase dataBase = new DataBase();
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1_login.MaxLength = 20;
            textBox2_password.MaxLength = 20;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            var loginUser = textBox1_login.Text;
            var passUser = textBox2_password.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select id_user, login_user, password_user from register where login_user = '{loginUser}' and password_user = '{passUser}'";

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count ==1)
            {
                MessageBox.Show("Соединение прошло успешно. Добро пожаловать в БД GreatDB!", "", MessageBoxButtons.OK);
                Form2 frm2 = new Form2();
                this.Hide();
                frm2.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("Что-то пошло не так!", "", MessageBoxButtons.OK);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var loginUser = textBox1_login.Text;
            var passUser = textBox2_password.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select id_user, login_user, password_user from register where login_user = '{loginUser}' and password_user = '{passUser}'";

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Соединение прошло успешно. Добро пожаловать в БД GreatDB!", "", MessageBoxButtons.OK);
                Form3 frm3 = new Form3();
                this.Hide();
                frm3.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("Что-то пошло не так!", "", MessageBoxButtons.OK);
        }
    }
}
