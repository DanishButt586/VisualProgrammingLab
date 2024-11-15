using System;
using System.Xml;
using System.IO;

class Program
{
    static void Main()
    {
        CreateXmlFile();

        ReadXmlFile();

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static void CreateXmlFile()
    {
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.IndentChars = "\t"; 

        using (XmlWriter writer = XmlWriter.Create("GPS.xml", settings))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("GPS_Log");
            writer.WriteStartElement("Position");
            writer.WriteAttributeString("DateTime", "1/26/2017 5:08:59 PM");
            writer.WriteElementString("x", "65.8973342");
            writer.WriteElementString("y", "72.3452346");
            writer.WriteStartElement("SatteliteInfo");
            writer.WriteElementString("Speed", "40");
            writer.WriteElementString("NoSatt", "7");
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteStartElement("Image");
            writer.WriteAttributeString("Resolution", "1024x800");
            writer.WriteElementString("Path", @"\images\1.jpg");
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();
        }

        Console.WriteLine("XML file 'GPS.xml' created successfully.");
    }

    static void ReadXmlFile()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("GPS.xml");

        StringWriter stringWriter = new StringWriter();
        XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter)
        {
            Formatting = Formatting.Indented,  
            Indentation = 1,                   
            IndentChar = '\t'                  
        };


        doc.WriteTo(xmlTextWriter);

        Console.WriteLine("\nXML File Content:");
        Console.WriteLine(stringWriter.ToString());
    }
}
