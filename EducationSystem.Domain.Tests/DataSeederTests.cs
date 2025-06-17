public class DataSeederTests
{
    [Fact]
    public void Seed_CreatesValidTestData()
    {
        // Arrange
        var uniRepo = new UniversityRepository();
        var specRepo = new SpecialtyRepository();

        // Act
        DataSeeder.Seed(uniRepo, specRepo);
        var universities = uniRepo.GetAll();
        var specialties = specRepo.GetAll();

        // Assert
        Assert.NotEmpty(universities);
        Assert.NotEmpty(specialties);
        Assert.True(universities[0].Faculties.Count > 0);
    }
}