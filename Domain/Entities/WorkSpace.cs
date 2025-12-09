using System;

namespace Domain.Entities;

public class Workspace
{
    public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int LocationId { get; set; }
        public Location? Location { get; set; }

        public int WorkspaceTypeId { get; set; }
        public WorkspaceType? WorkspaceType { get; set; }

        public ICollection<Facility>? Facilities { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
        public ICollection<Review>? Reviews { get; set; }
}
