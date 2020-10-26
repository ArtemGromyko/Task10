using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Task10
{
    class Program
    {
        static void Main(string[] args)
        {
            Book b = new Book();
            b.ReadObjectFromXML(@"..\..\..\XMLBookRead.xml");
            b.Disp();
            b.WriteObjectToXML(@"..\..\..\XMLBookWrite.xml");
            Book.WriteObjectToJSON(@"..\..\..\write.json", b);
            Book a = new Book();
            a = Book.ReadObjectFromJSON(@"..\..\..\read.json");
            Console.WriteLine("a: ");
            a.Disp();
            Book.WriteObjectToJSON(@"..\..\..\write.json", a);
        }
    }
}
