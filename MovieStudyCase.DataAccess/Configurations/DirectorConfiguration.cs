using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStudyCase.Entities.Concrete;

namespace MovieStudyCase.DataAccess.Configurations;


    public class DirectorConfiguration : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
        builder.HasKey(t => t.DirectorId);
        builder.Property(t => t.Name).HasMaxLength(100);
        builder.Property(t => t.CreateDate).HasDefaultValue(DateTime.Now).IsRequired();
        builder.Property(t => t.CreateUser).HasDefaultValue("admin").IsRequired();
        builder.HasData(Data());
        }
        
        IEnumerable<Director> Data()
        {
            return new List<Director>
            {
                new Director
                {
                    DirectorId = 1,
                    Name  = "Director 1",     
                    CreateDate = DateTime.Now,
                    CreateUser = "MustafaKocatepe",
                    UpdateUser = "MustafaKocatepe",
                    IsDeleted = false,
                },
                 new Director
                {
                    DirectorId = 2,
                    Name  = "Director 2",
                    CreateDate = DateTime.Now,
                    CreateUser = "MustafaKocatepe",
                    UpdateUser = "MustafaKocatepe",
                    IsDeleted = false,
                },
                  new Director
                {
                    DirectorId = 3,
                    Name  = "Director 3",
                    CreateDate = DateTime.Now,
                    CreateUser = "MustafaKocatepe",
                    UpdateUser = "MustafaKocatepe",
                    IsDeleted = false,

                },
                   new Director
                {
                    DirectorId = 4,
                    Name  = "Director 4",
                    CreateDate = DateTime.Now,
                    CreateUser = "MustafaKocatepe",
                    UpdateUser = "MustafaKocatepe",
                    IsDeleted = false,

                },
                    new Director
                {
                    DirectorId = 5,
                    Name  = "Director 5",
                    CreateDate = DateTime.Now,
                    CreateUser = "MustafaKocatepe",
                    UpdateUser = "MustafaKocatepe",
                    IsDeleted = false,

                },
                     new Director
                {
                    DirectorId = 6,
                    Name  = "Director 6",
                    CreateDate = DateTime.Now,
                    CreateUser = "MustafaKocatepe",
                    UpdateUser = "MustafaKocatepe",
                    IsDeleted = false,

                },
            };
        }
    }
