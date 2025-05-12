using FluentAssertions;
using LSL.Evaluation.Core.Tests.TestFactories;
using NUnit.Framework;

namespace LSL.Evaluation.Core.Tests;

public class FactoryTests
{
    [Test]
    public void GivenAJintFactoryThatHasNoSettings_ThenItShouldReturnAnEvaluator()
    {
        // Arrange
        var sut = new JintEvaluatorFactory()
            .Build(c =>
            {
                c.AddCode("var value = 12");
            });

        // Act
        var result = sut.Evaluate<int>("value + 2");

        // Assert
        result.Should().Be(14);
    }

    [Test]
    public void GivenAJintFactoryThatHasSettings_ThenItShouldReturnAnEvaluator()
    {
        // Arrange
        var sut = new JintEvaluatorFactoryWithSettings()
            .Build(c =>
            {
                c.AddCode("var value = 12");
                c.SetValues([
                    new("value3", 123), 
                    new("by2", (int i) => i * 2)
                ]);
                
                c.Configure(s =>
                {
                    s.ConfigureEngine(e => e.Execute("var value2 = 2"));
                });
            });

        // Act
        var result = sut.Evaluate<int>("value + by2(value2) + value3");

        // Assert
        result.Should().Be(139);
    }        
}