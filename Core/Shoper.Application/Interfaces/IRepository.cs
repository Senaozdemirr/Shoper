using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoper.Application.Interfaces
{
    public interface IRepository<T> where T : class //T:entity(kategori) alıp gönderiyoruz.
    {
        //Update,create,delete icin metotlar yazıyorum
        Task<List<T>> GetAllAsync();    //tüm kategorileri alabilecegimiz metot, (T:kategori)
        Task<T> GetByIdAsync(int id); //t:dönülecek kategori degeri, id'nin bulunduğu kategori değerini dön.
        Task CreateAsync(T entity);     //entity türüne göre oluşturma
        Task UpdateAsync(T entity);     //güncelleme icin
        Task DeleteAsync(T entity);       //silme icin
        
    }
}