public class SpecialtyRepositoryTests
{
    private readonly SpecialtyRepository _repository = new();

    [Fact]
    public void GetTopSpecialties_ReturnsOrderedByGroupCount()
    {
        // Arrange
        _repository.Add(new Specialty { Code = "01", GroupCount = 5 });
        _repository.Add(new Specialty { Code = "02", GroupCount = 10 });

        // Act
        var result = _repository.GetTopSpecialties(2);

        // Assert
        Assert.Equal(10, result[0].GroupCount);
        Assert.Equal(5, result[1].GroupCount);
    }

    [Fact]
    public void Add_IgnoresDuplicateCodes()
    {
        // Arrange
        var spec1 = new Specialty { Code = "09.03.01" };
        var spec2 = new Specialty { Code = "09.03.01" };

        // Act
        _repository.Add(spec1);
        _repository.Add(spec2);
        var result = _repository.GetAll();

        // Assert
        Assert.Single(result);
    }
}