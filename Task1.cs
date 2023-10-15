using System;
using System.Text.RegularExpressions;

interface ICodeAcademy
{
    string CodeEmail { get; set; }
    void GenerateEmail(string name, string surname, int id);
}

class Student : ICodeAcademy
{
    public string Name { get; }
    public string Surname { get; }
    public int Id { get; }
    public string CodeEmail { get; set; }

    public Student(string name, string surname)
    {
        if (CheckName(name) && CheckName(surname))
        {
            Name = name;
            Surname = surname;
            Id = IdGenerator.GetNextId();
            GenerateEmail(name, surname, Id);
        }
        else
        {
            Console.WriteLine("Invalid name or surname. Student not created.");
        }
    }

    public void GenerateEmail(string name, string surname, int id)
    {
        string email = $"{name}.{surname}{id}@code.edu.az".ToLower();
        CodeEmail = email;
    }

    public static bool CheckName(string name)
    {
        string pattern = "^[A-Za-z]{3,25}$";
        return Regex.IsMatch(name, pattern);
    }
}

static class IdGenerator
{
    private static int currentId = 0;

    public static int GetNextId()
    {
        return ++currentId;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Student student1 = new Student("Murad", "Xasaddinov");
        Console.WriteLine($"Name: {student1.Name}, Surname: {student1.Surname}, CodeEmail: {student1.CodeEmail}");

        Student student2 = new Student("Ad1l", "Huseynov"); // have number in name 
        Student student3 = new Student("Sabir", "Resulmemmedquluzadeleshdirilmisov"); // too long surname
        Student student4 = new Student("Subhan", "Quluyev");
        Console.WriteLine($"Name: {student4.Name}, Surname: {student4.Surname}, CodeEmail: {student4.CodeEmail}");
    }
}
