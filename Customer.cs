using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Don_t_Give_Up_You_Can_Do_it
{
    class Customer
    {
        private int custID;
        private string custName;
        private string phoneNum;
        private string address;

        private ArrayList folder = new ArrayList();

        public Customer(int id, string name, string phone, string ads)
        {
            custID = id; custName = name; phoneNum = phone; address = ads;
        }

        public int CustID { get { return custID; } }
        public string CustName { get { return custName; } }
        public string PhoneNum { get { return phoneNum; } }
        public string Address { get { return address; } }
    }
}
