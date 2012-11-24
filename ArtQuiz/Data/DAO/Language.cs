using System.Data.Linq.Mapping;

namespace ArtQuiz.Data.DAO
{
    [Table]
    public class Language
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public string[] Name
        {
            get;
            set;
        }
    }
}