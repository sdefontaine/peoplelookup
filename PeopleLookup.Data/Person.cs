using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;

namespace PeopleLookup.Data
{


    [Table("Person")]
    public partial class Person
    {
        [Key]
        public long ID { get; set; }

        [StringLength(50)]
        public string First { get; set; }

        [StringLength(50)]
        public string Last { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        public int Age { get; set; }

        [StringLength(200)]
        public string Interests { get; set; }

        [StringLength(50)]
        public string Picture { get; set; }



    }
}
