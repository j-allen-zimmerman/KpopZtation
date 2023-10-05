using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Services.Model;
using Services.Factory;

namespace Services.Repository
{
    public class TransactionRepository
    {

        public static Database1Entities1 db = new Database1Entities1();

        public static TransactionHeader CreateTrHeader(int CustomerID, DateTime transactionDate)
        {
            TransactionHeader data = db.TransactionHeaders.Add(TransactionFactory.CreateTrHeader(CustomerID, transactionDate));
            db.SaveChanges();
            return data;
        }
        public static TransactionDetail CraeteTrDetail(int transactionID, int albumID, int qty)
        {
            TransactionDetail data = db.TransactionDetails.Add(TransactionFactory.CreateTrDetail(transactionID, albumID, qty));
            db.SaveChanges();
            return data;
        }
        public static List<TransactionHeader> GetAllTrHeader(int customerID)
        {
            return db.TransactionHeaders.Where(x => x.CustomerID == customerID).ToList();
        }

        public static List<TransactionDetail> GetAllTrDetail(int transactionId)
        {
            return db.TransactionDetails.Where(x => x.TransactionID == transactionId).ToList();
        }
    }
}