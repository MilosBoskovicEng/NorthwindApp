using Model;
using System.Collections.Generic;

namespace DAL
{
    public interface IEmployees
    {
        List<Employees> getAllEmployees();
        Employees getEmployeeById(int employeeID);
        int addEmployee(Employees employee);
        int updateEmployee(Employees employee);
        int deleteEmployee(int employeeID);
    }
}
