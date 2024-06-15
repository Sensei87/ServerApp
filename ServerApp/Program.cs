using ServerApp;
using System.Xml;
using System.Xml.Linq;

Console.WriteLine("Generate infinity numbers");


// This is a technical task for an interview.
// Range and multicast group are configured via a separate XML config

try
{
    string? path = Environment.CurrentDirectory;

    // Find the file in the local directories
    DirectoryInfo directory = new DirectoryInfo(path);
    DirectoryInfo parentDirectory = directory.Parent;
    DirectoryInfo projectDirectory = parentDirectory?.Parent;
    DirectoryInfo xmlLocation = projectDirectory?.Parent;


    if (xmlLocation == null)
    {
        Console.WriteLine("Can't to find the XML location.");
        return;
    }

    string configPath = Path.Combine(xmlLocation.FullName, "config.xml");
    XDocument document = XDocument.Load(configPath);

    string? multicastAddress = document.Root.Element("multicastAddress")?.Value;
    if (!int.TryParse(document.Root.Element("range")?.Value, out int range))
    {
        Console.WriteLine("Invalid range value in config.xml");
        return;
    }
    if (!int.TryParse(document.Root.Element("port")?.Value, out int port))
    {
        Console.WriteLine("Invalid port value in config.xml");
        return;
    }


    Server.Sendler(multicastAddress, range, port);



}
catch (IOException ex)
{
    Console.WriteLine($"IO Exception: {ex}");
}
catch (XmlException ex)
{
    Console.WriteLine($"XML Exception: {ex}");
}
catch (Exception ex)
{
    Console.WriteLine($"Unexpected error: {ex}");
}

