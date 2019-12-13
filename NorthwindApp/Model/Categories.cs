using System.IO;

namespace Model
{
    public class Categories
    {
        private int categoryID;
        private string categoryName;
        private string description;
        private byte[] picture;

        private Categories(CategoriesBuilder builder)
        {
            this.categoryID = builder.GetCategoryID;
            this.CategoryName = builder.GetCategoryName;
            this.description = builder.GetDescription;
            this.picture = builder.GetPictureField;
        }

        public sealed class CategoriesBuilder
        {
            //required
            private readonly int categoryID;
            private readonly string categoryName;

            //optional
            private string description = null;
            private byte[] picture = null;

            public int GetCategoryID
            {
                get
                {
                    return categoryID;
                }
            }

            public string GetCategoryName
            {
                get
                {
                    return categoryName;
                }
            }

            public string GetDescription
            {
                get
                {
                    return description;
                }
            }

            public byte[] GetPictureField
            {
                get
                {
                    return picture;
                }
            }
            public CategoriesBuilder()
            {
                    
            }
            public CategoriesBuilder(int categoryID, string categoryName)
            {
                this.categoryID = categoryID;
                this.categoryName = categoryName;
            }

            public CategoriesBuilder(string categoryName)
            {
                this.categoryName = categoryName;
            }

            public CategoriesBuilder(string description, byte[] picture)
            {
                this.description = description;
                this.picture = picture;
            }

            public CategoriesBuilder Description(string value)
            {
                description = value;
                return this;
            }

            public CategoriesBuilder Picture(byte[] value)
            {
                picture = value;
                return this;
            }

            
            public Categories Build()
            {
                return new Categories(this);
            }

            public byte[] GetPicture(string filePath)
            {
                FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                BinaryReader reader = new BinaryReader(stream);

                byte[] photo = reader.ReadBytes((int)stream.Length);

                reader.Close();
                stream.Close();

                return photo;
            }
        }

        public int CategoryID
        {
            get
            {
                return categoryID;
            }
            set
            {
                categoryID = value;
            }
        }

        public string CategoryName
        {
            get
            {
                return categoryName;
            }
            set
            {
                categoryName = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public byte[] Picture
        {
            get
            {
                return picture;
            }
            set
            {
                picture = value;
            }
        }
    }
}
