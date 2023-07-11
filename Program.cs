using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Don_t_Give_Up_You_Can_Do_it
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList folder = new SortedList();
            int folderNO = 1;

            SortedList customer = new SortedList();
            int custID = 1;

            int contractNO = 1;

            Console.WriteLine("Menu\n1. Collect Files\n2. Access and Retrive\n3. Quit");
            Console.Write("\nChoose -> "); int choice = int.Parse(Console.ReadLine());

            while (choice != 3)
            {
                if (choice == 1)
                {
                    double totalFee = 0;

                    Console.WriteLine("\n\t\t\tCustomer 's Details");
                    Console.Write("Name -> "); string name = Console.ReadLine();
                    Console.Write("Phone -> "); string phone = Console.ReadLine();
                    Console.Write("Address -> "); string address = Console.ReadLine();
                    customer.Add(custID, new Customer(custID, name, phone, address));

                    Console.Write("\nDuration [ in months e.g. 12, 24, etc. ] -> "); int duration = int.Parse(Console.ReadLine());

                    Console.Write("\nQuantity of General File -> "); int gQuan = int.Parse(Console.ReadLine());
                    Console.Write("Quantity of Legal File -> "); int lQuan = int.Parse(Console.ReadLine());

                    if (gQuan > 0)
                    {
                        Console.WriteLine("\n\t\t\tGeneral Files");
                        Console.Write("Zone [ A - D ] -> "); string gZone = Console.ReadLine(); Console.WriteLine();
                        Folder GeneralFolder = new Folder(duration, "General", gZone, folderNO, ((Customer)customer[custID]));
                        folder.Add(folderNO, GeneralFolder);
                        for (int i = 1; i <= gQuan; i++)
                        {
                            Console.Write("Sheet Quantity -> "); int sheetQuan = int.Parse(Console.ReadLine());
                            Console.Write("Name -> "); string n = Console.ReadLine();
                            ((Folder)folder[folderNO]).RecordFile(new File(i, sheetQuan, n));
                        }
                        totalFee += ((Folder)folder[folderNO]).CostFee("General", duration);
                        folderNO++;
                    }

                    if (lQuan > 0)
                    {
                        Console.WriteLine("\n\t\t\tLegal Files");
                        Console.Write("Zone [ E - H ] -> "); string lZone = Console.ReadLine(); Console.WriteLine();
                        Folder LegalFolder = new Folder(duration, "Legal", lZone, folderNO, ((Customer)customer[custID]));
                        folder.Add(folderNO, LegalFolder);
                        for (int i = 1; i <= lQuan; i++)
                        {
                            Console.Write("Sheet Quantity -> "); int sheetQuan = int.Parse(Console.ReadLine());
                            Console.Write("Name -> "); string n = Console.ReadLine();
                            ((Folder)folder[folderNO]).RecordFile(new File(i, sheetQuan, n));
                        }
                        totalFee += ((Folder)folder[folderNO]).CostFee("Legal", duration);
                        totalFee += 1500;
                        folderNO++;
                    }

                    Console.WriteLine("\n\t\t\tService Fee");
                    Console.WriteLine("Total Fee Service: " + totalFee);

                    Console.WriteLine("\n\t\t\tContract");
                    Console.WriteLine("Contract NO.: " + contractNO);
                    Console.WriteLine("Customer Name: " + ((Customer)customer[custID]).CustName);
                    Console.WriteLine("Customer Phone NO.: " + ((Customer)customer[custID]).PhoneNum);
                    Console.WriteLine("Customer Address: " + ((Customer)customer[custID]).Address);
                    Console.WriteLine("\nDuration of Storage: " + ((Folder)folder[folderNO-1]).Duration + " Months");
                    Console.WriteLine("Strored Date: " + ((Folder)folder[folderNO-1]).StoredDate);
                    Console.WriteLine("Dued Date: " + ((Folder)folder[folderNO-1]).DuedDate); Console.WriteLine();

                    custID++;
                    contractNO++;                    
                }

                else if (choice == 2)
                {                   
                    Console.Write("\nContract NO. -> "); int cno = int.Parse(Console.ReadLine());

                    Console.WriteLine();
                    for (int i = 1; i <= folder.Count; i++)
                    {
                        if (cno == ((Folder)(folder[i])).CustID)
                        {
                            Console.WriteLine("Folder NO.: " + ((Folder)(folder[i])).FolderNO);
                        }
                    }

                    string key = "Yes";
                    while (key == "Yes")
                    {
                        Console.Write("\nFolder NO. -> "); int no = int.Parse(Console.ReadLine());


                        if (((Folder)folder[no]).FolderNO == no)
                        {
                            Console.WriteLine(); ((Folder)folder[no]).AccessFiles();

                            Console.Write("\nNumber of Files Retrived -> "); int num = int.Parse(Console.ReadLine());
                            Console.WriteLine("\nInput File NO. "); Console.WriteLine();

                            for (int i = 1; i <= num; i++)
                            {
                                Console.Write("File NO. "); int fno = int.Parse(Console.ReadLine());
                                Console.WriteLine("Name: " + ((Folder)folder[no]).GetFileName(fno));
                                ((Folder)folder[no]).RetriveFile(fno);
                            }

                            Console.WriteLine("Send to " + "\n\t" + ((Customer)customer[cno]).Address);
                        }

                        Console.Write("Continue ? [ Yes | NO ] -> "); key = Console.ReadLine();
                    } 
                }
                Console.WriteLine("\nMenu\n1. Collect Files\n2. Access and Retrive\n3. Quit");
                Console.Write("\nChoose -> "); choice = int.Parse(Console.ReadLine());
            }
        }
    }
}
