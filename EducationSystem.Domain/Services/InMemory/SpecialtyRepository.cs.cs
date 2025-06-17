/// <summary>
/// InMemory-реализация репозитория для работы со специальностями.
/// </summary>
public class SpecialtyRepository : ISpecialtyRepository
{
    private readonly List<Specialty> _specialties = new();

    public Specialty GetByCode(string code) =>
        _specialties.FirstOrDefault(s => s.Code == code);

    public List<Specialty> GetAll() =>
        _specialties.OrderByDescending(s => s.GroupCount).ToList();

    public void Add(Specialty specialty)
    {
        if (GetByCode(specialty.Code) == null)
            _specialties.Add(specialty);
    }

    public List<Specialty> GetTopSpecialties(int count) =>
        _specialties.OrderByDescending(s => s.GroupCount).Take(count).ToList();
}