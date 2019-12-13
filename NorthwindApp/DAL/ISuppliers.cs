using Model;
using System.Collections.Generic;

namespace DAL
{
    public interface ISuppliers
    {
        List<Suppliers> getAllSuppliers();
        Suppliers getSupplierById(int supplierID);
        int addSupplier(Suppliers supplier);
        int updateSupplier(Suppliers supplier);
        int deleteSupplier(int supplierID);
    }
}
