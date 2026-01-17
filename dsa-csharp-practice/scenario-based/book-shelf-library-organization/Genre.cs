namespace BookShelf.Models
{
    public class Genre
    {
        private string name;

        public Genre(string name)
        {
            this.name=name;
        }

        public string GetName()
        {
            return name;
        }

        public override string ToString()
        {
            return name;
        }

        public override bool Equals(object obj)
        {
            if(obj==null||!(obj is Genre))
            {
                return false;
            }

            Genre other=(Genre)obj;
            return name==other.name;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode();
        }
    }
}
