using Model;
using System.Collections.Generic;

namespace DAL
{
    public interface IRegion
    {
        List<Region> getAllRegions();
        Region getRegionById(int regionID);
        int addRegion(Region region);
        int updateRegion(Region region);
        int deleteRegion(int regionID);
    }
}
