using HP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HP.Services
{
    public interface IHPService<T>
    {
        Task<List<Character>> GetAll();
    }
}
