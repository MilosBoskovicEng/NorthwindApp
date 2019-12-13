namespace Model
{
    public class Region
    {
        private int regionID;
        private string regionDescription;

        public Region()
        {

        }

        public Region(int regionID, string regionDescription)
        {
            this.regionID = regionID;
            this.regionDescription = regionDescription;
        }

        public Region(string regionDescription)
        {
            this.regionDescription = regionDescription;
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

        public string RegionDescription
        {
            get
            {
                return regionDescription;
            }
            set
            {
                regionDescription = value;
            }
        }
    }
}
