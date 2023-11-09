namespace micropro.model;

using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("Students")]
public class Students
{
    private List<Student> studentList;

    [XmlElement("student")]
    public List<Student> StudentList
    {
        get { return studentList; }
        set { studentList = value; }
    }
}