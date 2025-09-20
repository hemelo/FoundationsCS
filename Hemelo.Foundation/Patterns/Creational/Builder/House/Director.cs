using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemelo.Foundation.Patterns.Creational.Builder.House
{
    /// <summary>
    /// Director class that defines the order in which to call building steps to construct different types of houses.
    /// Ensures that the construction process is followed correctly.
    /// Its like an orchestra conductor who ensures that all parts of the construction process are executed in the right order.
    /// </summary>
    public class Director(IHouseBuilder? builder = null)
    {
        private IHouseBuilder? _builder = builder;

        public IHouseBuilder? Builder
        {
            set => _builder = value;
        }

        /// <summary>
        /// Coordinates the building of a minimal viable house by calling only the essential building steps.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public void BuildMinimalViableHouse()
        {
            if (_builder == null) 
                throw new InvalidOperationException("Builder not set.");

            _builder?.BuildFoundation();
            _builder?.BuildStructure();
        }

        /// <summary>
        /// Coordinates the building of a full-featured house by calling all the building steps in the correct order.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public void BuildFullFeaturedHouse()
        {
            if (_builder == null)
                throw new InvalidOperationException("Builder not set.");

            _builder?.BuildFoundation();
            _builder?.BuildStructure();
            _builder?.BuildRoof();
            _builder?.BuildInterior();
        }

        /// <summary>
        /// Coordinates the building of a custom house by accepting a delegate that defines the specific building steps to be executed.
        /// </summary>
        /// <param name="buildAction"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void BuildCustomHouse(Action<IHouseBuilder> buildAction)
        {
            if (_builder == null) 
                throw new InvalidOperationException("Builder not set.");

            buildAction(_builder);
        }

        public House House => _builder?.GetHouse() ?? throw new InvalidOperationException("Builder not set.");
    }
}
