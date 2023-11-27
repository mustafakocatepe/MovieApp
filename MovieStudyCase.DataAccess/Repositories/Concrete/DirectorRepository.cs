using MovieStudyCase.DataAccess.Context;
using MovieStudyCase.DataAccess.Repositories.Abstract;
using MovieStudyCase.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieStudyCase.DataAccess.Repositories.Concrete
{
    public class DirectorRepository : EfRepository<Director>, IDirectorRepository
    {
        private readonly MovieAppContext _context;

        public DirectorRepository(MovieAppContext context) : base(context)
        {
            _context = context;
        }
       
    }

}
