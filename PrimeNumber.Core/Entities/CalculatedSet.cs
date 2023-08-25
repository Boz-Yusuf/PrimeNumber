using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumber.Core.Entities
{
    public class CalculatedSet
    {
        public int Id { get; set; }
        public int BiggestPrimeNumber { get; set; }
        public List<int> NumberSet { get; set; }
    }
}
