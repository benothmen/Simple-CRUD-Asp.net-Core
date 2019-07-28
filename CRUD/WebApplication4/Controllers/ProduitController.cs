using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAsp.Models;

namespace TestAsp.Controllers
{
    public class ProduitController : Controller
    {
        public CatalogueDbContext catalogueDbContext { get; set; }

        public ProduitController(CatalogueDbContext catalogueDbContext)
        {
            this.catalogueDbContext = catalogueDbContext;
        }
        // GET: Produit
        public ActionResult Index(int page=0,int size=5,string recherche="")
        {
            int position = page * size;
            //IEnumerable<Produit> produits = catalogueDbContext.Produits.ToList();
            IEnumerable<Produit> produits = catalogueDbContext.Produits.Where(p => p.Designation.Contains(recherche)).Skip(position).Take(size).Include(p => p.Categorie).ToList();
            ViewBag.currentPage = page;
            int totalPages =  catalogueDbContext.Produits.Where(p => p.Designation.Contains(recherche)).ToList().Count / size;
            if (catalogueDbContext.Produits.Where(p => p.Designation.Contains(recherche)).ToList().Count % size != 0)
            {
                totalPages += 1;
            }
            ViewBag.recherche = recherche;
            ViewBag.totalPages = totalPages;
            return View("Produits",produits);
        }
        public IActionResult AddProduit()
        {
            Produit produit = new Produit();
            IEnumerable<Categorie> categories = catalogueDbContext.Categories.ToList();
           // List<Categorie> categoriesList = new List<Categorie>();
            
            ViewBag.categories = categories;
            return View("AddProduit",produit);
        }
        [HttpPost]
        public IActionResult EnregistrerProduit(Produit produit)
        {
            if (ModelState.IsValid)
            {
                catalogueDbContext.Produits.Add(produit);
                catalogueDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            IEnumerable<Categorie> categories = catalogueDbContext.Categories.ToList();
            // List<Categorie> categoriesList = new List<Categorie>();

            ViewBag.categories = categories;
            return View("AddProduit",produit);
        }
       
        public IActionResult Delete(int id)
        {
            Produit produit = catalogueDbContext.Produits.Where(p => p.ProduitID == id).First();
            if(produit != null)
            {
                catalogueDbContext.Produits.Remove(produit);
                catalogueDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("AddProduit", produit);
        }

    
    }
}