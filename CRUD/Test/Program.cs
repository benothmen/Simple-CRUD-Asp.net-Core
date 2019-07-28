using System;
using TestAsp.Models;
namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new CatalogueDbContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();
               /* db.Categories.Add(
                    new Categorie { NomCatgegorie= "Catgegorie1" }
                    );
                db.Categories.Add(
                    new Categorie { NomCatgegorie = "Catgegorie2" }
                    );*/
                db.Produits.Add(new Produit
                {
                    Designation = "Designation4",
                    Prix = 100,
                    Quantite = 10,
                    CategorieID = 7
                });
                db.Produits.Add(new Produit
                {
                    Designation = "Designation7",
                    Prix = 200,
                    Quantite = 20,
                    CategorieID = 7
                });
                db.Produits.Add(new Produit
                {
                    Designation = "Designation6",
                    Prix = 300,
                    Quantite = 30,
                    CategorieID = 7
                });
                db.SaveChanges();
            }
        }
    }
}
