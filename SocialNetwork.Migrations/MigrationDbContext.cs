using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core.Entities;
using SocialNetwork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Migrations
{
    public class MigrationDbContext : AbstractDbContext
    {
        public MigrationDbContext(DbContextOptions<MigrationDbContext> options) 
                : base(options)
        {
        }

    }

}
