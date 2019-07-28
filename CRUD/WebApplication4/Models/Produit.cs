using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAsp.Models
{   [System.ComponentModel.DataAnnotations.Schema.Table("PRODUITS")]
    public class Produit
    {   [System.ComponentModel.DataAnnotations.Key]
        public int ProduitID { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MinLength(5), System.ComponentModel.DataAnnotations.MaxLength(25)]
        public string Designation { get; set; }
        [System.ComponentModel.DataAnnotations.Range(10,100000)]
        public double Prix { get; set; }
        public int Quantite { get; set; }
        public int CategorieID { get; set; }
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("CategorieID")]
        public virtual Categorie Categorie { get; set; }
    }
}
