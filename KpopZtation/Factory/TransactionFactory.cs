using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;

namespace KpopZtation.Factory
{
    public class TransactionFactory
    {

        public static Database1Entities3 db = new Database1Entities3();
        public static TransactionHeader CreateTrHeader(int CustomerID, DateTime transactionDate)
        {
            return new TransactionHeader
            {
                CustomerID = CustomerID,
                TransactionDate = transactionDate
            };
        }

        public static TransactionDetail CreateTrDetail(int transactionID, int albumID, int qty)
        {
            return new TransactionDetail
            {
                TransactionID = transactionID,
                AlbumID = albumID,
                Qty = qty
                
            };
        }

        public static List<TransactionHeader> GetAllTrHeader(int UserId)
        {
            return db.TransactionHeaders.Where(x => x.CustomerID == UserId).ToList();
        }

        public static List<TransactionDetail> GetAllTrDetail(int transactionId)
        {
            return db.TransactionDetails.Where(x => x.TransactionID == transactionId).ToList();
        }
    }
}