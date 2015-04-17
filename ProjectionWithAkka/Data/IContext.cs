using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IContext
    {
        IEnumerable<T> GetTableFor<T>(String collectionName);
        Boolean Save<T>(String collectionName, T item);
        Boolean Delete<T, I>(String collectionName, I id);
    }
}
