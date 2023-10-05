using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KpopZtation.Report;
using KpopZtation.Model;
using KpopZtation.Controller;

namespace KpopZtation.Views
{
    public partial class TransactionReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["Role"] == null || Session["Role"].Equals("Customer"))
            {
                Response.Redirect("~/Views/Home.aspx");
            }
            TransactionReport report = new TransactionReport();
            CrystalReportViewer1.ReportSource = report;
            DataSet1 data = loadDetailData(TransactionController.GetAllTransaction());
            report.SetDataSource(data);

        }


        //private DataSet1 loadDetailData(List<TransactionHeader> transaction)
        //{
        //    DataSet1 newData = new DataSet1();
        //    var headerTable = newData.TransactionHeader;
        //    var detailTabel = newData.TransactionDetail;
        //    int grandTotal = 0;

        //    foreach (TransactionHeader th in transaction)
        //    {

        //        var row = headerTable.NewRow();
        //        row["TransactionId"] = th.TransactionID;
        //        row["CustomerId"] = th.CustomerID;
        //        row["TransactionDate"] = th.TransactionDate;
        //        row["GrandTotalValue"] = grandTotal;
        //        headerTable.Rows.Add(row);
        //        foreach (TransactionDetail td in th.TransactionDetails)
        //        {
        //            var drow = detailTabel.NewRow();
        //            drow["TransactionId"] = td.TransactionID;
        //            drow["AlbumName"] = "JOELLELEL";
        //            drow["Quantity"] = td.Qty;
        //            drow["AlbumPrice"] = 3000;
        //            drow["SubTotalValue"] = 0;
        //            detailTabel.Rows.Add(drow);

        //        }
        //    }
        //    return newData;
        //}
        private DataSet1 loadDetailData(List<TransactionHeader> transaction)
        {
            DataSet1 newData = new DataSet1();
            var headerTable = newData.TransactionHeader;
            var detailTabel = newData.TransactionDetail;
           

            foreach (TransactionHeader th in transaction)
            {
                List<object> details = TransactionController.GetDetailReport(th.TransactionID);
                int grandTotal = 0;

                foreach (var td in details)
                {
                    var drow = detailTabel.NewRow();
                    drow["TransactionId"] = td.GetType().GetProperty("TransactionId").GetValue(td);
                    drow["AlbumName"] = td.GetType().GetProperty("AlbumName").GetValue(td);
                    drow["Quantity"] = td.GetType().GetProperty("Quantity").GetValue(td);
                    drow["AlbumPrice"] = td.GetType().GetProperty("AlbumPrice").GetValue(td);
                    int subtotal = (int)td.GetType().GetProperty("Quantity").GetValue(td) * (int)td.GetType().GetProperty("AlbumPrice").GetValue(td);
                    drow["SubTotalValue"] = subtotal;
                    grandTotal = grandTotal + subtotal;
                    detailTabel.Rows.Add(drow);

                }
                var row = headerTable.NewRow();
                row["TransactionId"] = th.TransactionID;
                row["CustomerId"] = th.CustomerID;
                row["TransactionDate"] = th.TransactionDate;
                row["GrandTotalValue"] = grandTotal;
                headerTable.Rows.Add(row);
            }
            return newData;
        }
    }
}