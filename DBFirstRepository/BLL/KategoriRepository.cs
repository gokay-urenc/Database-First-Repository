using DBFirstRepository.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstRepository.BLL
{
   public class KategoriRepository:IService<Category>
    {
        NORTHWNDEntities db = new NORTHWNDEntities();
        public void Duzenle(Category model)
        {
            Category orjinalKat = Bul(model.CategoryID);
            orjinalKat.CategoryName = model.CategoryName;
            orjinalKat.Description = model.Description;
            db.SaveChanges();
        }

        public void Ekle(Category param)
        {
            db.Categories.Add(param);
            db.SaveChanges();
        }

        public List<Category> Listele()
        {
            return db.Categories.ToList();
        }

        public void Sil(int id)
        {
            // 1. Yol:
            Category silinecekkat = Bul(id);
            db.Categories.Remove(silinecekkat);

            // 2. Yol:
            // db.Categories.Remove(Bul(id));

            db.SaveChanges();
        }

        public Category Bul(int id)
        {
           return db.Categories.Find(id);
        }
    }
}