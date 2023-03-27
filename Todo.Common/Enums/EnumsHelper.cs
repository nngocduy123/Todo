using System;
using System.ComponentModel;

namespace Todo.Common.Enums
{
	public static class EnumsHelper
	{
        public static string ToDescription<TEnum>(this TEnum enumValue) where TEnum : struct
        {
            var field = enumValue.GetType().GetField(enumValue.ToString());
            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
            {
                return attribute.Description;
            }
            throw new ArgumentException("Item not found.", nameof(enumValue));
        }
    }
}

