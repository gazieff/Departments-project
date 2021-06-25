using Departments_project.Departmentt;
using Departments_project.Employer;
using Departments_project.service;
using System;

namespace Departments_project
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanResourceManager hrm = new HumanResourceManager();
            Employee isci1 = new Employee("Islam Ekberov", "Qeydiyyatci", 350, "IHQD");
            Employee isci2 = new Employee("Qurban Zakirli", "Qeydiyyatci", 275, "HHQD");
            Employee isci3 = new Employee("Aydan Kerimova", "Telimci", 375, "QHQD");
            Employee isci4 = new Employee("Fidan Memmedli", "Zooloq", 400, "HHQD");
            Employee isci5 = new Employee("Arif Yunuslu", "Qeydiyyatci", 300, "IHQD");

            Department InsanHuquqlarininQorunmasi = new Department
            {
                Name = "IHQD",
                WorkerLimit = 5,
                SalaryLimit = 2300
            };
            Department QadinHuquqlarininQorunmasi = new Department
            {
                Name = "QHQD",
                WorkerLimit = 3,
                SalaryLimit = 3370
            };
            Department HeyvanHuquqlarininQorunmasi = new Department
            {
                Name = "HHQD",
                WorkerLimit = 7,
                SalaryLimit = 1100
            };

            HeyvanHuquqlarininQorunmasi.Employees.Add(isci2);
            HeyvanHuquqlarininQorunmasi.Employees.Add(isci4);
            InsanHuquqlarininQorunmasi.Employees.Add(isci1);
            InsanHuquqlarininQorunmasi.Employees.Add(isci5);
            QadinHuquqlarininQorunmasi.Employees.Add(isci3);

            hrm.Departments.Add(InsanHuquqlarininQorunmasi);
            hrm.Departments.Add(HeyvanHuquqlarininQorunmasi);
            hrm.Departments.Add(QadinHuquqlarininQorunmasi);

            Console.WriteLine("\t\tMovcud Isciler");
            foreach (var department in hrm.Departments)
            {
                foreach (var employee in department.Employees)
                {
                    Console.WriteLine("Isci Nomresi : " + employee.No
                        + "\tIsci Ad ve Soyadi : " + employee.Fullname
                        + "\tIscinin Departamentinin adi : " + employee.DepartmentName
                        + "\tIscinin Geliri : " + employee.Salary
                        + "\tIscinin Vezifesi : " + employee.Position);
                }
            }
        casemenuekshal:
            Console.WriteLine("\nEMELIYYATLAR MENYUSU \n1 - Departamentlerin Siyahisini gostermek \n2 - Departament Yaratmaq \n3 - Departamentde deyisiklik etmek \n4 - Iscilerin siyahisini gostermek \n5 - Departamentdeki Iscilerin siyahisini gostermek"
                + "\n6 - Isci Elave etmek \n7 - Isci uzerinde deyisiklik etmek \n8 - Departamentden isci silinmesi");
            Console.Write("\nEmeliyyatin nömresini daxil edin : ");
            int operationnumber = int.Parse(Console.ReadLine());

        caseekshal:
            switch (operationnumber)
            {
                case 1:
                    foreach (var item in hrm.Departments)
                    {
                        Console.WriteLine(item.Name + "  " + item.Employees.Count + "  " + item.CalcSalaryAverage());
                    }
                    break;
                case 2:
                    Console.Write("Departamentin Adi : ");
                    string name = Console.ReadLine();
                    Console.Write("Departamentin Isci Limiti : ");
                    int workerlimit = int.Parse(Console.ReadLine());
                    Console.Write("Departamentin Gelir Limiti : ");
                    int salarylimit = int.Parse(Console.ReadLine());
                    if (name.Length >= 2 && workerlimit >= 1 && salarylimit >= 250)
                    {
                        hrm.AddDepartment(name, workerlimit, salarylimit);
                    }
                    else
                    {
                        Console.WriteLine("Sehvlik var! Qaydalar: \n 1. Ad minimum 2 herfden ibaret olmalidir! \n 2. Isci Limiti minimum 1 ola biler! \n 3. Isci geliri minimum 250 ola biler!");
                        operationnumber = 2;
                        goto caseekshal;
                    }
                    break;
                case 3:
                    Console.Write("Deyisiklik edilecek Departamentin Adi : ");
                    name = Console.ReadLine();
                    if (hrm.Departments.Exists(x => x.Name.Contains(name)))
                    {
                        Console.WriteLine("Departamentin adi : " + hrm.Departments.Find(x => x.Name.Contains(name)).Name
                            + "\t Departamentin isci limiti : " + hrm.Departments.Find(x => x.Name.Contains(name)).WorkerLimit
                            + "\t Departamentin gelir limiti : " + hrm.Departments.Find(x => x.Name.Contains(name)).SalaryLimit);
                        Console.Write("Departamentin yeni adini daxil edin : ");
                        string newname = Console.ReadLine();
                        hrm.EditDepartments(name, newname);
                    }
                    else
                    {
                        Console.WriteLine("Bu adda bir Departament movcud deyildir!\n\n");
                        operationnumber = 3;
                        goto casemenuekshal;
                    }
                    break;
                case 4:
                    foreach (var department in hrm.Departments)
                    {
                        foreach (var employee in department.Employees)
                        {
                            Console.WriteLine("Isci Nomresi : " + employee.No
                                + "\tIsci Ad ve Soyadi : " + employee.Fullname
                                + "\tIscinin Departamentinin adi : " + employee.DepartmentName
                                + "\tIscinin Geliri : " + employee.Salary);
                        }
                    }
                    break;
                case 5:
                    Console.Write("Departamentin Adi : ");
                    name = Console.ReadLine();
                    if (hrm.Departments.Exists(x => x.Name.Contains(name)))
                    {
                        foreach (var item in hrm.Departments.Find(x => x.Name.Contains(name)).Employees)
                        {
                            Console.WriteLine("Isci Nomresi : " + item.No
                                    + "\tIsci Ad ve Soyadi : " + item.Fullname
                                    + "\tIscinin Departamentdeki Vezifesi : " + item.Position
                                    + "\tIscinin Geliri : " + item.Salary);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Bu adda bir Departament movcud deyildir!\n\n");
                        operationnumber = 5;
                        goto casemenuekshal;
                    }
                    break;
                case 6:
                    Console.Write("Isci Adi ve Soyadi : ");
                    name = Console.ReadLine();
                    Console.Write("Iscinin Vezifesi : ");
                    string position = Console.ReadLine();
                    Console.Write("Iscinin Geliri : ");
                    int salary = int.Parse(Console.ReadLine());
                    Console.Write("Isci calisdigi Departamentin adi : ");
                    string dpname = Console.ReadLine();
                    if (position.Length >= 2 && salary >= 250 && hrm.Departments.Exists(x => x.Name.Contains(dpname)))
                    {
                        hrm.AddEmployee(name, position, salary, dpname);
                    }
                    else
                    {
                        Console.WriteLine("Sehvlik var! Qaydalar: \n 1. Vezife adi minimum 2 herfden ibaret olmalidir! \n 2. Iscinin Geliri minimum 250 ola biler! \n 3. Daxil etdiyiniz Departamentin movcud olduguna emin olun!");
                        operationnumber = 6;
                        goto caseekshal;
                    }
                    break;
                case 7:
                    bool t = true;
                    Console.Write("Deyisiklik edilecek Iscinin nomresi : ");
                    string number = Console.ReadLine();
                    foreach (var department in hrm.Departments)
                    {
                        foreach (var employee in department.Employees)
                        {
                            if (employee.No == number)
                            {
                                t = true;
                                Console.WriteLine("Iscinin Adi ve Soyadi : " + employee.Fullname
                                    + "\tIscinin Geliri : " + employee.Salary
                                    + "\tIscinin Vezifesi : " + employee.Position);
                                Console.Write("Iscinin yeni Gelirini daxil edin : ");
                                salary = int.Parse(Console.ReadLine());
                                Console.Write("Iscinin yeni Vezifesini daxil edin : ");
                                position = Console.ReadLine();
                                hrm.EditEmployee(number, salary, position);
                                break;
                            }
                            else
                                t = false;
                        }
                        if (t)
                        {
                            break;
                        }
                    }
                    if (t == false)
                    {
                        Console.WriteLine("Bele bir isci nomresi movcud deyildir!");
                        goto casemenuekshal;
                    }
                    break;
                case 8:
                    Console.Write("Silinecek Iscinin nomresi : ");
                    number = Console.ReadLine();
                    Console.Write("Isci calisdigi Departamentin adi : ");
                    dpname = Console.ReadLine();
                    hrm.RemoveEmployee(number, dpname);
                    break;
            }
            //Console.WriteLine("Departamentler : ");
            //foreach (var item in hrm.Departments)
            //{
            //    Console.WriteLine(item.Name + "  " + item.WorkerLimit + "  " + item.SalaryLimit);
            //}
            //Console.WriteLine("Isciler : ");
            //foreach (var department in hrm.Departments)
            //{
            //    foreach (var employee in department.Employees)
            //    {
            //        Console.WriteLine("Isci Nomresi : " + employee.No
            //            + "\tIsci Ad ve Soyadi : " + employee.Fullname
            //            + "\tIscinin Departamentinin adi : " + employee.DepartmentName
            //            + "\tIscinin Geliri : " + employee.Salary);
            //    }
            //}
            Console.Read();
        }
    }
}
