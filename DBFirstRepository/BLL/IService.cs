using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstRepository.BLL
{
   public interface IService<T>
    {
        // T, generic(şablon) tiptir. Interface'i kullanacak olan class bu T tipini miras alma sırasında belirtmelidir. 
        // Interface'i bir kontrat olarak düşünebiliriz. Interface'i kullanacak olan sınıf burada bulunan üyeleri doldurmak ve sahiplenmek zorundadır.
        void Ekle(T param);
        void Sil(int id);
        void Duzenle(T model);
        List<T> Listele();
    }
}