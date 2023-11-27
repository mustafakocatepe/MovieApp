using MovieStudyCase.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStudyCase.Services.Dto.Movie
{
    public class CreateMovieDto
    {
        public string Name { get; set; }
        public DateTime Premier { get; set; }
        public Genre Genre { get; set; }
        public string Description { get; set; }
        public int DirectorId { get; set; }
    }
}
