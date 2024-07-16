using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EmployeeManagement.Data
{
    public class DbInitializer
    {
        public static void Initialize(EmployeeContext context)
        {
            // Verificar si la base de datos ya está poblada
            if (context.Employees.Any())
            {
                return;
            }

            var employees = new Employee[]
            {
                new Employee { RFC = "ABC123456XYZ", Name = "Mario", LastName = "Mario", BornDate = new DateTime(1985, 09, 13), Status = EmployeeStatus.Active },
                new Employee { RFC = "DEF789012UVW", Name = "Luigi", LastName = "Mario", BornDate = new DateTime(1987, 12, 15), Status = EmployeeStatus.Active },
                new Employee { RFC = "GHI345678RST", Name = "Link", LastName = "Hyrule", BornDate = new DateTime(1991, 07, 21), Status = EmployeeStatus.Active },
                new Employee { RFC = "JKL901234QRS", Name = "Zelda", LastName = "Hyrule", BornDate = new DateTime(1993, 05, 14), Status = EmployeeStatus.Inactive },
                new Employee { RFC = "MNO567890TUV", Name = "Samus", LastName = "Aran", BornDate = new DateTime(1986, 08, 01), Status = EmployeeStatus.Active },
                new Employee { RFC = "PQR234567WXY", Name = "Nathan", LastName = "Drake", BornDate = new DateTime(1985, 11, 03), Status = EmployeeStatus.Active },
                new Employee { RFC = "STU890123VWX", Name = "Lara", LastName = "Croft", BornDate = new DateTime(1973, 02, 14), Status = EmployeeStatus.Inactive },
                new Employee { RFC = "VWX456789YZA", Name = "Kratos", LastName = "Sparta", BornDate = new DateTime(1999, 06, 21), Status = EmployeeStatus.Active }
            };

            context.Employees.AddRange(employees);
            context.SaveChanges();
        }
    }
}
