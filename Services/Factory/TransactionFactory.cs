using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Services.Model;

namespace Services.Factory
{
    public class TransactionFactory
    {
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
    }
}