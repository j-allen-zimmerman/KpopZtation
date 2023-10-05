using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KpopZtation.Model;
using KpopZtation.Factory;

namespace KpopZtation.Repository
{
    public class TransactionRepository
    {
        
        public static Database1Entities3 db = new Database1Entities3();

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
        public static List<TransactionHeader> GetAllTrHeader()
        {
            return db.TransactionHeaders.ToList();
        }

        public static List<TransactionDetail> GetAllTrDetail(int transactionId)
        {
            return db.TransactionDetails.Where(x => x.TransactionID == transactionId).ToList();
        }

        public static List<object> GetHistory()
        {
            // buat dapetin keseluruhan history(ga dipake)
            var getHistory = (from customer in db.Customers
                           join th in db.TransactionHeaders on customer.CustomerID equals th.CustomerID 
                           join td in db.TransactionDetails on th.TransactionID equals td.TransactionID
                           join album in db.Albums on td.AlbumID equals album.AlbumID
                           select new
                           {
                               TransactionId = th.TransactionID,
                               TransactionDate = th.TransactionDate,
                               CustomerName = customer.CustomerName,
                               AlbumImage = album.AlbumImage,
                               AlbumName = album.AlbumName,
                               AlbumQuantity = td.Qty,
                               AlbumPrice = album.AlbumPrice
                           }).ToList<object>();
            return getHistory;
        }

        public static List<object> GetHeaderHistory(int idx)
        {
            var getHeaderHistory = (from customer in db.Customers
                                    join th in db.TransactionHeaders on customer.CustomerID equals th.CustomerID
                                    where (th.CustomerID == idx)
                                    select new
                                    {
                                        TransactionId = th.TransactionID,
                                        TransactionDate = th.TransactionDate,
                                        CustomerName = customer.CustomerName
                                    }).ToList<object>();
            return getHeaderHistory;
        }

        public static List<object> GetDetailsReport(int TransactionId)
        {
            var getdetailReport = (from td in db.TransactionDetails
                                   join album in db.Albums on td.AlbumID equals album.AlbumID
                                   where td.TransactionID == TransactionId
                                   select new
                                   {
                                       TransactionId = td.TransactionID,
                                       AlbumName = album.AlbumName,
                                       Quantity = td.Qty,
                                       AlbumPrice = album.AlbumPrice,
                                       
                                   }).ToList<object>();
            return getdetailReport;
        }

        public static List<object> GetDetailHistory(int TransactionId)
        {
            var getdetailReport = (from td in db.TransactionDetails
                                   join album in db.Albums on td.AlbumID equals album.AlbumID
                                   where td.TransactionID == TransactionId
                                   select new
                                   {
                                       TransactionId = td.TransactionID,
                                       AlbumName = album.AlbumName,
                                       AlbumImage = album.AlbumImage,
                                       AlbumPrice = album.AlbumPrice,
                                       AlbumQuantity = td.Qty


                                   }).ToList<object>();
            return getdetailReport;
        }
    }
}
