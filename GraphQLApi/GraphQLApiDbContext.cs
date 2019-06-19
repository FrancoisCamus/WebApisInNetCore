using Microsoft.EntityFrameworkCore;
using Shared;

namespace GraphQLApi
{
    public class GraphQLApiDbContext : SharedDbContext
    {
        public GraphQLApiDbContext(DbContextOptions options)
          : base(options)
        {
        }
    }
}
