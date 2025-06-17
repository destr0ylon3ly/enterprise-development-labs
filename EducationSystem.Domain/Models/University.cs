/// <summary>
/// Представляет высшее учебное заведение (ВУЗ).
/// Содержит основную информацию: название, адрес, ректора, тип собственности и связанные сущности.
/// </summary>
public class University
{
    public int Id { get; set; }                     // Регистрационный номер
    public string Name { get; set; }                // Название ВУЗа
    public string Address { get; set; }             // Адрес
    public Rector Rector { get; set; }              // Ректор (внешняя связь)
    public UniversityProperty PropertyType { get; set; } // Тип собственности учреждения
    public List<Faculty> Faculties { get; set; }    // Список факультетов
}