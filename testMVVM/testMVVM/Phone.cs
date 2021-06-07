namespace testMVVM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Phone
    {
        [Key]
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Company { get; set; }

        public int? Price { get; set; }
    }
}
