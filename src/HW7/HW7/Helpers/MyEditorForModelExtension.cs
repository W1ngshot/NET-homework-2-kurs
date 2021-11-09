using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HW7.Helpers
{
    public static class MyEditorForModelExtension
    {
        public static IHtmlContent MyEditorForModel(this IHtmlHelper helper)
        {
            var model = helper.ViewData.Model;
            var modelProperties = model.GetType().GetProperties();
            var editorBuilder = new HtmlContentBuilder();
            foreach (var propertyInfo in modelProperties)
            {
                var validationMessage = GetValidationMessage(propertyInfo, model);
                var propertyEditor = CreatePropertyEditor(propertyInfo, model, validationMessage);
                editorBuilder.AppendHtml(propertyEditor);
            }

            return editorBuilder;
        }

        private static IHtmlContent CreatePropertyEditor(PropertyInfo propertyInfo, object model, string? validationMessage)
        {
            var builder = new TagBuilder("div");
            builder.MergeAttribute("class", "mb-3");
            builder.InnerHtml.AppendHtml(CreatePropertyLabel(propertyInfo));
            builder.InnerHtml.AppendHtml(CreatePropertyField(propertyInfo, model));
            builder.InnerHtml.AppendHtml(CreatePropertyValidationSign(validationMessage));
            return builder;
        }
        
        private static string? GetValidationMessage(PropertyInfo propertyInfo, object model)
        {
            if (model == null) return null;

            var results = new List<ValidationResult>();
            var context = new ValidationContext(model)
            {
                MemberName = propertyInfo.Name,
                DisplayName = GetPropertyDisplayName(propertyInfo)
            };
            if (!Validator.TryValidateProperty(propertyInfo.GetValue(model), context, results))
                return results.Count == 0 ? null : results[0].ErrorMessage;
            return null;
        }

        private static IHtmlContent CreatePropertyLabel(PropertyInfo propertyInfo)
        {
            var builder = new TagBuilder("label");
            var displayName = GetPropertyDisplayName(propertyInfo);
            builder.MergeAttribute("for", propertyInfo.Name);
            builder.MergeAttribute("class", "form-label");
            builder.InnerHtml.SetContent(displayName);
            return builder;
        }
    
        private static string GetPropertyDisplayName(MemberInfo propertyInfo)
        {
            var propertyDisplayName = propertyInfo.GetCustomAttribute<DisplayAttribute>()?.Name;
            if (propertyDisplayName != null) return propertyDisplayName;
            return Regex.Replace(propertyInfo.Name, "([A-Z])", " $1", RegexOptions.Compiled).Trim();
        }

        private static IHtmlContent CreatePropertyField(PropertyInfo propertyInfo, object model)
        {
            var isEnum = propertyInfo.PropertyType.IsEnum;
            var fieldTagName = isEnum ? "select" : "input";
            var builder = new TagBuilder(fieldTagName);
            builder.MergeAttribute("id", propertyInfo.Name);
            builder.MergeAttribute("name", propertyInfo.Name);
            builder.MergeAttribute("class", "form-control");
            
            if (isEnum) AddPropertySelectOptions(builder, propertyInfo, model);
            else AddPropertyInputAttributes(builder, propertyInfo, model);
            return builder;
        }

        private static void AddPropertyInputAttributes(TagBuilder builder, PropertyInfo propertyInfo, object model)
        {
            builder.MergeAttribute("type", GetPropertyInputType(propertyInfo.PropertyType));
            if (model == null) return;
            var value = propertyInfo.GetValue(model);
            if (value != null) builder.MergeAttribute("value", value.ToString());
        }

        private static void AddPropertySelectOptions(TagBuilder selectBuilder, PropertyInfo propertyInfo, object model)
        {
            object modelValue = 0;
            if (model != null) modelValue = propertyInfo.GetValue(model);
            var enumItems = propertyInfo.PropertyType.GetFields(BindingFlags.Public | BindingFlags.Static);
            foreach (var enumItem in enumItems)
            {
                var enumType = enumItem.DeclaringType;
                var optionBuilder = new TagBuilder("option");
                optionBuilder.MergeAttribute("value", enumItem.Name);
                if (enumItem.GetValue(enumType)?.Equals(modelValue) ?? false) optionBuilder.MergeAttribute("selected", "true");
                optionBuilder.InnerHtml.AppendHtmlLine(GetPropertyDisplayName(enumItem));
                selectBuilder.InnerHtml.AppendHtml(optionBuilder);
            }
        }
        
        private static IHtmlContent CreatePropertyValidationSign(string? errorMessage)
        {
            var builder = new TagBuilder("span");
            builder.MergeAttribute("class", "text-danger col-form-label");
            if (errorMessage != null) builder.InnerHtml.SetContent(errorMessage);
            return builder;
        }
        
        private static string GetPropertyInputType(Type propertyType)
        {
            var intTypes = new HashSet<Type>()
            {
                typeof(int),
                typeof(uint),
                typeof(byte),
                typeof(sbyte),
                typeof(long),
                typeof(ulong),
                typeof(short),
                typeof(ushort)
            };
            var isInt = intTypes.Contains(propertyType) || intTypes.Contains(Nullable.GetUnderlyingType(propertyType));
            return isInt ? "number" : "text";
        }
    }
}