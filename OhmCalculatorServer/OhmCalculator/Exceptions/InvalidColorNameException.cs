using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhmCalculator
{
    internal class ColorNotFoundException : Exception
    {
        public ColorNotFoundException(string message) : base(message)
        {
        }

    }
}
