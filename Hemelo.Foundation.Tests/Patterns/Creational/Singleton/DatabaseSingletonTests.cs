using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Hemelo.Foundation.Patterns.Creational.Singleton;

namespace Hemelo.Foundation.Tests.Patterns.Creational.Singleton
{
    public class DatabaseSingletonTests
    {
        [Fact]
        public void Instance_ShouldReturnSameObject()
        {
            var instance1 = DatabaseSingleton.Instance;
            var instance2 = DatabaseSingleton.Instance;

            instance1.Should().BeSameAs(instance2);
        }

        [Fact]
        public void Instance_ShouldNotBeNull()
        {
            var instance = DatabaseSingleton.Instance;
            instance.Should().NotBeNull();
        }

        [Fact]
        public async Task Instance_ShouldBeThreadSafe()
        {
            DatabaseSingleton?[] results = new DatabaseSingleton?[10];

            await Task.WhenAll(
                Enumerable.Range(0, 10)
                    .Select(i => Task.Run(() => results[i] = DatabaseSingleton.Instance))
            );

            results.Should().OnlyContain(i => i == DatabaseSingleton.Instance);
            results.Distinct().Count().Should().Be(1);
        }

        [Fact]
        public async Task Instance_Lock_ShouldPreventMultipleInstances()
        {
            const int threadCount = 100;
            var instances = new DatabaseSingleton?[threadCount];

            await Task.WhenAll(
                Enumerable.Range(0, threadCount)
                    .Select(i => Task.Run(() => instances[i] = DatabaseSingleton.Instance))
            );

            // All instances should be the same
            instances.Should().OnlyContain(i => i == DatabaseSingleton.Instance);
            instances.Distinct().Count().Should().Be(1);
        }
    }
}