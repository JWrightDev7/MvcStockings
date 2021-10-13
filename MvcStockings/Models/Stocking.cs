using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcStockings.Models
{
    public class Stocking
    {
        public int Id { get; set; }
        [StringLength(25, MinimumLength =3)] //Sets the max and min length of the string
        [Required] //Makes the field Required
        public string Name { get; set; }
        [StringLength(25, MinimumLength =3)] //Sets the max and min length of the string
        [Required] //Makes the field Required
        public string Type { get; set; }
        [StringLength(25, MinimumLength =3)] //Sets the max and min length of the string
        [Required] //Makes the field Required
        public string Material { get; set; }
        [Column(TypeName ="double(18,2")] //Sets the formatting for the number to 2 digits after the decimal
        public double Price { get; set; }
        [Range(1, 5)] //Sets a max value of 5 and minimum value of 1
        public int Review { get; set; }
    }
}
