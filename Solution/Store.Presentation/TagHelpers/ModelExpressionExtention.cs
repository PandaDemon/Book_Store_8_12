using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Presentation.TagHelpers
{
    public static class ModelExpressionExtention
    {
        public static string AngularName(this ModelExpression modelExpression)
        {
            string className = modelExpression.Metadata.ContainerType.Name;
            className = char.ToLower(className[0]).ToString() + className.Substring(1);

            string propertyName = modelExpression.Name;
            propertyName = char.ToLower(propertyName[0]).ToString() + propertyName.Substring(1);

            return className + "." + propertyName;
        }
    }
}
