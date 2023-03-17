using System;
using FluentAssertions;
using Xunit;

namespace Exercises
{
    public class Ex04_StringTests
    {
        [Fact]
        public void A_default_person_has_a_non_empty_star_sign()
        {
            // Arrange
            var person = new Person();

            // Act
            string starSign = person.GetStarSign();

            // Assert
            starSign.Should().NotBeEmpty();
        }

        [Fact]
        public void This_test_framework_ignoring_casing_is_xunit()
        {
            // Arrange
            string expectedFrameworkName = "xunit";

            // Act
            string frameworkName = GetTestFramework();

            // Assert
            frameworkName.Should().BeEquivalentTo(expectedFrameworkName);
        }

        [Fact]
        public void Donald_Duck_has_a_nephew_named_Louie()
        {
            // Arrange
            string expectedNephew = "Louie";

            // Act
            string[] nephews = GetNephewsOfDonaldDuck();

            // Assert
            // If 'a' means exactly one:
            nephews.Should().ContainSingle(e => e == expectedNephew);
            // If 'a' means at least one:
            nephews.Should().Contain(expectedNephew);
        }

        [Fact]
        public void The_Danish_alphabeth_has_29_letters()
        {
            // Arrange
            int expectedLength = 29;

            // Act
            string alphabet = GetDanishAlphabeth();

            // Assert
            alphabet.Should().HaveLength(expectedLength);
        }

        [Fact]
        public void The_error_message_matches_Foo_and_Bar_in_that_order()
        {
            // Act
            string errorMessage = GetErrorMessage();

            // Assert
            // Can we assume the words in errorMessage is always separated with spaces?
            errorMessage.Split(' ').Should().ContainInOrder("Foo", "Bar");
            // If not, we can do this instead:
            new[]
            {
                errorMessage.IndexOf("Foo", StringComparison.Ordinal),
                errorMessage.IndexOf("Bar", StringComparison.Ordinal)
            }.Should().BeInAscendingOrder();
        }

        #region Helpers
        private class Person
        {
            public string GetStarSign() => "Taurus";
        }

        public static string GetTestFramework() => "xUniT";

        public static string[] GetNephewsOfDonaldDuck() => new[] { "Huey", "Louie", "Dewey" };

        public static string GetDanishAlphabeth() => "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ";

        public static string GetErrorMessage() => "Yada Yada Foo Yada Yada Bar Yada Yada";
        #endregion
    }
}
