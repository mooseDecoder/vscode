using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace vscode 
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("test");
            Console.WriteLine("test again");

            #region EF
            // using (var db = new BloggingContext())
            // {
            //     //db.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
            //     //var count = db.SaveChanges();
            //     //Console.WriteLine("{0} records saved to database", count);

            //     Console.WriteLine();
            //     Console.WriteLine("All blogs in database:");
            //     foreach (var blog in db.Blogs)
            //     {
            //         Console.WriteLine(" - {0}", blog.Url);
                    
            //     }
            // }
            #endregion EF

            #region XML

            string xml = @"
            
            <customer id='123'  middle='middle' status='archived'>
                <firstname>Joe</firstname>
                <lastname>Bloggs></lastname>
            </customer>
            
            ";

            XElement customer = XElement.Parse(xml);
            var test = customer.FirstNode;



            XDocument xdoc = XDocument.Load("CustomerOrders.xml");
            XmlSchemaSet xschemas = new XmlSchemaSet();
            xschemas.Add(null, "CustomerOrders.xsd");

            //Console.WriteLine(xdoc.FirstNode.ToString());
            bool errors = false;
            xdoc.Validate(xschemas, (o, e) =>
                           {
                               Console.WriteLine("{0}", e.Message);
                               errors = true;
                           }, true);
            Console.WriteLine("doc1 {0}", errors ? "did not validate" : "validated");

            XElement xe = XElement.Load("CustomerOrders.xml");

            var orders = from o in xe.Elements(name: "Orders")
                        select o.ToString();
            foreach(var s in orders) 
            {
                Console.WriteLine(s);
            }
            int i = 0;

            



            #endregion XML
        
        
        
        }
    }
}
