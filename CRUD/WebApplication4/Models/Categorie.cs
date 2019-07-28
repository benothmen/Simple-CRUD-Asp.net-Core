using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Threading.Tasks;

namespace TestAsp.Models
{   [System.ComponentModel.DataAnnotations.Schema.Table("CATEGORIES")]
    public class Categorie
    {   [Key]
        public int CategorieID { get; set; }
        [StringLength(50)]
        public string NomCatgegorie { get; set; }
        public virtual ICollection<Produit> Produits { get; set; }
    }
}
