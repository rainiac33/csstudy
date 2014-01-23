using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public static class GridHelper
    {
        public static T GetSelectedRowData<T>(this DevExpress.XtraGrid.Views.Grid.GridView gridView) where T : class, new()
        {
            try
            {
                return gridView.GetRow(gridView.GetSelectedRows()[0]) as T;
            }
            catch
            {
                return null;
            }
        }

        public static DataRow GetSelectedRowDataRow(this DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            try
            {
                var o = gridView.GetRow(gridView.GetSelectedRows()[0]) as DataRowView;
                return o.Row;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable GetSelectedRowDataTable(this DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            try
            {
                var o = gridView.GetRow(gridView.GetSelectedRows()[0]) as DataRowView;

                var table = o.DataView.Table.Clone();
                table.ImportRow(o.Row);

                return table;
            }
            catch
            {
                return null;
            }
        }

        public static void AddRow<T>(this DevExpress.XtraGrid.GridControl grid, T data) where T : class
        {
            var list = grid.DataSource as List<T>;
            if (list == null)
            {
                list = new List<T>();
                grid.DataSource = list;
            }

            list.Add(data);
            grid.RefreshDataSource();
        }


        public static void ReplaceRow<T>(this DevExpress.XtraGrid.GridControl grid, T oldData, T newData) where T : class
        {
            var list = grid.DataSource as List<T>;
            if (list == null)
                return;

            list.Insert(list.IndexOf(oldData), newData);
            list.Remove(oldData);

            grid.RefreshDataSource();
        }

        public static void RemoveRow<T>(this DevExpress.XtraGrid.GridControl grid, T data) where T : class
        {
            var list = grid.DataSource as List<T>;
            if (list == null)
                return;

            list.Remove(data);
            grid.RefreshDataSource();
        }
    }
}
