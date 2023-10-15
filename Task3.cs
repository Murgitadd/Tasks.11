using System;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}

class Group
{
    public static Group[] Groups = new Group[100];
    public static int GroupCount = 0;

    public int GroupId { get; set; }
    public string GroupName { get; set; }
    public Student[] Students { get; set; }

    public Group(int groupId, string groupName)
    {
        GroupId = groupId;
        GroupName = groupName;
        Students = new Student[4];
        Groups[GroupCount] = this;
        GroupCount++;
    }

    public void GetGroupInfo()
    {
        Console.WriteLine($"Group Id: {GroupId}");
        Console.WriteLine($"Group Name: {GroupName}");
        Console.WriteLine($"Number of Students in the Group: {Students.Length}");
    }

    public Student GetStudent(int studentId)
    {
        foreach (var student in Students)
        {
            if (student != null && student.Id == studentId)
            {
                return student;
            }
        }
        return null;
    }

    public void AddStudent(Student student)
    {
        for (int i = 0; i < Students.Length; i++)
        {
            if (Students[i] == null)
            {
                Students[i] = student;
                return;
            }
        }
        Console.WriteLine("Cannot add more students. The group is full.");
    }

    public void RemoveStudent(int studentId)
    {
        for (int i = 0; i < Students.Length; i++)
        {
            if (Students[i] != null && Students[i].Id == studentId)
            {
                Students[i] = null;
                return;
            }
        }
        Console.WriteLine($"No student with ID {studentId} found in the group.");
    }

    public void ShowStudents()
    {
        Console.WriteLine($"Students in Group {GroupName} (ID: {GroupId}):");
        foreach (var student in Students)
        {
            if (student != null)
            {
                Console.WriteLine($"Student Id: {student.Id}, Name: {student.Name}, Surname: {student.Surname}");
            }
        }
    }

    public static void ShowAllGroups()
    {
        Console.WriteLine("All Groups:");
        foreach (var group in Groups)
        {
            if (group != null)
            {
                group.GetGroupInfo();
            }
        }
    }

    public static Group AddGroup(int groupId, string groupName)
    {
        Group newGroup = new Group(groupId, groupName);
        return newGroup;
    }
}

class Program
{
    static void Main()
    {
        
        Group group1 = Group.AddGroup(1, "AB104");
        Group group2 = Group.AddGroup(2, "AP110");

        
        Student student1 = new Student { Id = 1, Name = "Murad", Surname = "Xasaddinov" };
        Student student2 = new Student { Id = 2, Name = "Subhan", Surname = "Hemidov" };
        Student student3 = new Student { Id = 3, Name = "Adil", Surname = "Huseyinli" };
        Student student4 = new Student { Id = 4, Name = "Sabir", Surname = "Baxishov" };
        group1.AddStudent(student1);
        group1.AddStudent(student2);
        group1.AddStudent(student3);
        group1.AddStudent(student4);

        
        Student student5 = new Student { Id = 5, Name = "Elnur", Surname = "Memmedov" };
        Student student6 = new Student { Id = 6, Name = "Qurban", Surname = "Nesirli" };
        Student student7 = new Student { Id = 7, Name = "Ferid", Surname = "Ramazanov" };
        Student student8 = new Student { Id = 8, Name = "Eyyar", Surname = "Shukurov" };
        group2.AddStudent(student5);
        group2.AddStudent(student6);
        group2.AddStudent(student7);
        group2.AddStudent(student8);

        Group.ShowAllGroups();
    }
}
