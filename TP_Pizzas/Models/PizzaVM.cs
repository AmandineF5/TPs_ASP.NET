using BO;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO.Validation;
using TP_Pizzas.Validation;

namespace TP_Pizzas.Models
{
    public class PizzaVM
    {
        [ValidationNom]
        public Pizza Pizza { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Pate> Pates { get; set; }
        [ValidationIngredients(2, 5)]
        public List<int> IngredientsIds { get; set; }

        
        public int? IdPate { get; set; }
        public int pateId { get; set; }
    }
}