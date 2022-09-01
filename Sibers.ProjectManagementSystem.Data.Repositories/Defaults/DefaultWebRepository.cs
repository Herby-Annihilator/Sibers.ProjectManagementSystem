using Sibers.ProjectManagementSystem.Data.Entities.Base;
using Sibers.ProjectManagementSystem.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sibers.ProjectManagementSystem.Data.Repositories.Defaults
{
    public class DefaultWebRepository<TEntity> : ICrudRepository<TEntity> where TEntity : Entity
    {
        protected HttpClient client;
        protected JsonSerializerOptions options;
        public DefaultWebRepository(HttpClient httpClient)
        {
            client = httpClient;
            options = new JsonSerializerOptions(JsonSerializerDefaults.Web)
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                //PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = null,
                WriteIndented = true,
            };
            
        }
        public virtual bool AutoSaveChanges { get; set; } = true;

        public virtual TEntity AddEntity(TEntity entity)
        {
            var response = client.PostAsJsonAsync("", entity, options).Result;
            var result = response
               .EnsureSuccessStatusCode()
               .Content
               .ReadFromJsonAsync<TEntity>(options)
               .Result;
            return result;
        }

        public virtual async Task<TEntity> AddEntityAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            //string text = JsonSerializer.Serialize(entity, typeof(TEntity), options);
            //File.WriteAllText(@"C:\Users\Rukin\json.txt", text);
            var response = await client.PostAsJsonAsync("", entity, options, cancellationToken)
                .ConfigureAwait(false);
            var result = await response
               .EnsureSuccessStatusCode()
               .Content
               .ReadFromJsonAsync<TEntity>(options: options, cancellationToken: cancellationToken)
               .ConfigureAwait(false);
            return result;
        }

        public virtual TEntity DeleteEntity(int id)
        {
            TEntity entity = GetById(id);
            if (entity == default)
                return default;
            return DeleteEntity(entity);
        }

        public virtual TEntity DeleteEntity(TEntity entity)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "")
            {
                Content = JsonContent.Create(entity, options: options)
            };
            var response = client.SendAsync(request).Result;
            if (response.StatusCode == HttpStatusCode.NotFound)
                return default;
            var result = response
               .EnsureSuccessStatusCode()
               .Content
               .ReadFromJsonAsync<TEntity>(options)
               .Result;
            return result;
        }

        public virtual async Task<TEntity> DeleteEntityAsync(int id, CancellationToken cancellationToken = default)
        {
            TEntity entity = await GetByIdAsync(id).ConfigureAwait(false);
            if (entity == default)
                return default;
            return await DeleteEntityAsync(entity).ConfigureAwait(false);
        }

        public virtual async Task<TEntity> DeleteEntityAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "")
            {
                Content = JsonContent.Create(entity, options: options)
            };
            var response = await client.SendAsync(request, cancellationToken).ConfigureAwait(false);
            if (response.StatusCode == HttpStatusCode.NotFound)
                return default;
            var result = await response
               .EnsureSuccessStatusCode()
               .Content
               .ReadFromJsonAsync<TEntity>(options: options, cancellationToken: cancellationToken)
               .ConfigureAwait(false);
            return result;
        }

        protected bool disposed = false;
        protected void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    client.Dispose();
                }
            }
            disposed = true;
        }
        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual IEnumerable<TEntity> GetAlL() => client.GetFromJsonAsync<IEnumerable<TEntity>>("", options).Result;

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await client.GetFromJsonAsync<IEnumerable<TEntity>>("", options, cancellationToken)
            .ConfigureAwait(false);

        public virtual TEntity GetById(int id) => client.GetFromJsonAsync<TEntity>($"get /{id}", options).Result;

        public virtual async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
            await client.GetFromJsonAsync<TEntity>($"get/{id}", options, cancellationToken)
            .ConfigureAwait(false);

        public virtual bool SaveChanges()
        {
            return true;
        }

        public virtual Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return Task.Factory.StartNew(() => true);
        }

        public virtual TEntity UpdateEntity(TEntity entity)
        {
            var response = client.PutAsJsonAsync("", entity, options).Result;
            var result = response
               .EnsureSuccessStatusCode()
               .Content
               .ReadFromJsonAsync<TEntity>(options)
               .Result;
            return result;
        }

        public virtual async Task<TEntity> UpdateEntityAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var response = await client.PutAsJsonAsync("", entity, options, cancellationToken)
                .ConfigureAwait(false);
            var result = await response
               .EnsureSuccessStatusCode()
               .Content
               .ReadFromJsonAsync<TEntity>(options: options, cancellationToken: cancellationToken)
               .ConfigureAwait(false);
            return result;
        }
    }
}
