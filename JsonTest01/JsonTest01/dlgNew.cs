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
    public partial class dlgNew : Form
    {
        public dlgNew()
        {
            InitializeComponent();
            InitBinding();
        }

        private BindingData _binding = new BindingData();

        private void InitBinding()
        {
            _binding.Add(null, "SN", typeof(long));
            _binding.Add(textEdit1, "Name");
            _binding.Add(textEdit2, "Age", typeof(int));
            _binding.Add(textEdit3, "Job");

            _binding.SetValue("SN", 0);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _binding.EndEdit();

            var s = _binding.JsonString;
        }
    }
}
