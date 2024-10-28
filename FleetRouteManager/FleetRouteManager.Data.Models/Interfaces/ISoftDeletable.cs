namespace FleetRouteManager.Data.Models.Interfaces
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedAt { get; set; }
    }
}
