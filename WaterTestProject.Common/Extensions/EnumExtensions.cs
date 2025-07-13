using System.ComponentModel;

namespace WaterTestProject.Common.Extensions;

public static class EnumExtensions
{
    public static string? GetDescription(this Enum value)
    {
        var type = value.GetType();
        var memberInfo = type.GetMember(value.ToString());

        if (memberInfo.Length <= 0)
            return null;

        var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
        return attrs.Length > 0 ? ((DescriptionAttribute)attrs[0]).Description : value.ToString();
    }
}