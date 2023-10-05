using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Services.Repository;
using Services.Model;

namespace Services.Handler
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

        public static List<TransactionHeader> GetAllTransaction(int customerID)
        {
            return TransactionRepository.GetAllTrHeader(customerID);
        }

        public static List<TransactionDetail> GetAllTransactionDetail(int transactionID)
        {
            return TransactionRepository.GetAllTrDetail(transactionID);
        }
    }
}