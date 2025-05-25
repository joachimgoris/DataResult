using System.Data;

namespace DataResult.Tests;

public class DataResultTTests
{
    [Test]
    public void ShouldCreateValidSuccessDataResultWithEntity_WhenValidObjectPassed()
    {
        // Arrange
        var containedObject = "This is the result I need";

        // Assert
        var dataResult = DataResult<string>.Success(containedObject);

        // Assert
        Assert.That(dataResult, Is.Not.Null);
        Assert.That(dataResult.Entity, Is.InstanceOf<string>());
        Assert.That(dataResult.Entity, Is.EqualTo(containedObject));
    }
}