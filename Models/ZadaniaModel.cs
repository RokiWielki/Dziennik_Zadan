using MessagePack;
using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dziennik_Zadan.Models
{
    [Table("Zadania")]
    public class ZadaniaModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int ZadaniaId { get; set; }
        [DisplayName("Nazwa")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage ="Wymagane !!")]
        [MaxLength(50)]
        public string Nazwa { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Wymagane !!")]
        [MaxLength(1000)]
        public string Wytyczne { get; set; }
        public bool Zrobione { get; set; }

    }
}
