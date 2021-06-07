namespace lab_13.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lecturer
    {
        [Key]
        [StringLength(60)]
        public string SNP { get; set; }

        [Required]
        [StringLength(50)]
        public string Subject { get; set; }

        public DateTime ConsultDateTime { get; set; }

        public int StudNum { get; set; }

        public int MaxStudNum { get; set; }
    }
}
