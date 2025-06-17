public class UniversityRepositoryTests
{
    private readonly UniversityRepository _repository = new();

    [Fact]
    public void Add_ShouldAddUniversity()
    {
        // Arrange
        var university = new University { Id = 1, Name = "Ã√”" };

        // Act
        _repository.Add(university);
        var result = _repository.GetById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Ã√”", result.Name);
    }

    [Fact]
    public void GetById_ReturnsNull_WhenNotExists()
    {
        // Act
        var result = _repository.GetById(999);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetAll_ReturnsUniversitiesInInsertionOrder()
    {
        // Arrange
        _repository.Add(new University { Id = 1, Name = "¬”« ¿" });
        _repository.Add(new University { Id = 2, Name = "¬”« ¡" });

        // Act
        var result = _repository.GetAll();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal("¬”« ¿", result[0].Name);
    }
}