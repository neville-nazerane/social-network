using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core.Defaults;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.DataAccess
{
    abstract class AccessDefaults<TEntity, TAdd, TUpdate>
        where TEntity : class, IEntityDefaults
        where TUpdate : IUpdateDefaults
    {
        public AppDbContext Context { get; }

        protected AccessDefaults(AppDbContext context)
        {
            Context = context;
        }

        protected abstract TEntity AddMapping(TAdd add);

        public virtual TEntity Add(TAdd add)
        {
            var toAdd = AddMapping(add);
            Context.Add(toAdd);
            Context.SaveChanges();
            return toAdd;
        }

        protected abstract void UpdateMapping(TEntity toUpdate, TUpdate update);

        public virtual TEntity Update(TUpdate update)
        {
            var toUpdate = Entity.SingleOrDefault(e => e.Id == update.Id);
            UpdateMapping(toUpdate, update);
            Context.SaveChanges();
            return toUpdate;
        }

        protected abstract DbSet<TEntity> Entity { get; }

        public virtual TEntity Get(int id) 
            => Entity.AsNoTracking().SingleOrDefault(m => m.Id == id);

        public virtual bool Delete(int id)
        {
            Context.Remove(Entity.Find(id));
            return Context.SaveChanges() == 1;
        }

        public virtual bool Exists(int id) => Entity.Any(e => e.Id == id);

        public virtual IEnumerable<TEntity> Get() => Entity.AsNoTracking();

    }
}
