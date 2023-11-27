using MovieStudyCase.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStudyCase.Services.Dto.Movie
{
    public class UpdateMovieDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
