﻿using APIforPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIforPI.Infrastracture.Dto
{
    public class SetsDto
    {
        public string Name { get; set; }
        public List<Sushi> Sushis { get; set; }
        public int Price { get; set; }
        public int TotalAmount { get; set; }
    }
}
