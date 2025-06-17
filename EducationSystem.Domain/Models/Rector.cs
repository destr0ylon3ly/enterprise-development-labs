/// <summary>
/// Содержит сведения о ректоре ВУЗа: ФИО, учёную степень, звание и должность.
/// </summary>
public class Rector
{
    public string FullName { get; set; }      // ФИО
    public string Degree { get; set; }        // Учёная степень (доктор наук, кандидат наук)
    public string Title { get; set; }         // Звание (профессор, доцент)
    public string Position { get; set; }      // Должность (ректор, и.о. ректора)
}