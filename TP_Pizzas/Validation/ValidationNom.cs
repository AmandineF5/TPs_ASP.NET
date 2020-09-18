using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_Pizzas.Utils;

namespace TP_Pizzas.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ValidationNom : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        private Pizza pizza = new Pizza();
        public override bool IsValid(object value)
        {
            bool isOk = false;
            this.pizza = value as Pizza;
            List<Pizza> listePizzas = PizzaFakeDB.Instance.ListePizzas;

            foreach (var item in listePizzas)
            {
                if (pizza.Nom == item.Nom)
                {
                    isOk = false;
                    return isOk;
                } else
                {
                    isOk = true;
                }
            }

            return isOk;
        }

        public override string FormatErrorMessage(string name)
        {
            return "Le nom de cette pizza est déjà pris";
        }
    }
}