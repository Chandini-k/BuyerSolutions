﻿using System;
using System.Collections.Generic;

namespace BUYERDBENTITY.Entity
{
    public partial class Items
    {
        public Items()
        {
            Cart = new HashSet<Cart>();
            Purchasehistory = new HashSet<Purchasehistory>();
        }

        public int Id { get; set; }
        public int? Categoryid { get; set; }
        public int? Subcategoryid { get; set; }
        public int? Price { get; set; }
        public string Itemname { get; set; }
        public string Description { get; set; }
        public int? Stockno { get; set; }
        public string Remarks { get; set; }
        public byte[] Imagename { get; set; }

        public virtual Category Category { get; set; }
        public virtual SubCategory Subcategory { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Purchasehistory> Purchasehistory { get; set; }
    }
}
