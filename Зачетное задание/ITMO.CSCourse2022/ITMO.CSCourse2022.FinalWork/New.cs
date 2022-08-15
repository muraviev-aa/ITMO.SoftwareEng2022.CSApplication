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
    public partial class New : Form
    {
        DataBase dataBase = new DataBase();
        public New()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            int pok;
            var per = textBox3.Text;
            var ter = textBox4.Text;
            var val = textBox5.Text;

            if (int.TryParse(textBox2.Text, out pok)) 
            {
                var addQuery = $"insert into Istochnik.TableSource (nPokazatelId, vPeriodType, vTerritoryId, nValue) values ('{pok}','{per}', '{ter}','{val}')";
                var command = new SqlCommand(addQuery, dataBase.getConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Запись в GreatDB создана!", "", MessageBoxButtons.OK);
            }
            else 
            {
                MessageBox.Show("Ошибка! Цена должна быть в int", "", MessageBoxButtons.OK);
            }

            dataBase.closeConnection();


        }
    }
}
