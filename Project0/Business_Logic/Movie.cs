﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary
{
    public class Movie : Product
    {
        public int InventoryAmount { get; set; }

        public string Title { get; set; }
    }
}
