/// <summary>
/// Описывает факультет ВУЗа. Связан с кафедрами и специальностями.
/// </summary>
public class Faculty
{
    public int Id { get; set; }
    public string Name { get; set; }               // Название факультета
    public List<Department> Departments { get; set; } // Список кафедр
    public List<Specialty> Specialties { get; set; }  // Список специальностей
}