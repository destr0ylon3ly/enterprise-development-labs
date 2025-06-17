/// <summary>
/// Сервис для генерации отчётов по заданным запросам.
/// </summary>
public class ReportService
{
    private readonly IUniversityRepository _universityRepository;
    private readonly ISpecialtyRepository _specialtyRepository;
    private readonly ILogger<ReportService> _logger;

    public ReportService(
        IUniversityRepository universityRepo,
        ISpecialtyRepository specialtyRepo,
        ILogger<ReportService> logger)
    {
        _universityRepository = universityRepo;
        _specialtyRepository = specialtyRepo;
        _logger = logger;
    }

    /// <summary>Запрос 1: Информация о выбранном ВУЗе.</summary>
    public University GetUniversityInfo(int universityId)
    {
        try
        {
            var university = _universityRepository.GetById(universityId);
            if (university == null)
            {
                _logger.LogWarning($"ВУЗ с ID {universityId} не найден");
                return null;
            }
            return university;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Ошибка при получении информации о ВУЗе {universityId}");
            throw;
        }
    }

    /// <summary>Запрос 2: Факультеты, кафедры и специальности ВУЗа.</summary>
    public object GetUniversityStructure(int universityId)
    {
        var university = GetUniversityInfo(universityId);
        if (university == null) return null;

        return new
        {
            UniversityName = university.Name,
            Faculties = university.Faculties.Select(f => new
            {
                f.Name,
                Departments = f.Departments.Select(d => d.Name),
                Specialties = f.Specialties.Select(s => s.Name)
            })
        };
    }

    /// <summary>Запрос 3: Топ-5 популярных специальностей (по количеству групп).</summary>
    public List<Specialty> GetTopSpecialties()
    {
        try
        {
            return _specialtyRepository.GetTopSpecialties(5);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при получении топ-5 специальностей");
            return new List<Specialty>();
        }
    }

    /// <summary>Запрос 4: ВУЗы с максимальным количеством кафедр (сортировка по названию).</summary>
    public List<University> GetUniversitiesByDepartmentCount()
    {
        return _universityRepository.GetAll()
            .OrderByDescending(u => u.Faculties.Sum(f => f.Departments.Count))
            .ThenBy(u => u.Name)
            .ToList();
    }

    /// <summary>Запрос 5: ВУЗы заданного типа собственности с количеством групп.</summary>
    public List<object> GetUniversitiesByProperty(UniversityProperty property)
    {
        return _universityRepository.GetAll()
            .Where(u => u.PropertyType == property)
            .Select(u => new
            {
                u.Name,
                u.Address,
                TotalGroups = u.Faculties.Sum(f => f.Specialties.Sum(s => s.GroupCount))
            })
            .ToList<object>();
    }

    /// <summary>Запрос 6: Статистика по типам собственности.</summary>
    public Dictionary<string, int> GetStatisticsByProperty()
    {
        var result = new Dictionary<string, int>();

        // Статистика по типам собственности учреждений
        var universityStats = _universityRepository.GetAll()
            .GroupBy(u => u.PropertyType)
            .ToDictionary(
                g => $"Учреждение ({g.Key})",
                g => g.Sum(u => u.Faculties.Sum(f => f.Departments.Count)));

        // Пример для зданий (нужна дополнительная модель Building в University)
        var buildingStats = new Dictionary<string, int>
        {
            { "Здание (Федеральное)", 10 },
            { "Здание (Муниципальное)", 15 }
        };

        return universityStats.Concat(buildingStats)
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }
}

public interface ILogger<T>
{
    void LogError(Exception ex, string v);
    void LogWarning(string v);
}