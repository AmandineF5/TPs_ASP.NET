using OGameLibrary.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGameLibrary.Validation
{
    public class ResourceValidation : ValidationAttribute

    {
        public override bool IsValid(object value)
        {
            bool isOk = true;

            List<Resource> playerResources = value as List<Resource>;
            List<string> playerResourceNames = playerResources.Select(x => x.Name).ToList();
            List<string> resourceNames = new List<string>() { "énergie", "oxygène", "acier", "uranium" };

            if (playerResources.Count() > 4)
            {
                isOk = false;

                string tempName = "";
                for (int i = 0; i < resourceNames.Count; i++)
                {
                    if (!playerResourceNames.Contains(resourceNames[i]))
                    {
                        isOk = false;
                    }
                    else if (playerResourceNames.Contains(resourceNames[i])
                        && playerResourceNames[i] != tempName)
                    {
                        isOk = true;
                    } else
                    {
                        isOk = false;
                    }

                    tempName = playerResourceNames[i];
                }
            }


            return isOk;
        }
    }
}
