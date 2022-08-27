using Sibers.ProjectManagementSystem.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.ProjectManagementSystem.Services.Web.Repositories
{
    public class WebRepository<TEntity> : ICrudRepository<TEntity> where TEntity : class
    {
        private HttpClient _client;
        public WebRepository(HttpClient httpClient)
        {
            _client = httpClient;
        }
        public bool AutoSaveChanges { get; set; } = true;

        public TEntity AddEntity(TEntity entity)
        {
            var response = _client.PostAsJsonAsync("", entity).Result;
            var result = response
               .EnsureSuccessStatusCode()
               .Content
               .ReadFromJsonAsync<TEntity>()
               .Result;
            return result;
        }

        public async Task<TEntity> AddEntityAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var response = await _client.PostAsJsonAsync("", entity, cancellationToken)
                .ConfigureAwait(false);
            var result = await response
               .EnsureSuccessStatusCode()
               .Content
               .ReadFromJsonAsync<TEntity>(cancellationToken: cancellationToken)
               .ConfigureAwait(false);
            return result;
        }

        public TEntity DeleteEntity(int id)
        {
            TEntity entity = GetById(id);
            if (entity == default)
                return default;
            return DeleteEntity(entity);
        }

        public TEntity DeleteEntity(TEntity entity)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "")
            {
                Content = JsonContent.Create(entity)
            };
            var response = _client.SendAsync(request).Result;
            if (response.StatusCode == HttpStatusCode.NotFound)
                return default;
            var result = response
               .EnsureSuccessStatusCode()
               .Content
               .ReadFromJsonAsync<TEntity>()
               .Result;
            return result;
        }

        public async Task<TEntity> DeleteEntityAsync(int id, CancellationToken cancellationToken = default)
        {
            TEntity entity = await GetByIdAsync(id).ConfigureAwait(false);
            if (entity == default)
                return default;
            return await DeleteEntityAsync(entity).ConfigureAwait(false);
        }

        public async Task<TEntity> DeleteEntityAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "")
            {
                Content = JsonContent.Create(entity)
            };
            var response = await _client.SendAsync(request, cancellationToken).ConfigureAwait(false);
            if (response.StatusCode == HttpStatusCode.NotFound)
                return default;
            var result = await response
               .EnsureSuccessStatusCode()
               .Content
               .ReadFromJsonAsync<TEntity>(cancellationToken: cancellationToken)
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
                    _client.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<TEntity> GetAlL() => _client.GetFromJsonAsync<IEnumerable<TEntity>>("").Result;

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await _client.GetFromJsonAsync<IEnumerable<TEntity>>("", cancellationToken)
            .ConfigureAwait(false);

        public TEntity GetById(int id) => _client.GetFromJsonAsync<TEntity>($"get/{id}").Result;

        public async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
            await _client.GetFromJsonAsync<TEntity>($"get/{id}", cancellationToken)
            .ConfigureAwait(false);

        public bool SaveChanges()
        {
            return true;
        }

        public Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return Task.Factory.StartNew(() => true);
        }

        public TEntity UpdateEntity(TEntity entity)
        {
            var response = _client.PutAsJsonAsync("", entity).Result;
            var result = response
               .EnsureSuccessStatusCode()
               .Content
               .ReadFromJsonAsync<TEntity>()
               .Result;
            return result;
        }

        public async Task<TEntity> UpdateEntityAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var response = await _client.PutAsJsonAsync("", entity, cancellationToken)
                .ConfigureAwait(false);
            var result = await response
               .EnsureSuccessStatusCode()
               .Content
               .ReadFromJsonAsync<TEntity>(cancellationToken: cancellationToken)
               .ConfigureAwait(false);
            return result;
        }
    }
}
