using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGameLibrary.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IntValidation : ValidationAttribute
    {
        readonly int min;
        readonly int max;
        public override string FormatErrorMessage(string name)
        {
            return base.FormatErrorMessage(name);
        }

        public override bool IsValid(object value)
        {
            bool isOk = true;
            
            if (value is int)
            {
                int intValue = int.Parse(value.ToString());
                if (intValue < this.min | intValue > this.max)
                {
                    isOk = false;
                }
            }

            return isOk;
        }
    }
}
