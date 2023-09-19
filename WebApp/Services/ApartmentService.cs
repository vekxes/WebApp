using System.Data.SqlClient;
using System.Data;
using WebApp.Models;
using WebApp.Interfaces;

namespace WebApp.Services
{
    public class ApartmentService : IService
    {        
        public IEnumerable<Entity> GetData(string whereString, string connectionString)
        {             
            var apartments = new List<Apartment>();
            var apartmentPriceHistory = new List<ApartmentPriceHistory>();
            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = connectionString;

                GetApartmentPriceHistories(apartmentPriceHistory, conn);
                GetApartments(apartments, apartmentPriceHistory, conn, whereString);

            }
            return apartments.ToList();
        }

        public void GetApartmentPriceHistories(List<ApartmentPriceHistory> apartmentPriceHistories, SqlConnection conn)
        {
            var da = new SqlDataAdapter();
            var apartmentPriceHistoryString = @$"select * from apartmentpricehistory";
            var apartHistoryDt = new DataTable();
            da.SelectCommand = new SqlCommand(apartmentPriceHistoryString, conn);
            da.Fill(apartHistoryDt);

            foreach (DataRow dataRow in apartHistoryDt.Rows)
            {
                var apartmentHistory = new ApartmentPriceHistory()
                {
                    Id = dataRow["Id"] != null ? (int)dataRow["Id"] : 0,
                    ApartmentId = dataRow["ApartmentId"] != null ? (int)dataRow["ApartmentId"] : 0,
                    PriceChangeDate = dataRow["PriceChangeDate"] != null ? (DateTime)dataRow["PriceChangeDate"] : DateTime.MinValue,
                    PriceAtDate = dataRow["PriceAtDate"] != null ? (double)dataRow["PriceAtDate"] : 0,
                };

                apartmentPriceHistories.Add(apartmentHistory);
            }
        }

        public void GetApartments(List<Apartment> apartments, IEnumerable<ApartmentPriceHistory> apartmentPriceHistory, SqlConnection conn, string whereString)
        {
            var da = new SqlDataAdapter();
            var apartmentsString = @"select * from apartments " + whereString;
            var apartmentDt = new DataTable();
            da.SelectCommand = new SqlCommand(apartmentsString, conn);
            da.Fill(apartmentDt);            
            foreach (DataRow row in apartmentDt.Rows)
            {
                var apartment = new Apartment()
                {
                    Id = row["Id"] != null ? (int)row["Id"] : 0,
                    NumberOfApartment = row["NumberOfApartment"] != null ? (int)row["NumberOfApartment"] : 0,
                    Price = row["Price"] != null ? (double)row["Price"] : 0,
                    Rooms = row["Rooms"] != null ? (int)row["Rooms"] : 0,
                    Url = row["Url"] != null ? (string)row["Url"] : "",
                };

                apartments.Add(apartment);
                apartment.PriceHistory = apartmentPriceHistory.Where(x => x.ApartmentId == apartment.Id).ToList();
            }
        }

        
    }
}
