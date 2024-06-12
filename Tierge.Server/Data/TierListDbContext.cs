using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;
using System.Runtime.CompilerServices;
using Tierge.Server.Models;

namespace Tierge.Server.Data
{
    public class TierListDbContext : DbContext
    {
        public TierListDbContext(DbContextOptions<TierListDbContext> options)
            : base(options)
        {
        }

        public DbSet<TierList> UserTierLists { get; init; }

        public DbSet<TierListTemplate> Templates { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TierList>().ToCollection("userTierLists");
            builder.Entity<TierListTemplate>().ToCollection("templateTierLists");
        }
    }
}
