using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Numerics;
using System.Net;
using Microsoft.EntityFrameworkCore.Storage;

namespace AdvertisingAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
       

        DAContext da = new DAContext();

        List<Order> ld = new List<Order>();
        [HttpGet]
        public IResult Get()
        {

            ld = da.Orders.ToList();
            return Results.Json(ld);
        }


        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            int index = 0;
            ld = da.Orders.ToList();
            for (int i = 0; i < ld.Count; i++)
            {
                if (ld[i].OrderNumber == id) { index = i; }
            }
            return Results.Json(ld[index]);
        }

        [HttpPut("{id}")]
        public void Put(int id, DateTime date, int clientid, int orderid, int count, float price)
        {
            ld = da.Orders.ToList();
            for (int i = 0; i < ld.Count; i++)
            {
                if (ld[i].OrderNumber == id)
                {
                    ld[i].OrderNumber = id;
                    ld[i].DateOfOrder = date;
                    ld[i].ClientCode = clientid;
                    ld[i].OrderCode=orderid;
                    ld[i].Count=count;
                    ld[i].Price=price;
                    da.SaveChanges();
                }}
        }

        [HttpPost]
        public void Post(DateTime date, int clientid, int orderid, int count, float price)
        {
            Order c = new Order
            { DateOfOrder = date, ClientCode = clientid, OrderCode = orderid, Count = count, Price = price };
            da.Orders.Add(c);
            da.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            da.Orders.Where(u => u.OrderNumber == id).ExecuteDelete();
            da.SaveChanges();
        }
    }
}

