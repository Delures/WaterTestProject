using WaterTestProject.Common.Enums;

namespace WaterTestProject.Database.Models;

public class DbEmployee : DbEntity
{
    /// <summary>
    ///     Имя
    /// </summary>
    public virtual string FirstName { get; set; }

    /// <summary>
    ///     Фамилия
    /// </summary>
    public virtual string LastName { get; set; }

    /// <summary>
    ///     Отчество
    /// </summary>
    public virtual string Patronymic { get; set; }

    /// <summary>
    ///     Должность
    /// </summary>
    public virtual EmployeePosition Position { get; set; }

    /// <summary>
    ///     Дата рождения
    /// </summary>
    public virtual DateTime DateOfBirth { get; set; }
}