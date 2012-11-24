using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace ArtQuiz.Data.DAO
{
    [Table]
    public class Artist
    {
        private Nullable<int> artID;
        private EntityRef<Art> artRef = new EntityRef<Art>();

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
        [Column(Storage = "artID", DbType = "Int")]
        public int? ArtID
        {
            get
            {
                return this.artID;
            }
            set
            {
                this.artID = value;
            }
        }

        [Association(Name = "FK_Art_Artists", Storage = "artRef", ThisKey = "ArtID", OtherKey = "ID", IsForeignKey = true)]
        public Art Art
        {
            get
            {
                return this.artRef.Entity;
            }
            set
            {
                Art previousValue = this.artRef.Entity;
                if (((previousValue != value) || (this.artRef.HasLoadedOrAssignedValue == false)))
                {
                    if ((previousValue != null))
                    {
                        this.artRef.Entity = null;
                        previousValue.Artists.Remove(this);
                    }
                    this.artRef.Entity = value;
                    if ((value != null))
                    {
                        value.Artists.Add(this);
                        this.artID = value.ID;
                    }
                    else
                    {
                        this.artID = default(Nullable<int>);
                    }
                }
            }
        }
    }
}