using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebWMS.Models;

namespace WebWMS.Controllers
{
    //[Route("api/[controller]")]
    public class DeliveryController : ApiController
    {
        List<DeliveryData> _deliveries = new List<DeliveryData>();

        // GET api/<controller>
        public IEnumerable<DeliveryData> Get()
        {
            var del1 = new DeliveryData { DeliveryId = 20, Name = "Rest Test Del 1", State = "Testing" };
            var del2 = new DeliveryData { DeliveryId = 21, Name = "Rest Test Del 2", State = "Testing" };

            _deliveries.Add(del1);
            _deliveries.Add(del2);

            return _deliveries;
        }

        // GET api/<controller>/5
        public List<DeliveryData> Get(int id)
        {
            if (id == 1)
            {
                var del3 = new DeliveryData { DeliveryId = 22, Name = "Rest Test Del 3", State = "Testing" };
                _deliveries.Add(del3);
            }

            return _deliveries;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}