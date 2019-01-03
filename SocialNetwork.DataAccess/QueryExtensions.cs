using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.DataAccess
{
    static class QueryExtensions
    {

        internal static IQueryable<T> AsTracking<T>(this IQueryable<T> query, bool tracking)
            where T : class
        {
            if (tracking) return query;
            else return query.AsNoTracking();
        }

    }
}
