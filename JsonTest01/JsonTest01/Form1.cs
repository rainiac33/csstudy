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

        private void InitBinding()
        {
            _binding.Add(txtCol1, "Name");
            _binding.Add(txtCol2, "Age", typeof(int)); // Type 지정가능
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
