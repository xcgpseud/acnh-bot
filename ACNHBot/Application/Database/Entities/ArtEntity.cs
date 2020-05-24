using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ACNHBot.Application.Database.Entities
{
    public class ArtEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public bool Genuine { get; set; }

        public string Image { get; set; }

        public int SellPrice { get; set; }

        public string RealArtworkTitle { get; set; }
        
        public string Artist { get; set; }

        public string MuseumDescription { get; set; }

        public int InternalId { get; set; }
    }
}