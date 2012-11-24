using System.Data.Linq;
using ArtQuiz.Data.DAO;

namespace ArtQuiz.Data
{
    public class ArtQuizDataContext : DataContext
    {
        public ArtQuizDataContext(string connectionString)
            : base(connectionString)
        {
        }

        public Table<Art> Arts
        {
            get
            {
                return this.GetTable<Art>();
            }
        }

        public Table<Artist> Artists
        {
            get
            {
                return this.GetTable<Artist>();
            }
        }
    }
}