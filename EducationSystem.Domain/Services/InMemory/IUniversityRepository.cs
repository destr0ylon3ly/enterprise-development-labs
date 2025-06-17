/// <summary>
/// Интерфейс репозитория для работы с ВУЗами.
/// </summary>
public interface IUniversityRepository
{
    University GetById(int id);
    List<University> GetAll();
    void Add(University university);
}