//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lab26Coffee.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Item
    {
        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description required")]
        public string Description { get; set; }

        [Range(1, 1000, ErrorMessage = "Quantity isn't in range")]
        public int Quantity { get; set; }

        [Range(0.01, 150, ErrorMessage = "Price isn't in range")]
        public string Price { get; set; }

        public int ID { get; set; }

    }
}