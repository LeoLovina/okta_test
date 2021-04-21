# okta
ref: https://developer.okta.com/blog/2018/02/01/secure-aspnetcore-webapi-token-auth
- When handling authentication for a server-to-server API, you really only have two options: HTTP basic auth or OAuth 2.0 client credentials.
- Create an application on OKta
- Add new scope "access_token"  ref: https://developer.okta.com/docs/guides/customize-authz-server/create-scopes/
## Api Client:
- OAuth 2.0 client credentials
- get token from Okta
```C#
var client = new HttpClient();
var client_id = this.oktaSettings.Value.ClientId;
var client_secret = this.oktaSettings.Value.ClientSecret;
var clientCreds = System.Text.Encoding.UTF8.GetBytes($"{client_id}:{client_secret}");

client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(clientCreds));
var postMessage = new Dictionary<string, string>();
postMessage.Add("grant_type", "client_credentials");
postMessage.Add("scope", "access_token");
var request = new HttpRequestMessage(HttpMethod.Post, this.oktaSettings.Value.TokenUrl)
{
    Content = new FormUrlEncodedContent(postMessage)
};
```
You must add the access_token on Okta
![access_token](./Document/access_token.png)

## Api
- validate the access token
  - call the Okta API's introspect endpoint
  - validate the token locally
  - install package ```Microsoft.AspNetCore.Authentication.JwtBearer```
  - enable JWT-based authentication
``` C# 
services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.Authority = "https://dev-82330891.okta.com/oauth2/default";
    options.Audience = "api://default";
    options.RequireHttpsMetadata = true;
});
```
The above setting must match the setting on Okta
![audience](./Document/api-audience.png)

## Read configuration values into C# object
1. define variables on appsettings.json
``` json
{
 "Okta": {
    "TokenUrl": "https://{yourOktaDomain}/oauth2/default/v1/token",
    "ClientId": "{clientId}",
    "ClientSecret": "{clientSecret}"
  }
}
```
2. declare class OktaSettings
```C#
namespace app.Models
{
    public class OktaSettings
    {
        public string TokenUrl { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
```  
3. add this new object to the services that can be injected by adding it to the ConfigureServices() method in the Startup.cs file. 
``` C#
 services.Configure<OktaSettings>(Configuration.GetSection("Okta")); 
```
4. get the oktaSettings injected from the application services
``` C#
    private readonly IOptions<OktaSettings> oktaSettings;
    public OktaTokenService(IOptions<OktaSettings> oktaSettings)
    {
        this.oktaSettings = oktaSettings;
    }
```   
# MediatR
- In-process messaging with no dependencies
- https://codeopinion.com/why-use-mediatr-3-reasons-why-and-1-reason-not/
    - Decoupling: decouple your application code from the top-level framework code
    - Application Requests: implement application request, not http request.
 - Example
    1. register MediatR handlers	
    ``` C#
    public void ConfigureServices(IServiceCollection services)
    {
        // omitted
        // register MediatR handlers
        services.AddMediatR(typeof(Startup));
        // omitted
    }
	```
    2. define 'request object'
    ```C#
    public class Ping : IRequest<string>
    {
        // IRequest<string> means data type 'string' is expected on response
        // the reqeust only define a property
        public DateTime SendingTime { get; set; } 
    }
    ```
    3. define 'handler'
    ``` C# 
    public class PingHandler : IRequestHandler<Ping, string>
    {
        // IRequestHandler<request type, response type>
        public Task<string> Handle(Ping request, CancellationToken cancellationToken)
        {
            return Task.FromResult($"Pong {request.SendingTime}");
        }
    }
    ```   
    4. call
    ``` C#
    private readonly IMediator _mediator;
    public PingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<PingController>
    [HttpGet]
    public async Task<string> Get(int id)
    {
        var response = await _mediator.Send(new Ping{ SendingTime = DateTime.Now});
        return response;
    }
    ```              

# Entity Framework
https://docs.microsoft.com/bs-cyrl-ba/ef/core/managing-schemas/migrations/projects?tabs=dotnet-core-cli
- open Package Manager Console
    - install necessary packages
    - Microsoft.EntityFrameworkCore.Design
    - Microsoft.EntityFrameworkCore.Tools
- change the 'Default project' to the project that contains DbContext 
- execute 'add-migration init' or 'add-migration init -o Persistence\Migration'
- To undo this action, use Remove-Migration.
- auto create database in Entity Framework Core
https://entityframework.net/knowledge-base/42355481/auto-create-database-in-entity-framework-core
``` C#
using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();

    // create a new database  
    //context.Database.EnsureDeleted();
    //context.Database.EnsureCreated();
}
```
