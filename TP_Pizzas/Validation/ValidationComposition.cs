using BO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TP_Pizzas.Models;
using TP_Pizzas.Utils;

namespace TP_Pizzas.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ValidationComposition : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        private List<int> ingredientsId = null;
        List<Pizza> listePizzas = PizzaFakeDB.Instance.ListePizzas;
  

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool isOk = true;

            if (value is List<int>)
            {
                this.ingredientsId = value as List<int>;
                var vm = validationContext.ObjectInstance as PizzaVM;
                if (vm.Pizza != null && vm.Pizza.Id != 0)
                {
                    if (this.listePizzas.Where(x => x.Id != vm.Pizza.Id).Any(x => x.Ingredients.Select(y => y.Id).OrderBy(z => z).SequenceEqual(this.ingredientsId.OrderBy(z => z))))
                    {
                        isOk = false;
                    }
                }
                else
                {
                    if (this.listePizzas.Any(x => x.Ingredients.Select(y => y.Id).OrderBy(z => z).SequenceEqual(this.ingredientsId.OrderBy(z => z))))
                    {
                        isOk = false;
                    }
                }
            }

            if (isOk == false)
            {
                return new ValidationResult("Cette composition existe déjà. Veuillez modifier les ingrédients");
            }
            else
            {
                return null;
            }
        }

        public override string FormatErrorMessage(string name)
        {
            return "Cette composition existe déjà. Veuillez modifier les ingrédients";
        }
    }
}