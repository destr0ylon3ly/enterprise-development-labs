/// <summary>
/// Сервис для работы с данными университетов.
/// </summary>
public class UniversityService
{
    private readonly IUniversityRepository _repository;

    public UniversityService(IUniversityRepository repository)
    {
        _repository = repository;
    }

    /// <summary>Получить университет по ID.</summary>
    public University GetUniversity(int id) =>
        _repository.GetById(id);

    /// <summary>Получить все университеты.</summary>
    public List<University> GetAllUniversities() =>
        _repository.GetAll();

    /// <summary>Получить университеты с максимальным числом кафедр.</summary>
    public List<University> GetUniversitiesWithMaxDepartments()
    {
        return _repository.GetAll()
            .OrderByDescending(u => u.Faculties.Sum(f => f.Departments.Count))
            .ThenBy(u => u.Name)
            .ToList();
    }
}