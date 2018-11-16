using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Services.Repositories
{
    public interface IGenericRepository<TEntity, TAdd, TUpdate>
    {

        TEntity Add(TAdd displayUser);

        TEntity Update(TUpdate displayUser);

        TEntity Get(int id);

        IEnumerable<TEntity> Get();

        bool Delete(int id);

        bool Exists(int id);

    }
}
