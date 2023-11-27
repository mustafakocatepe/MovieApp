using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStudyCase.Entities.Concrete;

namespace MovieStudyCase.DataAccess.Configurations;


    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
        builder.HasKey(t => t.MovieId);
        builder.Property(t => t.Name).HasMaxLength(100);
        builder.Property(t => t.Premier).HasMaxLength(50).IsRequired();
        builder.Property(t => t.Genre).IsRequired();
        builder.Property(t => t.CreateDate).HasDefaultValue(DateTime.Now).IsRequired();
        builder.Property(t => t.CreateUser).HasDefaultValue("admin").IsRequired();
        builder.Property(t => t.IsDeleted).HasDefaultValue(false).IsRequired();
        builder.HasData(Data());
        }
        
        IEnumerable<Movie> Data()
        {
            return new List<Movie>
            {
                new Movie
                {
                    MovieId = 1,
                    Name  = "Test Movie 1",
                    Premier = DateTime.Now,
                    Description = "Test Desc",
                    DirectorId = 1,
                    CreateDate = DateTime.Now,
                    CreateUser = "MustafaKocatepe",
                    UpdateUser = "MustafaKocatepe",
                    IsDeleted = false,
                }
            };
        }
    }
