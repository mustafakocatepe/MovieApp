using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using MovieStudyCase.DataAccess.Configurations;
using MovieStudyCase.Entities.Concrete;

namespace MovieStudyCase.DataAccess.Context;


public partial class MovieAppContext : DbContext
{
    public MovieAppContext(DbContextOptions<MovieAppContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Director> Directors { get; set; }
}
