using PersonalLibraryManagement.Repositories;
using PersonalLibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibraryManagement.Services
{
    public class CirculationService : ICirculationService
    {
        private readonly ICirculationRepository _CirculationRepository;

        public CirculationService(ICirculationRepository CirculationRepository)
        {
            _CirculationRepository = CirculationRepository;
        }

        public async Task<int> AddCirculationAsync(Circulation Circulation)
        {
            return await _CirculationRepository.AddAsync(Circulation);  
        }
    }
}
