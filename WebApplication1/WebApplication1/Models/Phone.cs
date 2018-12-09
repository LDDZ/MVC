using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Phone
    {
        public string PhoneName
        {
            get;
            set;
        }
        public string PhonePrice
        {
            get;
            set;
        }
        public override string ToString()
        {

            return this.PhoneName + "--￥" + this.PhonePrice;
        }
    }
}