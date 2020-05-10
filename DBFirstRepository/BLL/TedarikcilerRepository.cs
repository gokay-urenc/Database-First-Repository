using DBFirstRepository.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstRepository.BLL
{
    public class TedarikcilerRepository : IService<Supplier>
    {
        NORTHWNDEntities db = new NORTHWNDEntities();
        public void Duzenle(Supplier model)
        {
            Supplier orjinalKat = Bul(model.SupplierID);
            orjinalKat.CompanyName = model.CompanyName;
            orjinalKat.ContactName = model.ContactName;
            orjinalKat.ContactTitle = model.ContactTitle;
            orjinalKat.City = model.City;
            orjinalKat.Country = model.Country;
            orjinalKat.Address = model.Address;
            db.SaveChanges();
        }

        public void Ekle(Supplier param)
        {
            db.Suppliers.Add(param);
            db.SaveChanges();
        }

        public List<Supplier> Listele()
        {
            return db.Suppliers.ToList();
        }

        public void Sil(int id)
        {
            Supplier silinecekkat = Bul(id);
            db.Suppliers.Remove(silinecekkat);
            db.SaveChanges();
        }

        public Supplier Bul(int id)
        {
            return db.Suppliers.Find(id);
        }
    }
}