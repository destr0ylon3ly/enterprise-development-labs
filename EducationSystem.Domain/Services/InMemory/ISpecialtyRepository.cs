/// <summary>
/// Интерфейс для работы с хранилищем специальностей.
/// </summary>
public interface ISpecialtyRepository
{
    /// <summary>Получить специальность по шифру.</summary>
    Specialty GetByCode(string code);

    /// <summary>Получить все специальности (сортировка по популярности).</summary>
    List<Specialty> GetAll();

    /// <summary>Добавить новую специальность.</summary>
    void Add(Specialty specialty);

    /// <summary>Получить топ-N популярных специальностей.</summary>
    List<Specialty> GetTopSpecialties(int count);
}