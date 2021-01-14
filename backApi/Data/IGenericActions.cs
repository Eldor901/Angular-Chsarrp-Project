using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _.Data
{
    public interface IGenericActions
    {
        Task<IEnumerable<T>> GetAll<T>() where T: class;
        Task<T> GetOneElement<T>(int id) where T : class;
        
        
    }
}