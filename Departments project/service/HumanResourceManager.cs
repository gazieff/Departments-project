using Departments_project.Departmentt;
using Departments_project.Employer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Departments_project.service
{
    class HumanResourceManager : IHumanResourceManager
    {
        Department Dtemp = new Department();
        Employee Etemp = new Employee();
        int eea, a;

        public HumanResourceManager()
        {
            Departments = new List<Department>();
        }

        public List<Department> Departments { get; set; }

        public void AddDepartment(string name, int workerlimit, int salarylimit)
        {
            Dtemp.Name = name;
            Dtemp.WorkerLimit = workerlimit;
            Dtemp.SalaryLimit = salarylimit;
            Departments.Add(Dtemp);
        }

        public void AddEmployee(string fullname, string position, int salary, string DName)
        {
            Employee.n++;
            Etemp.Fullname = fullname;
            Etemp.Position = position;
            Etemp.Salary = salary;
            Etemp.DepartmentName = DName;
            Etemp.No = DName.Substring(0, 2) + Employee.n.ToString();
            Departments.FirstOrDefault(x => x.Name.Contains(DName)).Employees.Add(Etemp);
        }

        public void EditDepartments(string DName, string newname)
        {
            int a = Departments.FindIndex(x => x.Name.Contains(DName));
            Department tmp = Departments[a];
            tmp.Name = newname;
            Departments.RemoveAt(a);
            Departments.Insert(a, tmp);
        }

        public void EditEmployee(string no, int salary, string position)
        {
            foreach (var department in Departments)
            {
                foreach (var employee in department.Employees)
                {
                    if (employee.No == no)
                    {
                        eea = department.Employees.IndexOf(employee);
                        a = Departments.FindIndex(x => x.Employees[eea] == employee);
                    }
                }
            }
            Employee tmp = Departments[a].Employees[eea];
            tmp.Salary = salary;
            tmp.Position = position;
            Departments[a].Employees.RemoveAt(eea);
            Departments[a].Employees.Insert(eea, tmp);
        }

        public List<Department> GetDepartments()
        {
            return Departments;
        }

        public void RemoveEmployee(string no, string DName)
        {
            int dindex = Departments.FindIndex(x => x.Name.Contains(DName));
            int eindex = Departments[dindex].Employees.FindIndex(x => x.No.Contains(no));
            Departments[dindex].Employees.RemoveAt(eindex);
        }
    }
}

