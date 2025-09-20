using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hemelo.Foundation.Patterns.Creational.Builder.House
{
    /// <summary>
    /// Represents a house with properties describing its foundation, structure, roof, and interior.
    /// </summary>
    /// <remarks>Use the properties of this class to specify or retrieve details about the main components of
    /// a house. This class is intended for modeling basic architectural features and does not include behavior or
    /// validation logic.</remarks>
    public class House
    {
        public string? Foundation { get; set; }

        public string? Structure { get; set;  }

        public string? Roof { get; set; }

        public string? Interior { get; set; }
    }
}
