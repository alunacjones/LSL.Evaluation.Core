using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace LSL.Evaluation.Core.Tests;

public class EnumerableExtensionsTests
{
    [Test]
    public void GivenACallWithANonNullAction_ThenItShouldExecuteTheActionAgainstEachItem()
    {
        // Arrange
        IEnumerable<int> values = new[] { 1, 2, 3 };
        var evaluatedItems = new List<int>();

        // Act
        values.ForEach(i => evaluatedItems.Add(i));

        // Assert
        values.Should().BeEquivalentTo(evaluatedItems, c => c.WithStrictOrdering());
    }

    [Test]
    public void GivenACallWithANullAction_ThenItShouldThrowTheExpectedException()
    {
        // Arrange
        IEnumerable<int> values = new[] { 1, 2, 3 };

        // Act & Assert
        new Action(() => values.ForEach(null))
            .Should()
            .Throw<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'action')");
    }

    [Test]
    public void GivenACallWithANullEnumerable_ThenItShouldThrowTheExpectedException()
    {
        // Arrange
        IEnumerable<int> values = null;

        // Act & Assert
        new Action(() => values.ForEach(null))
            .Should()
            .Throw<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'items')");
    }        
}