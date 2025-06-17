/// <summary>
/// Сервис для работы со специальностями.
/// </summary>
public class SpecialtyService
{
    private readonly ISpecialtyRepository _repository;

    public SpecialtyService(ISpecialtyRepository repository)
    {
        _repository = repository;
    }

    /// <summary>Получить топ-5 популярных специальностей.</summary>
    public List<Specialty> GetTopSpecialties() =>
        _repository.GetTopSpecialties(5);

    /// <summary>Получить специальности по названию (поиск).</summary>
    public List<Specialty> FindByName(string name) =>
        _repository.GetAll()
            .Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
            .ToList();
}