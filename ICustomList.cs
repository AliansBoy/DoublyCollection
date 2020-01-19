using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoblyCollection
{
    public interface ICustomList<T>
    {
        void Add(T value);
        T this[int index] { get; }
        bool Delete(T value);   
    }
}
