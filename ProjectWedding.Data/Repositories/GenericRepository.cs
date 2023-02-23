using Newtonsoft.Json;
using ProjectWedding.Data.Configurations;
using ProjectWedding.Data.IRepositories;
using ProjectWedding.Domain.Commons;
using ProjectWedding.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWedding.Data.Repositories
{
    public class GenericRepository<TResult> : IGenericRepository<TResult> where TResult : Auditable
    {
        protected string path;
        protected long lastId;

        public GenericRepository()
        {
            if (typeof(TResult) == typeof(Client))
                path = DatabasePaths.CLIENTS_PATH;
            else if (typeof(TResult) == typeof(Restaurant))
                path = DatabasePaths.RESTAURANTS_PATH;
            else if (typeof(TResult) == typeof(Gift))
                path = DatabasePaths.GIFTS_PATH;
            else if (typeof(TResult) == typeof(Guest))
                path = DatabasePaths.GUESTS_PATH;
            else if (typeof(TResult) == typeof(Product))
                path = DatabasePaths.PRODUCTS_PATH;
        }
        public async Task<TResult> CreateAsync(TResult value)
        {
            // values listiga GetAllAsync() orqali barcha valuelar jamlangan listni oldik
            var values = await GetAllAsync();
            // kiritilayotgan value Id sini lastId dan bittaga oshishini va undan farq qilishini ko'rsatdik
            value.Id = ++lastId;
            // createdAt da ham value.Id kabi ish bajarilmoqda
            value.CreatedAt = DateTime.UtcNow;

            // va values listiga value ni qo'shib qo'ydik (tepada o'zgartirgan edik)
            values.Add(value);

            // json o'zgaruvchiga values ni SeraializeObject() orqali json formatida o'zlashtirdik
            var json = JsonConvert.SerializeObject(values, Formatting.Indented);
            // va olingan json ni Path filega yozib qo'ydik
            await File.WriteAllTextAsync(path, json);

            // va oxirida olingan value qaytarildi
            return value;

        }
        
        public async Task<bool> DeleteAsync(long id)
        {
            var values = await GetAllAsync();
            var value = values.FirstOrDefault(x => x.Id == id);

            // agar topilgan value null bo'lsa(ya'ni topilmasa)
            if (value is null)
                // false qaytardik
                return false;

            values.Remove(value);

            // jsonga o'girdik listni(values)
            var json = JsonConvert.SerializeObject(values, Formatting.Indented);
            // path ga olingan josn ni yozib qo'ydik
            await File.WriteAllTextAsync(path, json);

            // success uchun true qaytarildi
            return true;
        }

        public async Task<List<TResult>> GetAllAsync()
        {
            // models o'zgaruvchisiga Path da turgan filening ma'lumotlarini string ko'rinishida o'zlashtirdik
            string models = await File.ReadAllTextAsync(path);

            if (string.IsNullOrEmpty(models))
                models = "[]";

            // results listiga JsonConvert orqali jsondan List ko'rinishiga o'tkazib olib listni oldik
            List<TResult> results = JsonConvert.DeserializeObject<List<TResult>>(models);

            // va o'sha listni qaytardik
            return results;
        }

        public async Task<TResult> GetByIdAsync(long id)
        {
            var values = await GetAllAsync();
            return values.FirstOrDefault(x => x.Id == id);
        }

        

        public async Task<TResult> UpdateAsync(TResult value)
        {
            var values = await GetAllAsync();
            var model = values.FirstOrDefault(x => x.Id == value.Id);

            if (model is null)
                return null;

            
            // index o'zgaruvchisiga model ning values dagi indexini tengladik
            var index = values.IndexOf(model);
            // values  tarkibidan model ni o'chirib tashladik
            values.Remove(model);

            // modelning CreatedAt ini valuenikiga tengladik
            model.CreatedAt = value.CreatedAt;
            // UpdatedAt ini hozirgi vaqtga tengladik
            model.UpdatedAt = DateTime.UtcNow;

            // values ga index dagi o'ringa value ni Insert() orqali qo'shdik
            values.Insert(index, value);

            var json = JsonConvert.SerializeObject(values, Formatting.Indented);
            await File.WriteAllTextAsync(path, json);

            return model;
        }
    }
}
