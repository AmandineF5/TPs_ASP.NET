using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace TP_Dojo.Utils
{
    public static class LinkObjectProp
    {
        public static void SetObjectProp(this object o1, object o2)
        {

            PropertyInfo[] propertiesO2 = o2.GetType().GetProperties().OrderBy(x => x.Name).ToArray();
            PropertyInfo[] propertiesO1 = o1.GetType().GetProperties().OrderBy(x => x.Name).ToArray();
            for (int i = 0; i < propertiesO1.Length; i++)
            {
                if (propertiesO1[i].Name.Equals(propertiesO2[i].Name))
                {
                    propertiesO1[i].SetValue(o1, propertiesO2[i].GetValue(o2));
                }
            }
        }
    }
}