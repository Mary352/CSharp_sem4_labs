namespace Playgoer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ticket
    {
        public Guid Id { get; set; }

        public Guid PerformanceId { get; set; }

        public Guid SeatId { get; set; }

        public Guid UserId { get; set; }

        public virtual Performance Performance { get; set; }

        public virtual Seat Seat { get; set; }

        public virtual User User { get; set; }
    }
}
