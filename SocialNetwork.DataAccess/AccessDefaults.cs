using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core.Defaults;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.DataAccess
{
    public abstract class AccessDefaults<TEntity, TAdd, TUpdate>
        where TEntity : class, IEntityDefaults
    {
        internal readonly AppDbContext context;

        internal AccessDefaults(AppDbContext context)
        {
            this.context = context;
        }

        protected abstract TEntity AddMapping(TAdd add);

        public virtual TEntity Add(TAdd add)
        {
            var toAdd = AddMapping(add);
            toAdd.CreatedOn = DateTime.Now;
            context.Add(toAdd);
            try
            {
                context.SaveChanges();
                return toAdd;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        protected abstract void UpdateMapping(TEntity toUpdate, TUpdate update);

        public virtual TEntity Update(TUpdate update, int id)
        {
            var toUpdate = Entity.SingleOrDefault(e => e.Id == id);
            UpdateMapping(toUpdate, update);
            toUpdate.RespondedOn = DateTime.Now;
            try { 
                context.SaveChanges();
                return toUpdate;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        protected abstract DbSet<TEntity> Entity { get; }

        public virtual TEntity Get(int id) 
            => Entity.AsNoTracking().SingleOrDefault(m => m.Id == id);

        public virtual bool Delete(int id)
        {
            context.Remove(Entity.Find(id));
            return context.SaveChanges() == 1;
        }

        public virtual bool Exists(int id) => Entity.Any(e => e.Id == id);

        public virtual IEnumerable<TEntity> Get() => Entity.AsNoTracking().AsEnumerable();

    }
}
