using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Text.Encodings.Web;
using System.Text.Json;
using WebApp.Interfaces;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class ApartmentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IService _service;       

        public ApartmentController(IConfiguration Configuration, IService service)
        {            
            _configuration = Configuration;
            _service = service;
        }
        // 
        // GET: /Apartment/
        public IActionResult Index(string sortOrder, string sortCol)
        {
            ViewBag.SortParam = string.IsNullOrWhiteSpace(sortOrder) ? "desc" : "";
            var whereString = !string.IsNullOrWhiteSpace(sortCol) ? $"order by {sortCol} {sortOrder}" : "";
            var apartments = GetApartments(whereString);          
            return View(apartments);
        }
        // 
        // GET: /Apartment/Filter
        public IActionResult Filter(string filterName, string filterValue)
        {
            var apartments = new List<Apartment>();
            if (!string.IsNullOrWhiteSpace(filterName))
            {
                var filterString = string.IsNullOrWhiteSpace(filterValue) ? "" : $"where {filterName} = '{filterValue}'";
                apartments = GetApartments(filterString);
            }
            return PartialView("Table", apartments);
        }

        private List<Apartment> GetApartments(string whereString)
        {
            try
            {                   
                var constr = _configuration.GetConnectionString("DefaultApartmentConnection");
                var aparmtnets = (List<Apartment>)_service.GetData(whereString, constr);
                GetChartData(aparmtnets);
                return aparmtnets;
            }
            catch (Exception)
            {
                //TODO: error handler/error logger
                return new List<Apartment>();
            }
        }
        private void GetChartData (List<Apartment> apartments)
        {
            var grouped = apartments.Where(x => x.PriceHistory != null).SelectMany(p => p.PriceHistory.Where(ph => ph.PriceChangeDate != DateTime.MinValue).GroupBy(d => d.PriceChangeDate.Date.Month).Select(c => new DataPoint
            {
                x = c.FirstOrDefault().PriceChangeDate,
                y = (int)c.Average(p => p.PriceAtDate)
            })).ToList();
            ViewBag.ChartData = JsonSerializer.Serialize(grouped);
        }
    }
}
