using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebWMS.Models;
using WebWMS.Repository;

namespace WebWMS.Controllers
{
    public class DeliveryLineController : ApiController
    {
        public IDeliveryLineRepository DelLines = new DeliveryLineRepository();

        // GET api/<controller>
        public IEnumerable<DeliveryLineModel> Get()
        {
            return DelLines.GetAll();
        }

        // GET api/<controller>/5
        public HttpResponseMessage GetById(int id)
        {
            var findDelLine = DelLines.Find(id);
            if (findDelLine == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, findDelLine);
            return response;
        }

        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]DeliveryLineModel delLine)
        {
            if (delLine == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            DelLines.Add(delLine);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, delLine);
            return response;
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, [FromBody]DeliveryLineModel delLine)
        {
            if (delLine == null)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }
            var findDelLine = DelLines.Find(id);
            if (findDelLine == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }           
            DelLines.Update(delLine);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, delLine);
            return response;

        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            DelLines.Remove(id);
        }
    }
}