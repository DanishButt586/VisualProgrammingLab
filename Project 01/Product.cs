//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inventory_Management_System_SFML
{
    using System;
    using System.Collections.Generic;

    public partial class Product
    {
        public int ProductID { get; set; } // Should be an integer
        public string Name { get; set; }
        public string SKU { get; set; }
        public string Barcode { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; } // Should be an integer
        public decimal UnitPrice { get; set; } // Should be a decimal
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
