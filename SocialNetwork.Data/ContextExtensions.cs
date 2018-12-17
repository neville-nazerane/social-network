using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SocialNetwork.Data
{

    static class ContextExtensions
    {

        public static RelationBuilder<TEntity> RelationBuilder<TEntity>(this EntityTypeBuilder<TEntity> entity)
            where TEntity : class
            => new RelationBuilder<TEntity>(entity);

    }
}
