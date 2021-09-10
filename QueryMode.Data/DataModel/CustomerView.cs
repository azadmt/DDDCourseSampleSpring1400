using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryModel.Data.DataModel
{
    public  class CustomerView
    {
        public Guid Id { get;  set; }
        public string Name { get;  set; }
        public string NationalCode { get;  set; }

        public string HomeAddress_Province { get;  set; }
        public string HomeAddress_City { get;  set; }
        public string HomeAddress_Street { get;  set; }

        public string WorkAddress_Province { get;  set; }
        public string WorkAddress_City { get;  set; }
        public string WorkAddress_Street { get;  set; }

    }
}
