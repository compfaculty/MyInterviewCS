using System.Collections.Specialized;

namespace MyInterview.Test;

public class EmployessManagment
{
    public static Dictionary<string, int> AverageAgeForEachCompany(List<Employee> employees)
    {
        var averageAgeByCompany = new Dictionary<string, int>();

        foreach (var group in employees.GroupBy(e => e.Company))
        {
            var company = group.Key;
            var averageAge = group.Average(e => e.Age);
            averageAgeByCompany[company] = (int)Math.Ceiling(averageAge);
        }

        var sorted = averageAgeByCompany.OrderBy(x => x.Key);
        return new Dictionary<string, int>(sorted);
    }

    public static Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
    {
        var employeesPerCompany = new Dictionary<string, int>();

        foreach (var group in employees.GroupBy(e => e.Company))
        {
            var company = group.Key;
            var employers = group.Count();
            employeesPerCompany[company] = employers;
        }

        var sorted = employeesPerCompany.OrderBy(x => x.Key);
        return new Dictionary<string, int>(sorted);
    }

    public static Dictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
    {
        var employeesPerCompany = new Dictionary<string, Employee>();

        foreach (var group in employees.GroupBy(e => e.Company))
        {
            var company = group.Key;
            var oldestEmployee = group.MaxBy(e => e.Age);
            employeesPerCompany[company] = oldestEmployee;
        }

        var sorted = employeesPerCompany.OrderBy(x => x.Key);
        return new Dictionary<string, Employee>(sorted);
    }
}

public class Employee
{
    public Employee(string firstName, string lastName, string company, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Company = company;
        Age = age;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Company { get; set; }
    public int Age { get; set; }
}