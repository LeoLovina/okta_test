using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;

namespace Infrastructure
{
    public class ModelProvider
    {
        /// <summary>
        /// OData uses the Entity Data Model (EDM) to describe the structure of data
        /// </summary>
        /// <returns></returns>
        public static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Computer>("Computers");
            builder.EntitySet<Ping>("Pings");
            return builder.GetEdmModel();
        }
    }
}
