using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz10
{
    public class BankruptException : Exception
    {
        public BankruptException(string message) : base(message) { }
    }
}
