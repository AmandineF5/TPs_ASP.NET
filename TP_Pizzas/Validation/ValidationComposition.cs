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

            foreach (var pizza in listePizzas)
            {
                if (ingredientsId.Count() == pizza.Ingredients.Count())
                {
                    //TODO: exclure la pizza en mode édition (override ValidationResult isValid, y appeler
                    //la vm par var vm = validationContext.ObjectInstance as PizzaVM) ==> voir correction AC dans la classe ValidationNotSame
                    foreach (var ingredientPizza in pizza.Ingredients)
                    {
                        foreach (var selectedIngredientId in ingredientsId)
                        {
                            if (selectedIngredientId == ingredientPizza.Id)
                            {
                                isOk = false;
                            } else
                            {
                                isOk = true;
                                return isOk;
                            }
                        }
                    }
                }
                else
                {
                    isOk = true;
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