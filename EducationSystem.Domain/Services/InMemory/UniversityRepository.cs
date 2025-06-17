/// <summary>
/// InMemory-реализация репозитория для работы с данными ВУЗов.
/// </summary>
public class UniversityRepository : IUniversityRepository
{
    private List<University> _universities = new();

    public University GetById(int id) => _universities.FirstOrDefault(u => u.Id == id);
    public List<University> GetAll() => _universities;
    public void Add(University university) => _universities.Add(university);
}