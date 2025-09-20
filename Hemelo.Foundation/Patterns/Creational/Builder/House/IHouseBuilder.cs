using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemelo.Foundation.Patterns.Creational.Builder.House
{
    /// <summary>
    /// Defines the interface for building different parts of a house.
    /// </summary>
    public interface IHouseBuilder
    {
        /// <summary>
        /// Builds the foundation of the house.
        /// </summary>
        void BuildFoundation();

        /// <summary>
        /// Builds the main structure of the house.
        /// </summary>
        void BuildStructure();

        /// <summary>
        /// Builds the roof of the house.
        /// </summary>
        void BuildRoof();

        /// <summary>
        /// Builds the interior of the house.
        /// </summary>
        void BuildInterior();

        /// <summary>
        /// Builds the interior of the house.
        /// </summary>
        /// <returns></returns>
        House GetHouse();
    }


}
