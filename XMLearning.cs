using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
namespace vscode
{
    public static class XMLearning
    {
        public static void Run()
        {

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
        }
        
    }
}