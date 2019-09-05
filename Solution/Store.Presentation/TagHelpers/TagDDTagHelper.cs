using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Store.Presentation.TagHelpers
{
    [HtmlTargetElement("tag-dd")]
    public class TagDDTagHelper : TagHelper
    {
        [HtmlAttributeName("for")]
        public ModelExpression For { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var labelTag = new TagBuilder("label");
            labelTag.InnerHtml.Append(For.Metadata.Description);
            labelTag.AddCssClass("control-label");

            var pTag = new TagBuilder("p");
            pTag.AddCssClass("form-control-static");

            output.TagName = "div";
            output.Attributes.Add("class", "form-group");

            output.Content.AppendHtml(labelTag);
            output.Content.AppendHtml(pTag);
        }
    }

    [HtmlTargetElement("tag-di")]
    public class TagDITagHelper : TagHelper
    {
        [HtmlAttributeName("for")]
        public ModelExpression For { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var labelTag = new TagBuilder("label");
            labelTag.InnerHtml.Append(For.Metadata.Description);
            labelTag.AddCssClass("control-label");

            var inputTag = new TagBuilder("input");
            inputTag.AddCssClass("form-control");
            inputTag.TagRenderMode = TagRenderMode.StartTag;

            output.TagName = "div";
            output.Attributes.Add("class", "form-group");

            output.Content.AppendHtml(labelTag);
            output.Content.AppendHtml(inputTag);
        }
    }

    public static class FieldLengthValidation
    {
        public enum Limit
        {
            Min,
            Max
        };

        public static int? GetMinLength(this ModelMetadata model)
        {
            return GetMinOrMaxLengthValue(model, Limit.Min);
        }

        public static int? GetMaxLength(this ModelMetadata model)
        {
            return GetMinOrMaxLengthValue(model, Limit.Max);
        }

        public static int? GetMinOrMaxLengthValue(this ModelMetadata model, Limit limit)
        {
            IList<object> validationItems = ((DefaultModelMetadata)model).ValidationMetadata.ValidatorMetadata;
            if (!validationItems.Any())
                return null;

            bool hasStringValidationItems =
                validationItems.Any() &&
                validationItems.Any(a => (a as ValidationAttribute).GetType().ToString().Contains("StringLengthAttribute"));

            var attr = validationItems
                .DefaultIfEmpty(null)
                .FirstOrDefault(a => (a as ValidationAttribute).GetType().ToString().Contains("StringLengthAttribute"));

            if (attr == null)
                return null;

            StringLengthAttribute slAttr = (attr as StringLengthAttribute);

            if (limit == Limit.Min)
                return slAttr.MinimumLength;
            else
                return slAttr.MaximumLength;
        }
    }

}
