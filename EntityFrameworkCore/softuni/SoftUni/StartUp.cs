using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni 
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            Console.WriteLine(RemoveTown(context));
        }

        public static string GetEmployeesFullInformation(SoftUniContext context) 
        {
            var emp = context.Employees.Select(e=> new {
                e.FirstName,
                e.LastName,
                e.MiddleName,
                e.JobTitle,
                e.Salary
            }).ToList();
            string result = string.Join(Environment.NewLine,
            emp.Select(e => $"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:F2}")).TrimEnd();
            return result;
        }
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context) 
        {
            var emp = context.Employees.Select(e => new {
                e.FirstName,
                e.Salary
            }).Where(e=> e.Salary > 50000)
            .OrderBy(e=>e.FirstName)
            .ToList();
            return string.Join(Environment.NewLine,emp.Select(e => $"{e.FirstName} - {e.Salary:f2}"));
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context) 
        {
            var empl = context.Employees
                                .Where(e=>e.Department.Name == "Research and Development")
                                .Select(e => new
                                {
                                    e.FirstName,
                                    e.LastName,
                                    e.Department.Name,e.Salary
                                })
                                .OrderBy(e=>e.Salary)
                                .ThenBy(e=>e.FirstName);
            string result = string.Join(Environment.NewLine, empl.Select(e=> $"{e.FirstName} {e.LastName} from {e.Name} - ${e.Salary:f2}"));
            return result;
        }

        public static string AddNewAddressToEmployee(SoftUniContext context) 
        {
            Address addr = new Address() 
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var emp = context.Employees.FirstOrDefault(e=>e.LastName == "Nakov");
            emp.Address = addr;
            context.SaveChanges();
            var empl = context.Employees
                                               .Select(e => new 
                                                { 
                                                    e.AddressId,
                                                    e.Address.AddressText
                                                })
                                               .OrderByDescending(e=>e.AddressId)
                                               .Take(10)
                                               .ToList();
            string result = string.Join(Environment.NewLine, empl.Select(e=> $"{e.AddressText}"));
            return result;
        }

        public static string GetEmployeesInPeriod(SoftUniContext context) 
        {
            var empl = context
                .Employees
                .Include(e => e.EmployeesProjects)
                .ThenInclude(ep => ep.Project)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects
                        .Select(ep => new
                        {
                            Name = ep.Project.Name,
                            StartDate = ep.Project.StartDate,
                            EndDate = ep.Project.EndDate,
                        })
                        .Where(ep => ep.StartDate.Year >= 2001 && ep.StartDate.Year <= 2003)
                        .ToList()
                })
                .ToList();

            var result = new StringBuilder();
            string datePattr = "M/d/yyyy h:mm:ss tt";
            foreach (var employee in empl)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var project in employee.Projects)
                {
                    object projectEndDate = project.EndDate == null
                        ? "not finished"
                        : $"{((DateTime)project.EndDate).ToString(datePattr, CultureInfo.InvariantCulture)}";
                    result.AppendLine($"--{project.Name} - {project.StartDate.ToString(datePattr, CultureInfo.InvariantCulture)} - {projectEndDate}");
                }
            }

            return result.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context) 
        {
            var addr = context.Addresses
                                          .Include(a=>a.Employees)
                                          .Include(a=>a.Town)
                                          .OrderByDescending(a=>a.Employees.Count)
                                          .ThenBy(a=>a.Town.Name)
                                          .Take(10)
                                          .ToList();
            string result = string.Join(Environment.NewLine,addr.Select(a=>$"{a.AddressText}, {a.Town.Name} - {a.Employees.Count} employees"));
            return result;
        }

        public static string GetEmployee147(SoftUniContext context) 
        {
            var employeeId = 147;
            var empl147 = context.Employees
                .Include(e => e.EmployeesProjects).ThenInclude(ep=>ep.Project)
                .Where(e => e.EmployeeId == employeeId)
                .FirstOrDefault();
            var projects = empl147.EmployeesProjects
                    .OrderBy(p => p.Project.Name)
                    .Select(p => p.Project.Name)
                    .ToList();

            StringBuilder result = new StringBuilder();
            result.AppendLine($"{empl147.FirstName} {empl147.LastName} - {empl147.JobTitle}");
            foreach (var proj in projects)
            {
                result.AppendLine($"{proj}");
            }
            return result.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context) 
        {
            var depts = context.Departments.Include(d => d.Employees)
                                                         .Include(d=>d.Manager)
                                                         .Where(d => d.Employees.Count > 5)
                                                         .OrderByDescending(d=>d.Employees.Count)
                                                         .OrderBy(d=>d.Name)
                                                         .ToList();
            StringBuilder result = new StringBuilder();
            foreach (var dept in depts)
            {
                result.AppendLine($"{dept.Name} - {dept.Manager.FirstName} {dept.Manager.LastName}");
                var empls = dept.Employees.OrderBy(e=>e.FirstName)
                                                       .ThenBy(e=>e.LastName)
                                                       .ToList();
                foreach (var empl in empls) 
                {
                    result.AppendLine($"{empl.FirstName} {empl.LastName} - {empl.JobTitle}");
                }
            }
            return result.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context) 
        {
            var projects = context.Projects.OrderByDescending(p => p.StartDate)
                                                       .Take(10)
                                                       .OrderBy(p => p.Name)
                                                       .ToList();
            StringBuilder result = new StringBuilder();
            string datePattr = "M/d/yyyy h:mm:ss tt";
            foreach (var project in projects) 
            {
                result.AppendLine(project.Name);
                result.AppendLine(project.Description);
                result.AppendLine(project.StartDate.ToString(datePattr, CultureInfo.InvariantCulture));
            }
            return result.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context) 
        {
            var departmentsToIncreaseSalary = new string[] { "Engineering", "Tool Design", "Marketing", "Information Services" };

            var employeesWithIncreasedSalary = context.Employees
                .Where(e => departmentsToIncreaseSalary.Contains(e.Department.Name))
                .ToList();

            foreach (var employee in employeesWithIncreasedSalary)
            {
                employee.Salary *= 1.12m;
            }

            context.SaveChanges();

            var result = employeesWithIncreasedSalary
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    Salary = Math.Round(e.Salary, 2)
                })
                .ToList();

            StringBuilder res = new StringBuilder();
            foreach (var employee in result) 
            {
                res.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }
            return res.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context) 
        {
            var empl = context.Employees.Where(e => e.FirstName.StartsWith("Sa")).OrderBy(e=>e.FirstName).ThenBy(e=>e.LastName).ToList();
            string result = string.Join(Environment.NewLine, empl.Select(e=>$"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})"));
            return result;
        }

        public static string DeleteProjectById(SoftUniContext context) 
        {
            var employeeProjectsToDelete = context.EmployeesProjects.Where(ep => ep.ProjectId == 2).ToList();
            context.EmployeesProjects.RemoveRange(employeeProjectsToDelete);
            context.SaveChanges();
            var projectToDelete = context.Projects.FirstOrDefault(p => p.ProjectId == 2);
            if (projectToDelete != null)
            {
                context.Projects.Remove(projectToDelete);
                context.SaveChanges();
            }
            var proj = context.Projects.Take(10)
                                                  .Select(p => p.Name)
                                                  .ToList();
            string result = string.Join(Environment.NewLine, proj.Select(p => $"{p}"));
            return result;
        }

        public static string RemoveTown(SoftUniContext context) 
        {
            string townNameToDelete = "Seattle";
            var employeesWithAddressesInTown = context.Employees
                .Include(e => e.Address)
                .Where(e => e.Address != null && e.Address.Town.Name == townNameToDelete)
                .ToList();

            foreach (var employee in employeesWithAddressesInTown)
            {
                employee.AddressId = null;
            }

            context.SaveChanges();

            var addressesToDelete = context.Addresses
                .Where(a => a.Town.Name == townNameToDelete)
                .ToList();

            context.Addresses.RemoveRange(addressesToDelete);
            context.SaveChanges();

            var townToDelete = context.Towns.FirstOrDefault(t => t.Name == townNameToDelete);
            context.Towns.Remove(townToDelete);
            context.SaveChanges();

            int addressesDeletedCount = addressesToDelete.Count;
            return $"{addressesDeletedCount} addresses in {townNameToDelete} were deleted";
        }
    }
}