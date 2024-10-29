﻿namespace FleetRouteManager.Data.Models.Interfaces
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedOn { get; set; }
    }
}
