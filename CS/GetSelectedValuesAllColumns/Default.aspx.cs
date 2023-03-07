using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using DevExpress.Web;

namespace GetSelectedValuesAllColumns {
    public partial class _Default : System.Web.UI.Page {
        protected void Page_Init(object sender, EventArgs e) {
            ASPxGridView1.DataSource = GetData();
            ASPxGridView1.KeyFieldName = "ID";
            ASPxGridView1.SettingsBehavior.AllowSelectByRowClick = true;
            ASPxGridView1.DataBind();

            if(!IsPostBack && !IsCallback) {
                ASPxGridView1.Columns[ASPxGridView1.KeyFieldName].Visible = false;
            }
        }

        private DataTable GetData() {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("IsActive", typeof(bool));
            for(int i = 0; i < 10; i++) {
                table.Rows.Add(i, "Item " + i.ToString(), DateTime.Now.AddDays(i), i % 2 == 0);
            }
            return table;
        }
        protected void ASPxButton1_Click(object sender, EventArgs e) {
            GetSelectedValues();
            PrintSelectedValues();
        }

        
        List<object> selectedValues;

        private void GetSelectedValues() {
            List<string> fieldNames = new List<string>();
            foreach(GridViewColumn column in ASPxGridView1.Columns)
                if(column is GridViewDataColumn)
                    fieldNames.Add(((GridViewDataColumn)column).FieldName);
            selectedValues = ASPxGridView1.GetSelectedFieldValues(fieldNames.ToArray());
        }

        private void PrintSelectedValues() {
            if(selectedValues == null) return;
            string result = "";
            foreach(object[] item in selectedValues) {
                foreach(object value in item) {
                   result += string.Format("{0}&nbsp;&nbsp;&nbsp;&nbsp;", value);
                }
                result += "</br>";
            }
            Literal1.Text = result;
        }
    }
}
