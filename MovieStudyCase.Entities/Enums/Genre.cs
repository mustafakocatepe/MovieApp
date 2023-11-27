using System.ComponentModel.DataAnnotations;

namespace MovieStudyCase.Entities.Enums;

public enum Genre
{
    [Display(Name = "Drama")]
    Drama = 0,
    [Display(Name = "Horror")]
    Horror = 1,
    [Display(Name = "Romance")]
    Romance = 2,
    
}