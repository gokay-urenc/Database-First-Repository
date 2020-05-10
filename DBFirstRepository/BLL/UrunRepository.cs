using DBFirstRepository.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstRepository.BLL
{
    public class UrunRepository : IService<Product>
    {
        NORTHWNDEntities db = new NORTHWNDEntities();
        public void Duzenle(Product model)
        {
            Product orjinalKat = Bul(model.ProductID);
            orjinalKat.ProductName = model.ProductName;
            orjinalKat.Category = model.Category;
            orjinalKat.UnitPrice = model.UnitPrice;
            orjinalKat.UnitsInStock = model.UnitsInStock;
            db.SaveChanges();
        }

        public void Ekle(Product param)
        {
            db.Products.Add(param);
            db.SaveChanges();
        }

        public List<Product> Listele()
        {
            return db.Products.ToList();
        }

        public void Sil(int id)
        {
            Product silinecekUrun = db.Products.Find(id);
            db.Products.Remove(silinecekUrun);
            db.SaveChanges();
        }

        public Product Bul(int id)
        {
            return db.Products.Find(id);
        }
    }
}