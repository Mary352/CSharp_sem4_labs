namespace Playgoer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Performance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Performance()
        {
            Tickets = new HashSet<Ticket>();
        }

        public Guid Id { get; set; }

        [Required]
        public string PName { get; set; }

        [Required]
        [StringLength(35)]
        public string Genre { get; set; }

        public int Age { get; set; }

        public int Duration { get; set; }

        public DateTime Date_time { get; set; }

        public Guid TheaterId { get; set; }

        public virtual Theater Theater { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
