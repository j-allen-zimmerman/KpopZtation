using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Handler;
using KpopZtation.Model;


namespace KpopZtation.Controller
{
    public class TransactionController
    {
        public static TransactionHeader CreateTrHeader(int CustomerID, DateTime transactionDate)
        {
            return TransactionHandler.CreateTrHeader(CustomerID, transactionDate);
        }

        public static void CreateTrDetail(int transactionID, int albumID, int qty)
        {
            TransactionHandler.CreateTrDetail(transactionID, albumID, qty);
        }

        public static List<TransactionHeader> GetAllTransaction()
        {
            return TransactionHandler.GetAllTransaction();
        }

        public static List<TransactionDetail> GetAllTransactionDetail(int transactionID)
        {
            return TransactionHandler.GetAllTransactionDetail(transactionID);
        }

        public static List<object> GetHistory()
        {
            return TransactionHandler.GetHistory();
        }

        public static List<object> GetDetailReport(int TransactionId)
        {
            return TransactionHandler.GetDetailReport(TransactionId);
        }
        public static List<object> GetHeaderHistory(int customerId)
        {
            return TransactionHandler.GetHeaderHistory(customerId);
        }
        public static List<object> GeteDetailHistory(int TransactionId)
        {
            return TransactionHandler.GetDetailHistory(TransactionId);
        }

    }
}