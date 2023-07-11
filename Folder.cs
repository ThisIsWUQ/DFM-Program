using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Don_t_Give_Up_You_Can_Do_it //:)
{
    class Folder
    {
        private int duration;
        private DateTime storedDate;
        private DateTime dueDate;

        private string type;
        private string zone;
        private int folderNO;

        private ArrayList files;

        private Customer customer;

        public Folder(int months,string t, string z, int fNO, Customer c)
        {
            duration = months;
            type = t;
            storedDate = DateTime.Today;
            dueDate = storedDate.AddMonths(months);
            zone = z; folderNO = fNO;
            files = new ArrayList();
            customer = c;
        }

        public void RecordFile(File f)
        {
            files.Add(f);
        }   
      

        public void RetriveFile(int fno)
        {
            int index = 100000;
            for (int i = 0; i < files.Count; i++)
            {
                if (fno == ((File)files[i]).RefNO)
                {
                    File f = ((File)files[i]);
                    index = files.IndexOf(f);
                } break;
            }
            files.RemoveAt(index);
        }

        public void AccessFiles()
        {
            for (int i = 0; i < files.Count; i++)
            {
                Console.WriteLine("File NO.: " + ((File)files[i]).RefNO
                    + " Name: " + ((File)files[i]).Name);
            }
        }

        public string GetFileName(int no)
        {
            for (int i = 0; i < files.Count; i++)
            {
                if (no == ((File)files[i]).RefNO)
                {

                    return ((File)files[i]).Name;
                }
            }
            return "none";
        }

        public double CostFee(string t, int duration)
        {
            double cost = 0;
            if (t == "General")
            {
                if (files.Count > 6) { cost = 500 * duration; }
                else if (files.Count >= 4) { cost = 250 * duration; }
                else { cost = 125 * duration; }
                return cost;
            }
            else if (t == "Legal")
            {
                if (files.Count > 6) { cost = 1000 * duration; }
                else if (files.Count >= 4) { cost = 500 * duration; }
                else { cost = 250 * duration; }
                return cost;
            }
            else { return cost; }
        }

        public int Duration { get { return duration; } }
        public DateTime StoredDate { get { return storedDate; } }
        public DateTime DuedDate { get { return dueDate; } }

        public string Zone { get { return zone; } }
        public int FolderNO { get { return folderNO; } }

        public int CustID { get { return customer.CustID; } }
    }
}
