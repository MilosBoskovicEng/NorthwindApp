using Model;
using System.Collections.Generic;

namespace DAL
{
    public interface ITerritories
    {
        List<Territories> getAllTerritories();
        Territories getTerritoryById(string territoryID);
        string addTerritory(Territories territory);
        string updateTerritory(Territories territory);
        int deleteTerritory(string territoryID);
    }
}
