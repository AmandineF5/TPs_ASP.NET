using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP_Pizzas.Models
{
    public class PizzaVM
    {
        public Pizza Pizza { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Pate> Pates { get; set; }

        public List<int> IngredientsIds { get; set; }

        public int? IdPate { get; set; }
        public int pateId { get; set; }
    }
}