using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SocialNetwork.Data
{
    class RelationBuilder<TEntity>
        where TEntity : class
    {
        private readonly EntityTypeBuilder<TEntity> entity;

        public RelationBuilder(EntityTypeBuilder<TEntity> entity)
        {
            this.entity = entity;
        }


        public RelationBuilder<TEntity> OneToOneRestrict<TRelated>(Expression<Func<TRelated, TEntity>> navigationExpression)
            where TRelated : class
        {
            entity.HasOne<TRelated>().WithOne(navigationExpression).OnDelete(DeleteBehavior.Restrict);
            return this;
        }

        public RelationBuilder<TEntity> OneToOneSetNull<TRelated>(Expression<Func<TRelated, TEntity>> navigationExpression)
            where TRelated : class
        {
            entity.HasOne<TRelated>().WithOne(navigationExpression).OnDelete(DeleteBehavior.SetNull);
            return this;
        }

        public RelationBuilder<TEntity> OneToManyRestrict<TRelated>(Expression<Func<TRelated, TEntity>> navigationExpression)
            where TRelated : class
        {
            entity.HasMany<TRelated>().WithOne(navigationExpression).OnDelete(DeleteBehavior.Restrict);
            return this;
        }

        public RelationBuilder<TEntity> OneToManySetNull<TRelated>(Expression<Func<TRelated, TEntity>> navigationExpression)
            where TRelated : class
        {
            entity.HasMany<TRelated>().WithOne(navigationExpression).OnDelete(DeleteBehavior.SetNull);
            return this;
        }

    }
}
