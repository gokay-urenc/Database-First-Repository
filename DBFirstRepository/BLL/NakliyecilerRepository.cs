using DBFirstRepository.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstRepository.BLL
{
    public class NakliyecilerRepository : IService<Shipper>
    {
        NORTHWNDEntities db = new NORTHWNDEntities();
        public void Duzenle(Shipper model)
        {
            Shipper orjinalKat = Bul(model.ShipperID);
            orjinalKat.CompanyName = model.CompanyName;
            orjinalKat.Phone = model.Phone;
            db.SaveChanges();
        }

        public void Ekle(Shipper param)
        {
            db.Shippers.Add(param);
            db.SaveChanges();
        }

        public List<Shipper> Listele()
        {
            return db.Shippers.ToList();
        }

        public void Sil(int id)
        {
            Shipper silinecekkat = Bul(id);
            db.Shippers.Remove(silinecekkat);
            db.SaveChanges();
        }

        public Shipper Bul(int id)
        {
            return db.Shippers.Find(id);
        }
    }
}