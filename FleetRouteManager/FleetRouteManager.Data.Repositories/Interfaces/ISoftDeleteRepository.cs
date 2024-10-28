using FleetRouteManager.Data.Models.Interfaces;

namespace FleetRouteManager.Data.Repositories.Interfaces
{
    public interface ISoftDeleteRepository<T, TKey> : IRepository<T, TKey>
        where T : class, ISoftDeletable
    {

    }
}
