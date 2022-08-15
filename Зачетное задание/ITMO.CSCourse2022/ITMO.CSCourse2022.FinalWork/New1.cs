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
    public partial class New1 : Form
    {
        DataBase dataBase = new DataBase();
        public New1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            int pok;
            var ter = textBox2.Text;
            var terp = textBox3.Text;
            var val = textBox4.Text;

            if (int.TryParse(textBox1.Text, out pok))
            {
                var addQuery = $"insert into NashaBaza.OurTable (nCanonId, nTerOtdelenie, nTerPodrazdel, vProcent) values ('{pok}','{ter}', '{terp}','{val}')";
                var command1 = new SqlCommand(addQuery, dataBase.getConnection());
                command1.ExecuteNonQuery();

                MessageBox.Show("Запись в GreatDB создана!", "", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Ошибка! ID должен быть в int", "", MessageBoxButtons.OK);
            }

            dataBase.closeConnection();
        }
    }
}
