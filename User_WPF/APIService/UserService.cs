using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using User_WPF.Entities;
using User_WPF.Models.Users;
namespace User_WPF.APIService;

public interface IUserService
{
    Task<HttpResponseMessage> Authenticate(AuthenticateRequest authenticateRequest);
    Task<HttpResponseMessage> Register(RegisterRequest registerRequest);
    Task<HttpResponseMessage> GetAll();
    Task<HttpResponseMessage> GetAuthenticatedUser();
    Task<HttpResponseMessage> GetAuthenticatedUserId();

}

public class UserService : IUserService
{
    public async Task<HttpResponseMessage> Authenticate(AuthenticateRequest authenticateRequest)
    {
        using (var client = new HttpClient())
        {
            // define URI
            var endpoint = new Uri("http://localhost:4000/users/authenticate");

            // define the payload to send to API 
            var payload = new StringContent(JsonConvert.SerializeObject(authenticateRequest), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(endpoint, payload);

            var currentUser = JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync());

            // returns a HttpResponseMessage object which needs to be deserialized further down to get token value
            return response;

        }
    }

    public async Task<HttpResponseMessage> Register(RegisterRequest registerRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<HttpResponseMessage> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> GetAuthenticatedUser()
    {
        throw new NotImplementedException();
    }

    public Task<HttpResponseMessage> GetAuthenticatedUserId()
    {
        throw new NotImplementedException();
    }
}