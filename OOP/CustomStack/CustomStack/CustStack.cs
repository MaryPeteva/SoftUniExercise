using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStack
{
    public class StackOfStrings:Stack<string>
    {
        public bool IsEmpty() 
        {
            return this.Any();
        }

        public Stack<string> AddRange(IEnumerable<string> input) 
        {
            foreach (var item in input) 
            {
                this.Push(item);
            }

            return this;
        }
    }
}
