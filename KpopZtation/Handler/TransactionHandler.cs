using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Repository;
using KpopZtation.Model;

namespace KpopZtation.Handler
{
    public class TransactionHandler
    {
        public static TransactionHeader CreateTrHeader(int CustomerID, DateTime transactionDate)
        {
            return TransactionRepository.CreateTrHeader(CustomerID, transactionDate);
        }

        public static void CreateTrDetail(int transactionID, int albumID, int qty)
        {
            TransactionRepository.CraeteTrDetail(transactionID,albumID,qty);
        }

        public static List<TransactionHeader> GetAllTransaction()
        {
            return TransactionRepository.GetAllTrHeader();
        }

        public static List<TransactionDetail> GetAllTransactionDetail(int transactionID)
        {
            return TransactionRepository.GetAllTrDetail(transactionID);
        }

        public static List<object> GetHistory()
        {
            return TransactionRepository.GetHistory();
        }
        public static List<object> GetDetailReport(int TransactionId)
        {
            return TransactionRepository.GetDetailsReport(TransactionId);
        }
        public static List<object> GetHeaderHistory(int customerId)
        {
            return TransactionRepository.GetHeaderHistory(customerId);
        }
        public static List<object> GetDetailHistory(int TransactionId)
        {
            return TransactionRepository.GetDetailHistory(TransactionId);
        }

    }
}