using System;
using FluentAssertions;
using Hemelo.Foundation.Patterns.Creational.Builder.House;
using Xunit;

namespace Hemelo.Foundation.Tests.Patterns.Creational.Builder.House
{
    public class HouseBuilderTests
    {
        [Fact]
        public void ConcreteHouseBuilder_ShouldBuildAllPartsOfHouse()
        {
            // Arrange
            var builder = new ConcreteHouseBuilder();

            // Act
            builder.BuildFoundation();
            builder.BuildStructure();
            builder.BuildRoof();
            builder.BuildInterior();
            var house = builder.GetHouse();

            // Assert
            house.Foundation.Should().Be("Concrete foundation");
            house.Structure.Should().Be("Wooden structure");
            house.Roof.Should().Be("Shingle roof");
            house.Interior.Should().Be("Standard interior");
        }

        [Fact]
        public void GetHouse_ShouldReturnHouseAndResetBuilder()
        {
            // Arrange
            var builder = new ConcreteHouseBuilder();
            builder.BuildFoundation();
            var house1 = builder.GetHouse();

            // Act
            var house2 = builder.GetHouse();

            // Assert
            house1.Should().NotBeNull();
            house1.Foundation.Should().Be("Concrete foundation");
            house2.Should().NotBeNull();
            house2.Foundation.Should().BeNull(); // The new house should be empty
        }

        [Fact]
        public void Reset_ShouldCreateNewHouse()
        {
            // Arrange
            var builder = new ConcreteHouseBuilder();
            builder.BuildFoundation();
            var house1 = builder.GetHouse();

            // Act
            builder.Reset();
            var house2 = builder.GetHouse();

            // Assert
            house1.Should().NotBeNull();
            house2.Should().NotBeNull();
            house2.Foundation.Should().BeNull();
        }

        [Fact]
        public void Director_ShouldBuildMinimalViableHouse()
        {
            // Arrange
            var builder = new ConcreteHouseBuilder();
            var director = new Director(builder);

            // Act
            director.BuildMinimalViableHouse();
            var house = builder.GetHouse();

            // Assert
            house.Foundation.Should().Be("Concrete foundation");
            house.Structure.Should().Be("Wooden structure");
            house.Roof.Should().BeNull();
            house.Interior.Should().BeNull();
        }

        [Fact]
        public void Director_ShouldBuildFullFeaturedHouse()
        {
            // Arrange
            var builder = new ConcreteHouseBuilder();
            var director = new Director(builder);

            // Act
            director.BuildFullFeaturedHouse();
            var house = builder.GetHouse();

            // Assert
            house.Foundation.Should().Be("Concrete foundation");
            house.Structure.Should().Be("Wooden structure");
            house.Roof.Should().Be("Shingle roof");
            house.Interior.Should().Be("Standard interior");
        }

        [Fact]
        public void Director_BuildMinimalViableHouse_ShouldThrowExceptionIfBuilderNotSet()
        {
            // Arrange
            var director = new Director();

            // Act
            Action act = () => director.BuildMinimalViableHouse();

            // Assert
            act.Should().Throw<InvalidOperationException>().WithMessage("Builder not set.");
        }

        [Fact]
        public void Director_BuildFullFeaturedHouse_ShouldThrowExceptionIfBuilderNotSet()
        {
            // Arrange
            var director = new Director();

            // Act
            Action act = () => director.BuildFullFeaturedHouse();

            // Assert
            act.Should().Throw<InvalidOperationException>().WithMessage("Builder not set.");
        }
        
        [Fact]
        public void Director_ShouldBuildCustomHouse()
        {
            // Arrange
            var builder = new ConcreteHouseBuilder();
            var director = new Director(builder);

            // Act
            director.BuildCustomHouse(b =>
            {
                b.BuildFoundation();
                b.BuildRoof();
            });
            var house = builder.GetHouse();

            // Assert
            house.Foundation.Should().Be("Concrete foundation");
            house.Structure.Should().BeNull();
            house.Roof.Should().Be("Shingle roof");
            house.Interior.Should().BeNull();
        }

        [Fact]
        public void Director_BuildCustomHouse_ShouldThrowExceptionIfBuilderNotSet()
        {
            // Arrange
            var director = new Director();

            // Act
            Action act = () => director.BuildCustomHouse(b => b.BuildFoundation());

            // Assert
            act.Should().Throw<InvalidOperationException>().WithMessage("Builder not set.");
        }

        [Fact]
        public void Director_HouseProperty_ShouldReturnHouse()
        {
            // Arrange
            var builder = new ConcreteHouseBuilder();
            var director = new Director(builder);
            director.BuildFullFeaturedHouse();

            // Act
            var house = director.House;

            // Assert
            house.Should().NotBeNull();
            house.Foundation.Should().Be("Concrete foundation");
        }

        [Fact]
        public void Director_HouseProperty_ShouldThrowExceptionIfBuilderNotSet()
        {
            // Arrange
            var director = new Director();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => director.House);
        }
    }
}