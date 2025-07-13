using System.ComponentModel;

namespace WaterTestProject.Common.Enums;

public enum EmployeePosition
{
    [Description("Сотрудник")] Worker,

    [Description("Руководитель")] Manager,

    [Description("Не указано")] None
}