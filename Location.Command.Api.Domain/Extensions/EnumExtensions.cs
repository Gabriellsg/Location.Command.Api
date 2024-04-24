using System.ComponentModel;
using System.Reflection;

namespace Location.Command.Api.Domain.Extensions;
public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

        if (fieldInfo != null)
        {
            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
        }

        return value.ToString();
    }
}