using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lib
{
    public class DataBinding<T> where T : class, new()
    {
        public DataBinding()
        {
            Reset();
        }

        private T m_data;
        private BindingSource m_binding = new BindingSource();

        private const string EditValue = "EditValue";
        private const string Tag = "Tag";

        public T Data
        {
            get
            {
                m_binding.EndEdit();
                return m_data;
            }
            set
            {
                m_data = value;
                m_binding.DataSource = m_data;
                m_binding.ResetBindings(false);
            }
        }

        public void Add(Control control, string PropertyName, string FieldName)
        {
            control.DataBindings.Add(new Binding(PropertyName, m_binding, FieldName, true));
        }

        public void Add(Control control, string FieldName)
        {
            control.DataBindings.Add(new Binding(EditValue, m_binding, FieldName, true));
        }

        public void AddTag(Control control, string FieldName)
        {
            control.DataBindings.Add(new Binding(Tag, m_binding, FieldName, true));
        }

        public void EndEdit()
        {
            m_binding.EndEdit();
        }

        public void Reset()
        {
            m_data = new T();
            m_binding.DataSource = m_data;
            m_binding.ResetBindings(true);
        }

        public void Refresh()
        {
            m_binding.ResetBindings(false);
        }
    }
}
