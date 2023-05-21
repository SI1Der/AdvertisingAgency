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

namespace AdvertisingAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        

        DAContext da = new DAContext();

        List <Client> ld = new List<Client>();
       
        
        [HttpGet]
        public IResult Get()
        {

            ld = da.Clients.ToList();
            return Results.Json(ld);
        }


        [HttpGet("{id}")]
        public IResult Get(int id)
        {
            int index = 0;
            ld = da.Clients.ToList();
            for (int i = 0; i < ld.Count; i++)
            {
                if (ld[i].IdClient == id) { index = i; }
            }
            return Results.Json(ld[index]);
        }

        [HttpPut("{id}")]
        public void Put(int id, string surname, string name, string patronymic, DateTime birthday, string address, string passport)
        {
            ld = da.Clients.ToList();
            for (int i = 0; i < ld.Count; i++)
            {
                if (ld[i].IdClient == id)
                {
                    ld[i].ClientSurname = surname;
                    ld[i].ClientName = name;
                    ld[i].DateOfBirth = birthday;
                    ld[i].Adress= address;
                    ld[i].Passport = passport;
                    ld[i].Clien = patronymic;
                    da.SaveChanges();
                }
            }
        }

        [HttpPost]
        public void Post(string surname, string name, string patronymic, DateTime birthday, string address, string passport)
        {
            Client c = new Client { ClientSurname = surname, ClientName = name,DateOfBirth = birthday,Adress = address,Passport = passport,Clien = patronymic
        };
            da.Clients.Add(c);
            da.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            da.Clients.Where(u => u.IdClient == id).ExecuteDelete();
            da.SaveChanges();
        }
    }
}
