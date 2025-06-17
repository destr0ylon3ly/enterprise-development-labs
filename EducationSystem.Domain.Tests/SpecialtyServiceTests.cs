public class SpecialtyServiceTests
{
    private readonly SpecialtyService _service;
    private readonly SpecialtyRepository _repo = new();

    public SpecialtyServiceTests()
    {
        _service = new SpecialtyService(_repo);
    }

    [Fact]
    public void FindByName_IsCaseInsensitive()
    {
        // Arrange
        _repo.Add(new Specialty { Name = "Информатика" });
        _repo.Add(new Specialty { Name = "Математика" });

        // Act
        var result = _service.FindByName("инф");

        // Assert
        Assert.Single(result);
        Assert.Equal("Информатика", result[0].Name);
    }
}