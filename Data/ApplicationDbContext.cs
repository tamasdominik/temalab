using Temalab_Fitness.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Temalab_Fitness.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<Temalab_Fitness.Models.Profile> Profile { get; set; }
        public DbSet<Temalab_Fitness.Models.Exercise> Exercise { get; set; }
        public DbSet<Temalab_Fitness.Models.MileStone> MileStone { get; set; }
        public DbSet<Temalab_Fitness.Models.MileStone_Connection> MileStone_Connection { get; set; }
        public DbSet<Temalab_Fitness.Models.Workout> Workout { get; set; }
        public DbSet<Temalab_Fitness.Models.Workout_Connection> Workout_Connection { get; set; }

        public DbSet<Temalab_Fitness.Models.ApplicationUser> ApplicationUser{ get; set; }

    }
}
