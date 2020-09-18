using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_Pizzas.Utils;

namespace TP_Pizzas.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ValidationComposition : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        private List<int> ingredientsId = null;
        public override bool IsValid(object value)
        {
            bool isOk = false;
            this.ingredientsId = value as List<int>;
            List<Pizza> listePizzas = PizzaFakeDB.Instance.ListePizzas;

            foreach (var item in listePizzas)
            {
                if (ingredientsId.Count() == item.Ingredients.Count())
                {
                    foreach (var ingredient in item.Ingredients)
                    {
                        foreach (var igredientP in item)
                        {

                        }
                    }
                }
            }
         

            return isOk;
        }

        public override string FormatErrorMessage(string name)
        {
            return "Cette composition existe déjà. Veuillez modifier les ingrédients";
        }
    }
}