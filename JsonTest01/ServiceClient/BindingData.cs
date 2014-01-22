using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lib
{
    public class BindingData
    {
        private DataBinding<DataTable> _binding = new DataBinding<DataTable>();

        public BindingData()
        {
            var row = _binding.Data.NewRow();
            _binding.Data.Rows.Add(row);
        }

        public string JsonString
        {
            get
            {
                var json = DataTableJsonTool.Serialize(_binding.Data);
                //// DataTable은 배열형태이므로 "[", "]"를 제거한다.
                //json = json.Replace("]", "");
                //json = json.Replace("[", "");
                return json;
            }
        }

        public DataTable Data
        {
            get { return _binding.Data; }
            set { _binding.Data = value; }
        }

        private void AddCol(string colName)
        {
            _binding.Data.Columns.Add(colName);
        }

        public void Add(Control control, string PropertyName, string FieldName)
        {
            AddCol(FieldName);
            _binding.Add(control, PropertyName, FieldName);
        }

        public void Add(Control control, string FieldName)
        {
            AddCol(FieldName);
            _binding.Add(control, FieldName);
        }

        public void AddTag(Control control, string FieldName)
        {
            AddCol(FieldName);
            _binding.AddTag(control, FieldName);
        }

        public void EndEdit()
        {
            _binding.EndEdit();
        }

        public void Refresh()
        {
            _binding.Refresh();
        }
    }
}
