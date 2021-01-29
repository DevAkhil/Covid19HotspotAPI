using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TestAPI.Data;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    public class HotspotsController : ApiController
    {
        


        public HttpResponseMessage Get()
        {

            List<Hotspot> hs = new List<Hotspot>();
            hs = GetStats.getAllStats();
            if (hs == null)
            {
                var message = string.Format("Data Could Not Be Retrieved Please Try Again Later");
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
            else
                return Request.CreateResponse(HttpStatusCode.OK, hs);

        }

        public HttpResponseMessage Get(string id)
        {
            List<Hotspot> hs = new List<Hotspot>();
            hs = GetStats.getStatForProvince(id);

            if (hs == null)
            {
                var message = string.Format("Hotspot with id = {0} not found", id);
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
            else
                return Request.CreateResponse(HttpStatusCode.OK, hs);

        }

    }

}