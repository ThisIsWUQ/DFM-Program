using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Don_t_Give_Up_You_Can_Do_it
{
    class File
    {
        private int refNO;
        private int sheetQuan;
        private string name;

        public File(int NO, int quan, string n)
        {
            refNO = NO;
            sheetQuan = quan;
            name = n;
        }

        public int RefNO { get { return refNO; } }
        public int SheetQuan { get { return sheetQuan; } }
        public string Name { get { return name; } }
    }
}
