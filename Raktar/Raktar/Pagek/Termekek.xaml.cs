using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Raktar
{
    /// <summary>
    /// Interaction logic for Termekek.xaml
    /// </summary>
    public partial class Termekek : Page 
    {
        private void TablazatLetrehoz()
        {

            DataGrid datagrid = new DataGrid();
            dataGridView1.AutoGenerateColumns = false;
            datagrid.DataContext = CTermekkezeles.termekListaVisszaAd();

            DataGridTextColumn oszlop1 = new DataGridTextColumn();
            oszlop1.Header = "id";
            DataGridTextColumn oszlop2 = new DataGridTextColumn();
            oszlop2.Header = "Megnevezés";
            DataGridTextColumn oszlop3 = new DataGridTextColumn();
            oszlop3.Header = "Súly(gramm)";
            DataGridTextColumn oszlop4 = new DataGridTextColumn();
            oszlop4.Header = "Raktáron";
            DataGridTextColumn oszlop5 = new DataGridTextColumn();
            oszlop5.Header = "Raktár id";
            DataGridTextColumn oszlop6 = new DataGridTextColumn();
            oszlop6.Header = "Beszállítva";
            DataGridTextColumn oszlop7 = new DataGridTextColumn();
            oszlop7.Header = "Szavatosság";
            

            dataGridView1.Columns.Add(oszlop1);
            dataGridView1.Columns.Add(oszlop2);
            dataGridView1.Columns.Add(oszlop3);
            dataGridView1.Columns.Add(oszlop4);
            dataGridView1.Columns.Add(oszlop5);
            dataGridView1.Columns.Add(oszlop6);
            dataGridView1.Columns.Add(oszlop7);



        }
        public Termekek()
        {
            InitializeComponent();
            TablazatLetrehoz();
        }
    }
}
