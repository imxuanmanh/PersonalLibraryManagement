using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalLibraryManagement.Models;

namespace PersonalLibraryManagement.Services
{
    public interface ICirculationService
    {
        Task<int> AddCirculationAsync(Circulation Circulation);
    }
}
