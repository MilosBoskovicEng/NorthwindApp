namespace Model
{
    public class Territories
    {
        private string territoryID;
        private string territoryDescription;
        private int regionID;

        public Territories()
        {

        }

        public Territories(string territoryID, string territoryDescription, int regionID)
        {
            this.territoryID = territoryID;
            this.territoryDescription = territoryDescription;
            this.regionID = regionID;
        }

        public Territories(string territoryDescription, int regionID)
        {
            this.territoryDescription = territoryDescription;
            this.regionID = regionID;
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

        public string TerritoryDescription
        {
            get
            {
                return territoryDescription;
            }
            set
            {
                territoryDescription = value;
            }
        }

        public int RegionID
        {
            get
            {
                return regionID;
            }
            set
            {
                regionID = value;
            }
        }
    }
}
