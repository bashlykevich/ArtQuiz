using System.Data.Linq.Mapping;
using System.Data.Linq;
namespace ArtQuiz.Data.DAO
{
    [Table]
    public class Art
    {
        private EntitySet<Artist> artistsRef;

        public Art()
        {
            this.artistsRef = new EntitySet<Artist>(this.OnArtistAdded, this.OnArtistRemoved);
        }

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
        [Association(Name = "FK_Art_Artists", Storage = "artistsRef", ThisKey = "ID", OtherKey = "ArtID")]
        public EntitySet<Artist> Artists
        {
            get
            {
                return this.artistsRef;
            }
        }

        private void OnArtistAdded(Artist artist)
        {
            artist.Art = this;
        }

        private void OnArtistRemoved(Artist artist)
        {
            artist.Art = null;
        }
    }
}