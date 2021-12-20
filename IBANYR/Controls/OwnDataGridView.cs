using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace IBANYR
{
    class OwnDataGridView : DataGridView
    {
        public void LoadDataToGridView<T>(List<T> dataList)
        {
            Type myListElementType = dataList.GetType().GetGenericArguments().Single();
            if (myListElementType.GetProperties().Length > 1)
            {
                if (this.Columns.Count == 0)
                {
                    for (int i = 0; i < myListElementType.GetProperties().Length; i++)
                    {
                        this.Columns.Add(myListElementType.GetProperties()[i].Name, ((DisplayNameAttribute)TypeDescriptor.GetProperties(myListElementType)[myListElementType.GetProperties()[i].Name].Attributes[typeof(DisplayNameAttribute)]).DisplayName);
                    }
                    this.ColumnHeaderMouseDoubleClick += Dgv_ColumnHeaderMouseDoubleClick;
                }
                for (int f = 0; f < dataList.Count; f++)
                {
                    this.Rows.Add();
                        
                    for (int i = 0; i < myListElementType.GetProperties().Length; i++)
                    {
                        if (dataList[f].GetType().GetProperties()[i].GetValue(dataList[f]) is bool myBool)
                        {
                            this.Rows[f].Cells[i].Value = myBool ? "Igen" : "Nem";
                        }
                        else if (dataList[f].GetType().GetProperties()[i].GetValue(dataList[f]) != null && dataList[f].GetType().GetProperties()[i].GetValue(dataList[f]).GetType().IsEnum)
                        {
                            if (!String.IsNullOrEmpty((Attribute.GetCustomAttribute(dataList[f].GetType().GetProperties()[i].GetValue(dataList[f]).GetType().GetField(dataList[f].GetType().GetProperties()[i].GetValue(dataList[f]).ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description))
                            {
                                this.Rows[f].Cells[i].Value = (Attribute.GetCustomAttribute(dataList[f].GetType().GetProperties()[i].GetValue(dataList[f]).GetType().GetField(dataList[f].GetType().GetProperties()[i].GetValue(dataList[f]).ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description;
                            }
                            else
                            {
                                this.Rows[f].Cells[i].Value = dataList[f].GetType().GetProperties()[i].GetValue(dataList[f]);
                            }
                        }
                        else
                        {
                            this.Rows[f].Cells[i].Value = dataList[f].GetType().GetProperties()[i].GetValue(dataList[f]);
                        }
                    }
                }
            }
        }

        private void Dgv_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (Control item in Controls)
            {
                if (item is DgvColumnPanel panel && panel.Name == "columnPanel")
                {
                    item.Dispose();
                }
            }
            new DgvColumnPanel(sender as DataGridView);
        }
    }
}
