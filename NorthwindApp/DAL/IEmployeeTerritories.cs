using Model;
using System.Collections.Generic;

namespace DAL
{
    public interface IEmployeeTerritories
    {
        List<EmployeeTerritories> getAllEmployeeTerritories();
        EmployeeTerritories getEmployeeTerritoriesById(int employeeID, string territoryID);
        int addEmployeeTerritories(EmployeeTerritories employeeTerritories);
        int deleteEmployeeTerritories(int employeeID, string territoryID);
    }
}
