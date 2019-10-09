using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary
{
    public class Movie : Product
    {
        public enum RatingList { G, PG, PG13, R }
        public string Runtime { get; set; }


    }
}
