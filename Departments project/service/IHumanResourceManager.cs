using Departments_project.Departmentt;
using System;
using System.Collections.Generic;
using System.Text;

namespace Departments_project.service
{
    interface IHumanResourceManager
    {
        List<Department> Departments { get; set; }
        void AddDepartment(string name, int workerlimit, int salarylimit);
        List<Department> GetDepartments();
        void EditDepartments(string DName, string newname);
        void AddEmployee(string fullname, string position, int salary, string DName);
        void RemoveEmployee(string no, string DName);
        void EditEmployee(string no, int salary, string position);
    }
}
