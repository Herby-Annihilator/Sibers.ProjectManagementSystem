using Sibers.ProjectManagementSystem.Services.WebApiClients.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sibers.ProjectManagementSystem.Services.WebApiClients
{
    public class DefaultClient<TDto> : IClient<TDto>
    {
        protected HttpClient client;
        protected JsonSerializerOptions options;
        public DefaultClient(HttpClient client)
        {
            this.client = client;
            options = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
            };
        }
        public async Task<TDto> AddEntityAsync(TDto dto, CancellationToken cancellationToken = default)
        {
            var response = await client.PostAsJsonAsync("", dto, options, cancellationToken)
               .ConfigureAwait(false);
            var result = await response
               .EnsureSuccessStatusCode()
               .Content
               .ReadFromJsonAsync<TDto>(options: options, cancellationToken: cancellationToken)
               .ConfigureAwait(false);
            return result;
        }

        public async Task<TDto> DeleteEntityAsync(TDto dto, CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "")
            {
                Content = JsonContent.Create(dto, options: options)
            };
            var response = await client.SendAsync(request, cancellationToken).ConfigureAwait(false);
            if (response.StatusCode == HttpStatusCode.NotFound)
                return default;
            var result = await response
               .EnsureSuccessStatusCode()
               .Content
               .ReadFromJsonAsync<TDto>(options: options, cancellationToken: cancellationToken)
               .ConfigureAwait(false);
            return result;
        }

        public async Task<ICollection<TDto>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await client.GetFromJsonAsync<ICollection<TDto>>("", options, cancellationToken)
            .ConfigureAwait(false);
        public async Task<TDto> GetEntityByIdAsync(int id, CancellationToken cancellationToken = default) =>
            await client.GetFromJsonAsync<TDto>($"get/{id}", options, cancellationToken)
            .ConfigureAwait(false);

        public async Task<TDto> UpdateEntityAsync(TDto dto, CancellationToken cancellationToken = default)
        {
            var response = await client.PutAsJsonAsync("", dto, options, cancellationToken)
                .ConfigureAwait(false);
            var result = await response
               .EnsureSuccessStatusCode()
               .Content
               .ReadFromJsonAsync<TDto>(options: options, cancellationToken: cancellationToken)
               .ConfigureAwait(false);
            return result;
        }
    }
}
