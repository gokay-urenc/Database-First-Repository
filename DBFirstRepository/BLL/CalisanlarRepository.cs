using DBFirstRepository.BLL;
using DBFirstRepository.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstRepository.FormTanımlamalar
{
    public class CalisanlarRepository : IService<Employee>
    {
        NORTHWNDEntities db = new NORTHWNDEntities();
        public void Duzenle(Employee model)
        {
            Employee orjinalKat = Bul(model.EmployeeID);
            orjinalKat.FirstName = model.FirstName;
            orjinalKat.LastName = model.LastName;
            orjinalKat.Title = model.Title;
            orjinalKat.Address = model.Address;
            orjinalKat.City = model.City;
            orjinalKat.Country = model.Country;
            db.SaveChanges();
        }

        public void Ekle(Employee param)
        {
            db.Employees.Add(param);
            db.SaveChanges();
        }

        public List<Employee> Listele()
        {
            return db.Employees.ToList();
        }

        public void Sil(int id)
        {
            Employee silinecekkat = Bul(id);
            db.Employees.Remove(silinecekkat);
            db.SaveChanges();
        }

        public Employee Bul(int id)
        {
            return db.Employees.Find(id);
        }
    }
} 