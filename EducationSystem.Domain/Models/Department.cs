/// <summary>
/// Кафедра ВУЗа. Хранит название и связанные специальности.
/// </summary>
public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }              // Название кафедры
    public List<Specialty> Specialties { get; set; } // Специальности кафедры
}