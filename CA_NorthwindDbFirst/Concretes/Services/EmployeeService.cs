using CA_NorthwindDbFirst.Abstracts.Interfaces;
using CA_NorthwindDbFirst.Models;
using System.Linq;

namespace CA_NorthwindDbFirst.Concretes.Services
{
    internal class EmployeeService : IEmployeeRepository
    {
        private readonly NorthwindContext _db;
        public EmployeeService()
        {
            _db = new NorthwindContext();
        }
        //select FirstName,LastName,YEAR(GETDATE())-YEAR(BirthDate) from Employees ORDER BY YEAR(GETDATE())-YEAR(BirthDate) desc
        public void GetEmployeeAge()
        {
            #region LinqToEntity
            var employees = _db.Employees.Select(x => new
            {
                Name = x.FirstName,
                Surname = x.LastName,
                Age = DateTime.Now.Year - x.BirthDate.Value.Year
            }).OrderByDescending(x => x.Age).ToList();

            foreach (var employee in employees)
            {
                var formatAge = $"{employee.Name} {employee.Surname} {employee.Age}";
                Console.WriteLine(formatAge);
            }
            #endregion

            #region LinqToSql
            //var employees = from e in _db.Employees
            //                orderby DateTime.Now.Year - e.BirthDate.Value.Year descending
            //                select new
            //                {
            //                    e.FirstName,
            //                    e.LastName,
            //                    Year = DateTime.Now.Year - e.BirthDate.Value.Year
            //                };
            //var query = employees.ToList();
            //foreach (var employee in query)
            //{
            //    string result = $"{employee.FirstName} {employee.LastName} {employee.Year}";
            //    Console.WriteLine(result);
            //}
            Console.WriteLine("Employees Count:" + employees.Count());
            #endregion
        }
    }
}
