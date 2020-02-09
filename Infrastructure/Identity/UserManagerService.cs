using Auth0.AuthenticationApi.Models;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Bridge.Application.Common.Interfaces;
using Bridge.Application.Common.Models;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Bridge.Infrastructure.Identity
{
    public class UserManagerService : IUserManager, IDisposable
    {
        private readonly AuthManagementApiConnectionOptions managementClientTokenRequest;
        private ManagementApiClient _managementApiClient;
        private DateTime tokenExpiresOn;
        private AccessTokenResponse _managementApiClientAccessToken;
        private ClientCredentialsTokenRequest cc;
        public UserManagerService(IOptions<AuthManagementApiConnectionOptions> optionsAccessor)
        {
            managementClientTokenRequest = optionsAccessor.Value;
            _managementApiClient = new ManagementApiClient("token", "AUTH0_DOMAIN");
            RenewAccessToken();
        }

        private void RenewAccessToken()
        {
            var restClient = new RestClient($"https://{managementClientTokenRequest.TenantDomain}/oauth/token");
            var restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("content-type", "application/x-ww-form-urlencoded");
            restRequest.AddParameter("application/x-www-form-urlencoded", $"grant_type=client_credentials&client_id={managementClientTokenRequest.ClientId}&client_secret={managementClientTokenRequest.ClientAudience}&audience={managementClientTokenRequest.ClientAudience}", ParameterType.RequestBody);
            var response = restClient.Execute<AccessTokenResponse>(restRequest);
            _managementApiClientAccessToken = response.Data;

            if (response.StatusCode != HttpStatusCode.OK) throw new Exception($"Could not get API token. Error: ({response.ErrorMessage})");
            _managementApiClient = new ManagementApiClient(_managementApiClientAccessToken.AccessToken, new Uri($"https://{managementClientTokenRequest.TenantDomain}/oauth/token"));
            tokenExpiresOn = DateTime.Now.AddSeconds(_managementApiClientAccessToken.ExpiresIn);
        }

        public Task<Result> DeleteUserAsync(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<(Result Result, string UserId)> CreateUserAsync(string firstName, string lastName, string userName, string email, string password)
        {
            if (tokenExpiresOn <= DateTime.Now)
                RenewAccessToken();

            var userCreateRequest = new UserCreateRequest
            {
                FirstName = firstName,
                LastName = lastName,
                UserName = userName,
                Email = email,
                Password = password,
                Connection = managementClientTokenRequest.DatabaseConnectionId,
            };
            throw new NotImplementedException();
        }

        public async Task<Result> CreateClientAsync(string clientName, string clientDescription)
        {
            try
            {
                await _managementApiClient.Clients.CreateAsync(new ClientCreateRequest
                {
                    Name = clientName,
                    Description = clientDescription,
                    ApplicationType = ClientApplicationType.Spa,
                }).ConfigureAwait(true); 
            }
            catch (Exception ex)
            {
                return Result.Failure(new List<string> { ex.Message });
                throw;
            }
            return Result.Success();
        }

        public async Task<Result> EditClientAsync(string clientId, string newName, string description, string newLogoUri)
        {
            try
            {
                await _managementApiClient.Clients.UpdateAsync(clientId, new ClientUpdateRequest
                {
                    Name = newName,
                    Description = description,
                    LogoUri = newLogoUri
                }).ConfigureAwait(true);
            }
            catch (Exception ex)
            {
                return Result.Failure(new List<string> { ex.Message });
                throw;
            }
            throw new NotImplementedException();
        }

        public async Task<Result> BlockClientAsync(string clientId)
        {
            try
            {

            }
            catch (Exception ex)
            {
                return Result.Failure(new List<string> { ex.Message });
                throw;
            }
            throw new NotImplementedException();
        }

        public Task<Result> GetClients()
        {
            throw new NotImplementedException();
        }

        public Task<Result> GetClient(string clientId)
        {
            throw new NotImplementedException();
        }

        public Task<Result> CreateClientAsync(string clientId)
        {
            throw new NotImplementedException();
        }

        public virtual void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}