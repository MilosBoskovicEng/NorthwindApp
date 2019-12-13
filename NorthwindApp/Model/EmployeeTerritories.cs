namespace Model
{
    public class EmployeeTerritories
    {
        private int employeeID;
        private string territoryID;

        public EmployeeTerritories()
        {

        }

        public EmployeeTerritories(int employeeID, string territoryID)
        {
            this.employeeID = employeeID;
            this.territoryID = territoryID;
        }

        public int EmployeeID
        {
            get
            {
                return employeeID;
            }
            set
            {
                employeeID = value;
            }
        }

        public string TerritoryID
        {
            get
            {
                return territoryID;
            }
            set
            {
                territoryID = value;
            }
        }
    }
}
