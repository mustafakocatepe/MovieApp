using MovieStudyCase.DataAccess.Repositories.Abstract;
using MovieStudyCase.DataAccess.Repositories.Concrete;
using MovieStudyCase.Entities.Concrete;
using MovieStudyCase.Services.Abstract;
using MovieStudyCase.Services.Dto.Movie;
using MovieStudyCase.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStudyCase.Services.Concrete
{
    public class DirectorService : IDirectorService
    {
        private readonly IDirectorRepository _directorRepository;

        public DirectorService(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }

        public void CheckDirectorById(int id)
        {
            if (!_directorRepository.Any(x => x.DirectorId == id && !x.IsDeleted))
                throw new StateException("Yönetmen bulunamadı.");
           
        }

    }
}
