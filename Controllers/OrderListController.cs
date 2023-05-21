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
using Microsoft.Extensions.Options;

namespace AdvertisingAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderListController : ControllerBase
    {
        

        DAContext da = new DAContext();

        List<OrdersList> ld = new List<OrdersList>();
       
        [HttpGet]
        public IResult Get()
        {

            ld = da.OrdersLists.ToList();
            return Results.Json(ld);
        }


        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            int index = 0;
            ld = da.OrdersLists.ToList();
            for (int i = 0; i < ld.Count; i++)
            {
                if (ld[i].IdOrder == id) { index = i; }
            }
            return Results.Json(ld[index]);
        }

        [HttpPut("{id}")]
        public void Put(int id, string name, float price)
        {
            ld = da.OrdersLists.ToList();
            for (int i = 0; i < ld.Count; i++)
            {
                if (ld[i].IdOrder == id)
                {
                    ld[i].OrderName = name;
                    ld[i].OrderPrice = price;
                    da.SaveChanges();
                }}
        }

        [HttpPost]
        public void Post(string name, float price)
        {
            OrdersList c = new OrdersList
            {OrderName = name, OrderPrice = price};

            da.OrdersLists.Add(c);
            da.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            da.OrdersLists.Where(u => u.IdOrder == id).ExecuteDelete();
            da.SaveChanges();
        }
    }
}

