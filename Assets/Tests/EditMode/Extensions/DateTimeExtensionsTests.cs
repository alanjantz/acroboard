using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DateTimeExtensionsTests
{
    [Test]
    [TestCase("2020-11-01", "2020-11-01T00:00:00.0000000")]
    [TestCase("2021-02-28", "2021-02-28T00:00:00.0000000")]
    public void DateTimeExtensions_ToFullString_ShouldReturnExpectedResult(DateTime dateTime, string expectedResult)
    {
        // Act
        var result = DateTimeExtensions.ToFullString(dateTime);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}
