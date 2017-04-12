using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class DataGrid
    {
        public int total { get; set; }
        public object rows { get; set; }
        public object footer { get; set; }

        public List<Column> title { get; set; }
    }

    public class Column
    {
        public string field { get; set; }
        public string title { get; set; }

        public bool checkbox { get; set;}
    }
}
