using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemelo.Foundation.Patterns.Creational.Builder.House
{
    /// <summary>
    /// Concrete implementation of the IHouseBuilder interface for constructing a standard house.
    /// </summary>
    public class ConcreteHouseBuilder : IHouseBuilder
    {
        private House _house = new();

        public void BuildFoundation() => _house.Foundation = "Concrete foundation";
        public void BuildStructure() => _house.Structure = "Wooden structure";
        public void BuildRoof() => _house.Roof = "Shingle roof";
        public void BuildInterior() => _house.Interior = "Standard interior";
        public void Reset() => _house = new House();
        public House GetHouse()
        {
            House result = _house;
            _house = new House();
            return result;
        }
    }
}
