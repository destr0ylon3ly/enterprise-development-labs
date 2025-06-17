/// <summary>
/// Специальность, предлагаемая ВУЗом. Может быть общей для разных учреждений.
/// </summary>
public class Specialty
{
    public string Code { get; set; }          // Шифр специальности (например, "09.03.01")
    public string Name { get; set; }           // Название (например, "Информатика и вычислительная техника")
    public int GroupCount { get; set; }        // Количество учебных групп
}