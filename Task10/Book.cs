using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Schema;

namespace Task10
{
    class Book
    {
        public string Name { get; set; }
        public int NumberOfPages { get; set; }
        public string Author { get; set; }
        public Book() { }
        public Book(string name, int number, string author)
        {
            Name = name;
            NumberOfPages = number;
            Author = author;
        }
        public void Disp()
        {
            Console.WriteLine("Name: "+Name);
            Console.WriteLine("NumberOfPages: "+NumberOfPages);
            Console.WriteLine("Author: "+Author);
        }
        public void ReadObjectFromXML(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("wrong path");
                return;
            }
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlElement root = xml.DocumentElement;
            foreach(XmlNode x in root.ChildNodes)
            {
                if (x.Name == "Name")
                    Name = x.InnerText;
                else if (x.Name == "NumberOfPages")
                    NumberOfPages = Int32.Parse(x.InnerText);
                else if (x.Name == "Author")
                    Author = x.InnerText;
            }
        }
        public void WriteObjectToXML(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("wrong path");
                return;
            }
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlElement root = xml.DocumentElement;

            XmlElement xBook = xml.CreateElement("Book");

            XmlElement xName = xml.CreateElement("Name");
            XmlText xNameText = xml.CreateTextNode(this.Name);
            xName.AppendChild(xNameText);

            XmlElement xNumber = xml.CreateElement("NumberOfPages");
            XmlText xNumberText = xml.CreateTextNode(this.NumberOfPages.ToString());
            xNumber.AppendChild(xNumberText);

            XmlElement xAuthor = xml.CreateElement("Author");
            XmlText xAuthorText = xml.CreateTextNode(this.Author);
            xAuthor.AppendChild(xAuthorText);

            xBook.AppendChild(xName);
            xBook.AppendChild(xNumber);
            xBook.AppendChild(xAuthor);

            root.AppendChild(xBook);

            xml.Save(path);
        }
        public static void WriteObjectToJSON(string path, Book b)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("wrong path");
                return;
            }
            string s = JsonSerializer.Serialize<Book>(b);
            File.WriteAllText(path, s);
        }
        public static Book ReadObjectFromJSON(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("wrong path");
                return null;
            }
            string s = File.ReadAllText(path);
            Book b = new Book();
            b = JsonSerializer.Deserialize<Book>(s);
            return b;
        }
    }
}
