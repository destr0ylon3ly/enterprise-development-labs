public class UniversityServiceTests
{
    private readonly UniversityService _service;
    private readonly UniversityRepository _repo = new();

    public UniversityServiceTests()
    {
        _service = new UniversityService(_repo);
    }

    [Fact]
    public void GetUniversitiesWithMaxDepartments_CalculatesCorrectly()
    {
        // Arrange
        var uni1 = new University
        {
            Name = "ВУЗ А",
            Faculties = new List<Faculty> { new() { Departments = new() { new(), new() } } }
        };
        var uni2 = new University
        {
            Name = "ВУЗ Б",
            Faculties = new List<Faculty> { new() { Departments = new() { new() } } }
        };
        _repo.Add(uni1);
        _repo.Add(uni2);

        // Act
        var result = _service.GetUniversitiesWithMaxDepartments();

        // Assert
        Assert.Equal("ВУЗ А", result[0].Name);
        Assert.Equal(2, result[0].Faculties.Sum(f => f.Departments.Count));
    }
}