using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace MvcWebOrder.Areas 
{
    public partial class Model_SalesOrder
    {
        public  static SalesOrder CreateOrder()
        {
            return new SalesOrder()
            {
                BillCode = DateTime.Now.ToString("yyyyMMdd"), 
                OrderDate = DateTime.Now
            };
        }
    }
}
