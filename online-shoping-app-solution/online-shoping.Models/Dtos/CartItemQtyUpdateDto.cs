﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_shoping.Models.Dtos
{
    public class CartItemQtyUpdateDto
    {
        public int CartItemId { get; set; }
        public int Qty { get; set; }
    }
}
