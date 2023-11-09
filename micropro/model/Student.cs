namespace micropro.model;


using System.Xml.Serialization;

using System;
using System.Xml.Serialization;

[XmlRoot("Student")]
public class Student
{
    private string name;
    private string prenom;
    private double noteN;
    private double noteR;
    private string email;
    private int apogee;
    private double m1;
    private double m2;
    private double m3;
    private double m4;
    private double m5;
    private double m6;

   
    [XmlAttribute("Name")]
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    [XmlAttribute("Prenom")]
    public string Prenom
    {
        get { return prenom; }
        set { prenom = value; }
    }

    [XmlElement(ElementName = "noteN")]
    public double NoteN
    {
        get { return noteN; }
        set { noteN = value; }
    }

    [XmlElement(ElementName = "noteR")]
    public double NoteR
    {
        get { return noteR; }
        set { noteR = value; }
    }
    
    [XmlAttribute("email")]
    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    [XmlAttribute("apogee")]
    public int Apogee  {
        get { return apogee; }
        set { apogee = value; }
    }
    [XmlAttribute("M1")]
    public double M1
    {
        get { return m1; }
        set { m1 = value; }
    }
    [XmlAttribute("M2")]
    public double M2
    {
        get { return m2; }
        set { m2 = value; }
    }
    [XmlAttribute("M3")]
    public double M3
    {
        get { return m3; }
        set { m3 = value; }
    }
    [XmlAttribute("M4")]
    public double M4
    {
        get { return m4; }
        set { m4 = value; }
    }
    [XmlAttribute("M5")]
    public double M5
    {
        get { return m5; }
        set { m5 = value; }
    }
    [XmlAttribute("M6")]
    public double M6
    {
        get { return m6; }
        set { m6 = value; }
    }
   
    
}

