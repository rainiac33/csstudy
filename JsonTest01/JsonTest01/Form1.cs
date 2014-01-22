using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib;

namespace JsonTest01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            InitBinding();
        }

        private BindingData _binding = new BindingData();
        //private DataBinding<DataTable> _binding = new DataBinding<DataTable>();

        private void InitBinding()
        {
            //var dt = new DataTable();

            //var dr = dt.NewRow();
            //dt.Rows.Add(dr);

            //dt.Columns.Add("Name");
            //dt.Columns.Add("Age");
            //dt.Columns.Add("Job");

            //_binding.Data = dt;

            //var dr = _binding.Data.NewRow();
            //_binding.Data.Rows.Add(dr);

            //_binding.Data.Columns.Add("Name");
            _binding.Add(txtCol1, "Name");

            //_binding.Data.Columns.Add("Age");
            _binding.Add(txtCol2, "Age");

            //_binding.Data.Columns.Add("Job");
            _binding.Add(txtCol3, "Job");
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = await ServiceClient.Get("http://192.168.23.70/JsonTest.txt");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            _binding.EndEdit();

            var a = _binding.JsonString;
        }
    }
}
