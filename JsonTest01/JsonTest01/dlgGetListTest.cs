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
using UI;

namespace JsonTest01
{
    public partial class dlgGetListTest : Form
    {
        public dlgGetListTest()
        {
            InitializeComponent();

            InitBinding();
            ShowList();
        }

        private BindingData _binding = new BindingData();

        private void InitBinding()
        {
            _binding.Add(null, "SN");
            _binding.Add(textEdit2, "Name");
            _binding.Add(textEdit3, "Age", typeof(int));
            _binding.Add(textEdit4, "Job");
        }

        private async void ShowList()
        {
            gridControl1.DataSource = await ServiceClient.Get("http://192.168.23.70/JsonTest.txt");
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Clicks != 2)
                return;

            _binding.Data = gridView1.GetSelectedRowDataTable();
            _binding.Refresh();
        }
    }
}
