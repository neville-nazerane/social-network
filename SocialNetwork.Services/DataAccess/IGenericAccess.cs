using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Services.DataAccess
{
    public interface IGenericAccess<TEntity, TAdd, TUpdate>
    {

        TEntity Add(TAdd displayUser);

        TEntity Update(TUpdate displayUser, int id);

        TEntity Get(int id);

        IEnumerable<TEntity> Get();

        bool Exists(int id);

        bool Delete(int id);

    }
}
