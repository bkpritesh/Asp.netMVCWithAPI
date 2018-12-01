using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Areas.Management.Models.TeamManagement {
    public class Product {
        public class Feature {
            string featureId;
            string name;
            string description;
            string price;
        }

        string productId;
        string name;
        string description;
        string price;
        Feature[] features;
    }
}