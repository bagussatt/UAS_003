using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UAS_003
{
    class Node
    {
        public int NIM;
        public string Nama;
        public string Kelas;
        public string Kota_asal;
        public Node next;
        public Node prev;
    }
    class listdata
    {
        Node START;
        public listdata()
        {
            START = null;
        }
        public void inputdata()
        {
            int NIM;
            string nama, kelas, kota_asal;

            Console.WriteLine("Masukan NIM ");
            NIM = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Masukan Nama ");
            nama = Console.ReadLine();
            Console.WriteLine("Masukan Kelas  ");
            kelas = Console.ReadLine();
            Console.WriteLine("Masukan Kota Asal");
            kota_asal = Console.ReadLine();

            Node newnode = new Node();
            newnode.NIM = NIM;
            newnode.Nama = nama;
            newnode.Kelas = kelas;
            newnode.Kota_asal = kota_asal;

            if (START == null || NIM <= START.NIM)
            {
                if ((START != null) && (NIM == START.NIM))
                {
                    Console.WriteLine("\nData tidak valid");
                    return;
                }
                newnode.next = START;
                if (START != null)
                    START.prev = newnode;
                newnode.next = null;
                START = newnode;
                return;
            }

            Node previous, current;
            for (current = previous = START;
                current != null && NIM >= current.NIM;
                previous = current, current = current.next)
            {
                if (kota_asal == current.Kota_asal)
                {
                    Console.WriteLine("Duplicate tidak diperbolehkan");
                    return;
                }
            }

            newnode.next = current;
            newnode.prev = previous;
            if (current == null)
            {
                newnode.next = null;
                previous.next = newnode;
                return;


            }
            current.prev = newnode;
            previous.next = newnode;







        }
        public bool Search(int rollNo, ref Node previous, ref Node current)
        {
            previous = current = START;
            while (current != null &&
                rollNo != current.NIM)
            {
                previous = current;
                current = current.next;
            }
            return (current != null);
        }
        public bool dellNode(int rollNo)
        {
            Node previous, current;
            previous = current = null;
            if (Search(rollNo, ref previous, ref current) == false)
                return false;
            //the begining of data
            if (current.next == null)
            {
                previous.next = null;
                return true;
            }
            //node between two nodes in the list
            if (current == START)
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return true;
            }
            /*if the to be deleted is in between the list then the following lines of is executed. */
            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        public void ascending()
        {
            if (listEmpty())
                Console.WriteLine("\nList is Empty");
            else
            {
                Console.WriteLine("\n Record in the asceding order of " + "Roll numeber are:\n ");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.NIM + currentNode.Nama + currentNode.Kelas + currentNode.Kota_asal + "\n ");
            }
        }
        public void descending()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecord in the Descending order of " + "Roll Number are: \n ");
                Node currentNode;
                //membawa currentNode ke node paling belakang
                currentNode = START;
                while (currentNode.next != null)
                {
                    Console.Write(currentNode.next);
                }

                //membaca data dari last node ke first node
                while (currentNode != null)
                {
                    Console.Write(currentNode.NIM + "" + currentNode.Nama + currentNode.Kelas + currentNode.Kota_asal + "\n ");
                    currentNode = currentNode.prev;
                }
            }

        }
        public void trnasverse()
        {
            if (listEmpty())
                Console.WriteLine("data kosong");
            else 
                    Console.WriteLine("");
            Node currentNode;
            for (currentNode = START; currentNode != null;
                    currentNode = currentNode.next)
                Console.Write(currentNode.NIM + "" + currentNode.Nama + currentNode.Kelas + currentNode.Kota_asal + "\n ");
        }
        public void revtraverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList is Empty");
            else
            {
                Console.WriteLine("\nRecords in the descending order of " +
                    "roll numbers are : \n");
                Node currentNode;
                for (currentNode = START; currentNode.next != null;
                    currentNode = currentNode.next) { }
                while (currentNode != null)
                {
                    Console.Write(currentNode.NIM + " " +
                        currentNode.Nama + currentNode.Kelas + currentNode.Kota_asal +"\n");
                    currentNode = currentNode.prev;
                }

            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            listdata ld = new listdata();
            while (true)
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Add Record to the list");
                    Console.WriteLine("2. Delete a record from the list");
                    Console.WriteLine("3. View all recordds in the asceding order of roll number");
                    Console.WriteLine("4. View all record in the descending order of roll numbers");
                    Console.WriteLine("5. search for a record in the list");
                    Console.WriteLine("6. Exit\n");
                    Console.WriteLine("Enter your Choice (1-6: )");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                ld.inputdata();
                            }
                            break;
                        case '2':
                            {
                                if (ld.listEmpty())
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Console.Write("Enter the roll number of the student" + "whose record is to be deleted: ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (ld.dellNode(rollNo) == false)
                                    Console.WriteLine("Record not found");
                                else
                                    Console.WriteLine("Record with roll number" + rollNo + "deleted\n");

                            }
                            break;
                        case '3':
                            {
                                ld.ascending();

                            }
                            break;
                        case '4':
                            {
                                ld.descending();
                            }
                            break;
                        case '5':
                            {
                                if (ld.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;

                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\n enter the roll number of the student whose record you want to search: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (ld.Search(num, ref prev, ref curr) == false)
                                {
                                    Console.WriteLine("\nRecord not found");
                                }
                                else
                                {
                                    Console.WriteLine("\nRecord not found");
                                    Console.WriteLine("\nNIM: " + curr.NIM);
                                    Console.WriteLine("\nNama: " + curr.Nama);
                                    Console.WriteLine("\nKelas:" + curr.Kelas);
                                    Console.WriteLine("\nkota Asal:" + curr.Kota_asal);
                                }
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("check for the values entered.");
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Check for the vaalues entered.");
                }
        }
    }
    

}


//2.Saya Menggunakan double linkedlist dikarenakan menurut saya double linked list cocok untuk program ini untuk mencari mengurutkan dan menampilkan data
//3. Rear ,
//4. array digunakan saat mengetahui jumlah index yang akan dimasukkan dan menggunakna  sedangakan linked list digunakan saat kitatidak mengetahui jumlah maks data dan menggunakan Node
//5. a.parent dari 10 adalah 20
//     children dari 10 15
//   b.pre order
//   20.10.5.15.10.12.15.18.16.30.20.25.20.28.32
     