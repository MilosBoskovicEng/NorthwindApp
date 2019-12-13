using Model;
using System.Collections.Generic;

namespace DAL
{
    public interface IShippers
    {
        List<Shippers> getAllShippers();
        Shippers getShipperById(int shipperID);
        int addShippers(Shippers customer);
        int updateShippers(Shippers customer);
        int deleteShippers(int shipperID);
    }
}
