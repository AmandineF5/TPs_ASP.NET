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
    public class ValidationNom : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        private Pizza pizza = new Pizza();
      

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool isOk = true;
            if (value is Pizza)
            {
                this.pizza = value as Pizza;
                List<Pizza> listePizzas = PizzaFakeDB.Instance.ListePizzas;
                var vm = validationContext.ObjectInstance as PizzaVM;

                if (vm.Pizza != null && vm.Pizza.Id != 0)
                {
                    if(listePizzas.Where(x => x.Id != vm.Pizza.Id).Any(x => x.Nom.Equals(pizza.Nom)))
                    {
                        isOk = false;
                    }
                } else
                {
                    if (listePizzas.Any(x => x.Nom.Equals(pizza.Nom)))
                    {
                        isOk = false;
                    }
                }
            }
            if (isOk == false)
            {
                return new ValidationResult("Ce nom est déjà pris");
            }
            else
            {
                return null;
            }
        }

        public override string FormatErrorMessage(string name)
        {
            return "Le nom de cette pizza est déjà pris";
        }
    }
}