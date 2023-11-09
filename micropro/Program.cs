using System.Xml;
using System.Xml.Linq;
using micropro.model;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/getElement/{elementName}", (string elementName) =>
{
    // Load the XML document from the file
    XmlDocument doc = new XmlDocument();
    doc.Load("D:\\springboot\\E-learning\\microproject\\src\\main\\resources\\data\\firstsemester.xml"); // Replace with the path to your XML file

    // Find the first occurrence of the element by its name
    XmlNodeList elements = doc.GetElementsByTagName(elementName);

    if (elements.Count > 0)
    {
        XmlNode element = elements[0]; // Get the first matching element
        return element.InnerText;
    }
    else
    {
        return "Element not found: " + elementName;
    }
});

app.MapGet("/students", () =>
{
    string filePath = "D:\\rider\\WebApplication1\\WebApplication1\\service\\students.xml"; // Path to your XML file

    // Load the XML document
    XDocument xdoc = XDocument.Load(filePath);

    // Add a new student
    XElement newStudent = new XElement("student",
        new XElement("age", 25),
        new XElement("name", "New Student")
    );

    xdoc.Element("students").Add(newStudent);

    // Modify an existing student (e.g., the third student's name)
    XElement studentToModify = xdoc.Descendants("student").ElementAt(2); // Select the third student
    studentToModify.Element("name").Value = "Updated Name";

    // Save the modified XML back to the file
    xdoc.Save(filePath);

    return "XML file updated successfully.";
});
app.MapGet("/getAll", () =>
{
    string filePath = "D:\\springboot\\E-learning\\microproject\\src\\main\\resources\\data\\students.xml"; // Path to your XML file

    // Load the XML document
    XDocument xdoc = XDocument.Load(filePath);

    var students = xdoc.Descendants("student");
    var studentList = new List<Student>(); // List to store student data

    foreach (var student in students)
    {
        string name = student.Element("name")?.Value;
        string prenom = student.Element("prenom")?.Value;
        double noteN = double.Parse(student.Element("noteN")?.Value ?? "0.0"); // Use 0.0 as default if noteN is missing
        double noteR = double.Parse(student.Element("noteR")?.Value ?? "0.0"); // Use 0.0 as default if noteR is missing
        string email = student.Element("email")?.Value;

        var studentData = new Student
        {
            Name = name,
            Prenom = prenom,
            NoteN = noteN,
            NoteR = noteR,
            Email = email
        };

        studentList.Add(studentData);
    }

    // Return the list of student data as JSON
    return Results.Json(studentList);
});
app.MapGet("/getstudentSemester1", () =>
{
    string filePath = "D:\\springboot\\E-learning\\microproject\\src\\main\\resources\\data\\firstsemester.xml"; // Path to your XML file

    // Load the XML document
    XDocument xdoc = XDocument.Load(filePath);

    var students = xdoc.Descendants("student");
    var studentList = new List<Student>(); // List to store student data

    foreach (var student in students)
    {
        string name = student.Element("name")?.Value;
        string prenom = student.Element("prenom")?.Value;
        double noteN = double.Parse(student.Element("noteN")?.Value ?? "0.0"); // Use 0.0 as default if noteN is missing
        double noteR = double.Parse(student.Element("noteR")?.Value ?? "0.0"); // Use 0.0 as default if noteR is missing
        string email = student.Element("email")?.Value;

        var studentData = new Student
        {
            Name = name,
            Prenom = prenom,
            NoteN = noteN,
            NoteR = noteR,
            Email = email
        };

        studentList.Add(studentData);
    }

    // Return the list of student data as JSON
    return Results.Json(studentList);
});
app.MapGet("/getstudentSemester2", () =>
{
    string filePath = "D:\\springboot\\E-learning\\microproject\\src\\main\\resources\\data\\secondsemester.xml"; // Path to your XML file

    // Load the XML document
    XDocument xdoc = XDocument.Load(filePath);

    var students = xdoc.Descendants("student");
    var studentList = new List<Student>(); // List to store student data

    foreach (var student in students)
    {
        string name = student.Element("name")?.Value;
        string prenom = student.Element("prenom")?.Value;
        double noteN = double.Parse(student.Element("noteN")?.Value ?? "0.0"); // Use 0.0 as default if noteN is missing
        double noteR = double.Parse(student.Element("noteR")?.Value ?? "0.0"); // Use 0.0 as default if noteR is missing
        string email = student.Element("email")?.Value;

        var studentData = new Student
        {
            Name = name,
            Prenom = prenom,
            NoteN = noteN,
            NoteR = noteR,
            Email = email
        };

        studentList.Add(studentData);
    }

    // Return the list of student data as JSON
    return Results.Json(studentList);
});


app.MapPost("/inscrit/{semseter}", async (HttpContext context,string semseter) =>
{
    try
    {
        string filePath = "D:\\springboot\\E-learning\\microproject\\src\\main\\resources\\data\\semester"+semseter+".xml"; // Path to your XML file

        // Load the XML document
        XDocument xdoc = XDocument.Load(filePath);

        // Read XML data from the request body asynchronously
        using (var reader = new System.IO.StreamReader(context.Request.Body))
        {
            var xmlContent = await reader.ReadToEndAsync(); // Use ReadToEndAsync

            // Parse the XML data
            XElement studentElement = XElement.Parse(xmlContent);

            // Access student data from the XML
            string studentName = studentElement.Element("name")?.Value;
            string studentPrenom = studentElement.Element("prenom")?.Value;
            double studentNoteN = double.Parse(studentElement.Element("noteN")?.Value ?? "0.0");
            double studentNoteR = double.Parse(studentElement.Element("noteR")?.Value ?? "0.0");
            string studentEmail = studentElement.Element("email")?.Value;
            string apogee = studentElement.Element("apogee")?.Value;


            // Create a new student element and add it to the XML
            XElement newStudent = new XElement("student",
                new XAttribute("name", studentName),
                new XAttribute("prenom", studentPrenom),
                new XElement("noteN", studentNoteN),
                new XElement("noteR", studentNoteR),
                new XAttribute("email", studentEmail),
                new XAttribute("apogee",apogee),
                new XElement("M1",-1),
                new XElement("M2",-1),
                new XElement("M3",-1),
                new XElement("M4",-1),
                new XElement("M5",-1),
                new XElement("M6",-1),
                new XElement("MR1",-1),
                new XElement("MR2",-1),
                new XElement("MR3",-1),
                new XElement("MR4",-1),
                new XElement("MR5",-1),
                new XElement("MR6",-1)
            );

            xdoc.Root.Add(newStudent);

            // Save the modified XML back to the file
            xdoc.Save(filePath);
            Console.WriteLine("student added ");
            return "Student added successfully.";
        }
    }
    catch (Exception ex)
    {
        return $"An error occurred: {ex.Message}";
    }
});

app.Run();