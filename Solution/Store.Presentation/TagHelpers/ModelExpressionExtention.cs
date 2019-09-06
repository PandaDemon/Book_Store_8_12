using Microsoft.AspNetCore.Mvc.ViewFeatures;

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

        public static string AngularPropertyName(this ModelExpression modelExpression)
        {
            string propertyName = modelExpression.Name;
            propertyName = char.ToLower(propertyName[0]).ToString() + propertyName.Substring(1);

            return propertyName;
        }
    }
}
