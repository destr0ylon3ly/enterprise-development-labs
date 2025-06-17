/// <summary>
/// Класс для заполнения системы начальными тестовыми данными.
/// </summary>
public static class DataSeeder
{
    /// <summary>
    /// Инициализирует репозитории тестовыми данными.
    /// </summary>
    public static void Seed(IUniversityRepository universityRepo, ISpecialtyRepository specialtyRepo)
    {
        // Создаем специальности
        var specialties = new List<Specialty>
        {
            new Specialty { Code = "09.03.01", Name = "Информатика", GroupCount = 15 },
            new Specialty { Code = "38.03.05", Name = "Бизнес-информатика", GroupCount = 8 }
        };
        specialties.ForEach(s => specialtyRepo.Add(s));

        // Создаем ректоров
        var rectors = new List<Rector>
        {
            new Rector { FullName = "Иванов А.А.", Degree = "Доктор наук", Title = "Профессор" },
            new Rector { FullName = "Петрова В.М.", Degree = "Кандидат наук", Title = "Доцент" }
        };

        // Создаем вузы с факультетами
        var universities = new List<University>
        {
            new University
            {
                Id = 1,
                Name = "МГУ",
                PropertyType = UniversityProperty.Municipal,
                Rector = rectors[0],
                Faculties = new List<Faculty>
                {
                    new Faculty
                    {
                        Name = "Факультет компьютерных наук",
                        Departments = new List<Department>
                        {
                            new Department { Name = "Кафедра алгоритмов" }
                        },
                        Specialties = specialties.Take(1).ToList()
                    }
                }
            }
        };
        universities.ForEach(u => universityRepo.Add(u));
    }
}