using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BO.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ValidationIngredients : System.ComponentModel.DataAnnotations.ValidationAttribute
    {

        readonly int _min;
        readonly int _max;

        private List<int> ingredientsId = null;

        public ValidationIngredients(int min, int max)
        {
            this._min = min;
            this._max = max;
        }
        public override bool IsValid(object value)
        {
            bool isOk = false;
            this.ingredientsId = value as List<int>;
            int nbIngredients = ingredientsId.Count();

            if (nbIngredients >= this._min && nbIngredients <= this._max)
            {
                isOk = true;
            }

            return isOk;
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format("Une pizza doit contenir entre {0} et {1} ingrédients", this._min, this._min);
        }
    }
}