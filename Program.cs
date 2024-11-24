using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _2ndWeek
{
    public class Teacher
    {
        string name;
        int id;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Teacher(string tName, int tId)
        {
            Name = tName;
            Id = tId;
        }
    }

    public class School
    {
        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public List<Teacher> Teachers { get; set; }

        public School(string name)
        {
            Name = name;
            Teachers = new List<Teacher>();
        }

        public void AddTeacher(Teacher teacher)
        {
            Teachers.Add(teacher);
        }
    }

    public class City
    {
        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<School> Schools
        { get; set; }

        public City(string name)
        {
            Name = name;
            Schools = new List<School>();
        }

        public void AddSchool(School school)
        {
            Schools.Add(school);
        }
    }
    public class GenericList<T>
    {
        private List<T> elements = new List<T>();

        public void AddElement(T element)
        {
            elements.Add(element);
        }

        public T GetFirstElement()
        {
            if (elements.Count > 0)
                return elements[0];
            else
                throw new InvalidOperationException("The list is empty.");
        }
        public void DisplayAllElements()
        {
            Console.WriteLine("List elements:");
            foreach (var element in elements)
            {
                Console.WriteLine($"-- {element}");
            }
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            string type;
            int ch = 0;
            while (true)
            {
                if (ch != 4)
                {
                    Console.WriteLine("Menu:");
                    Console.WriteLine("1. Exercise 1");
                    Console.WriteLine("2. Exercise 2");
                    Console.WriteLine("3. Exercise 3");
                    Console.WriteLine("4. Exit");
                    ch = Convert.ToInt32(Console.ReadLine());
                    switch (ch)
                    {

                        case 1:
                            {
                                GenericList<int> intList = new GenericList<int>();
                                GenericList<string> stringList = new GenericList<string>();
                                GenericList<double> doubleList = new GenericList<double>();
                                GenericList<char> charList = new GenericList<char>();

                                Console.WriteLine("Enter the data type (int, string, double, char):");
                                type = Console.ReadLine().ToLower();
                                int option = 0;
                                if (type == "string" || type == "int" || type == "char" || type == "double")
                                {
                                    while (true)
                                    {
                                        if (option != 4)
                                        {
                                            Console.WriteLine("Options: ");
                                            Console.WriteLine("1. Add Element");
                                            Console.WriteLine("2. Display First Element ");
                                            Console.WriteLine("3. Display All");
                                            Console.WriteLine("4. Exit");
                                            option = Convert.ToInt32(Console.ReadLine());

                                            switch (option)
                                            {
                                                case 1:
                                                    {
                                                        Console.WriteLine("Enter a Value to add:");
                                                        var input = Console.ReadLine();
                                                        if (type == "int")
                                                        {
                                                            intList.AddElement(Convert.ToInt32(input));
                                                        }
                                                        else if (type == "string")
                                                        {
                                                            stringList.AddElement(Convert.ToString(input));
                                                        }
                                                        else if (type == "double")
                                                        {
                                                            doubleList.AddElement(Convert.ToDouble(input));
                                                        }
                                                        else
                                                        {
                                                            charList.AddElement(Convert.ToChar(input));
                                                        }

                                                        break;
                                                    }

                                                case 2:
                                                    {
                                                        if (type == "int")
                                                        {
                                                            int firstEle;
                                                            firstEle = intList.GetFirstElement();
                                                            Console.WriteLine($"The First Element of the List is: {firstEle}");
                                                        }
                                                        else if (type == "string")
                                                        {
                                                            string firstEle;
                                                            firstEle = stringList.GetFirstElement();
                                                            Console.WriteLine($"The First Element of the List is: {firstEle}");
                                                        }
                                                        else if (type == "double")
                                                        {
                                                            double firstEle;
                                                            firstEle = doubleList.GetFirstElement();
                                                            Console.WriteLine($"The First Element of the List is: {firstEle}");
                                                        }
                                                        else
                                                        {
                                                            char firstEle;
                                                            firstEle = charList.GetFirstElement();
                                                            Console.WriteLine($"The First Element of the List is: {firstEle}");
                                                        }
                                                        break;

                                                    }
                                                case 3:
                                                    {
                                                        if (type == "int")
                                                        {
                                                            intList.DisplayAllElements();

                                                        }
                                                        else if (type == "string")
                                                        {
                                                            stringList.DisplayAllElements();
                                                        }
                                                        else if (type == "double")
                                                        {
                                                            doubleList.DisplayAllElements();
                                                        }
                                                        else
                                                        {
                                                            charList.DisplayAllElements();
                                                        }
                                                        break;
                                                    }

                                                default:
                                                    if (option == 4)
                                                        Console.WriteLine("Exiting");
                                                    else
                                                    {
                                                        Console.WriteLine("Invalid option. Please try again.");

                                                    }
                                                    break;

                                            }

                                        }
                                        else
                                        { break; }
                                    }
                                }


                                else
                                {
                                    Console.WriteLine("Not A Valid Type");
                                }
                                break;
                            }

                        case 2:
                            {
                                // I have some issues with my laptop, i could not test this part "
                             
                                string filePath1 = @"C:\Users\DASOUQI\OneDrive - UNHCR\Desktop\fullstack- batch\OOP Course\2ndWeek\doc2R.txt";
                                string filePath2 = @"C:\Users\DASOUQI\OneDrive - UNHCR\Desktop\fullstack- batch\OOP Course\2ndWeek\doc1W.txt";
                                try
                                {

                                    string content = File.ReadAllText(filePath1);

                                    File.AppendAllText(filePath2, content);


                                    string data = File.ReadAllText(filePath2);


                                    int wordCount = data.Split(new[] { ' ', '\n', '\r', '.', ',', ';', ':', '!', '?', '-', '(', ')', '"', '\'' }, StringSplitOptions.RemoveEmptyEntries)
                                        .Count(word => !string.IsNullOrWhiteSpace(word));

                                    Console.WriteLine($"Total number of words in '{filePath2}': {wordCount}");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"An error occurred: {ex.Message}");
                                }
                                break;
                            }
                        case 3:
                            {
                                List<City> cities = new List<City>();
                                int choice = 0;
                                while (true)
                                {
                                    if (choice != 6)
                                    {
                                        Console.WriteLine("\nMenu:");
                                        Console.WriteLine("1. Add City");
                                        Console.WriteLine("2. Add School to City");
                                        Console.WriteLine("3. Add Teacher to School");
                                        Console.WriteLine("4. Display Cities, Schools, and Teachers");
                                        Console.WriteLine("5. Display School with Most Teachers");
                                        Console.WriteLine("6. Exit");
                                        Console.Write("Enter your choice: ");
                                        choice = Convert.ToInt32(Console.ReadLine());

                                        switch (choice)
                                        {
                                            case 1:
                                                {
                                                    Console.WriteLine("_______________________________________");
                                                    Console.Write("Enter the name of the city: ");
                                                    string cityName = Console.ReadLine();
                                                    cities.Add(new City(cityName));
                                                    Console.WriteLine($"City '{cityName}' added.");
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    Console.WriteLine("_______________________________________");
                                                    Console.Write("Enter the name of the city: ");
                                                    string cityName = Console.ReadLine();
                                                    var city = cities.FirstOrDefault(c => c.Name.Equals(cityName, StringComparison.OrdinalIgnoreCase));

                                                    if (city != null)
                                                    {
                                                        Console.Write("Enter the name of the school: ");
                                                        string schoolName = Console.ReadLine();
                                                        city.AddSchool(new School(schoolName));
                                                        Console.WriteLine($"School '{schoolName}' added to '{cityName}'.");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("City not found.");
                                                    }
                                                    break;
                                                  
                                                }
                                            case 3:
                                                {
                                                    Console.WriteLine("_______________________________________");
                                                    Console.Write("Enter the name of the city: ");
                                                    string cityName = Console.ReadLine();
                                                    var city = cities.FirstOrDefault(c => c.Name.Equals(cityName, StringComparison.OrdinalIgnoreCase));

                                                    if (city != null)
                                                    {
                                                        Console.Write("Enter the name of the school: ");
                                                        string schoolName = Console.ReadLine();
                                                        var school = city.Schools.FirstOrDefault(s => s.Name.Equals(schoolName, StringComparison.OrdinalIgnoreCase));

                                                        if (school != null)
                                                        {
                                                            Console.Write("Enter the teacher's name: ");
                                                            string teacherName = Console.ReadLine();
                                                            Console.Write("Enter the teacher's ID: ");
                                                            int teacherId = Convert.ToInt32(Console.ReadLine());
                                                            school.AddTeacher(new Teacher(teacherName, teacherId));
                                                            Console.WriteLine($"Teacher '{teacherName}' added to '{schoolName}'.");
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("School not found.");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("City not found.");
                                                    }
                                                    break;
                                                }
                                            case 4:
                                                {
                                                    Console.WriteLine("_______________________________________");
                                                    var cityInfo = from c in cities
                                                                   select new
                                                                   {
                                                                       CityName = c.Name,
                                                                       Schools = c.Schools.Select(s => new
                                                                       {
                                                                           SchoolName = s.Name,
                                                                           Teachers = s.Teachers.Select(t => new { t.Name, t.Id })
                                                                       })
                                                                   };
                                                    foreach (var cityDetail in cityInfo)
                                                    {
                                                        Console.WriteLine($"City: {cityDetail.CityName}");
                                                        foreach (var school in cityDetail.Schools)
                                                        {
                                                            Console.WriteLine($"  School: {school.SchoolName}");
                                                            foreach (var teacher in school.Teachers)
                                                            {
                                                                Console.WriteLine($"    Teacher: {teacher.Name}, ID: {teacher.Id}");
                                                            }
                                                        }
                                                        Console.WriteLine("_______________________________________");
                                                    }
                                                    break;
                                                }
                                            case 5:
                                                {
                                                    Console.WriteLine("_______________________________________");
                                                    var schoolWithMostTeachers = (from c in cities
                                                                                  from s in c.Schools
                                                                                  orderby s.Teachers.Count descending
                                                                                  select s).FirstOrDefault();

                                                    if (schoolWithMostTeachers != null)
                                                    {
                                                        Console.WriteLine($"School with the highest number of teachers: {schoolWithMostTeachers.Name} with {schoolWithMostTeachers.Teachers.Count} teachers.");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("No schools available.");
                                                    }
                                                    break;
                                                }
                                            case 6:
                                                Console.WriteLine("Exiting...");
                                                break;
                                            default:
                                                Console.WriteLine("Invalid choice. Please try again.");
                                                break;
                                        }
                                    }
                                    else { break; }
                                }

                                break;
                            }
                        case 4:
                            {
                                return;

                            }


                    }
                }

            }




        }
    }
}

