# .Net Core OData
Refer: https://devblogs.microsoft.com/odata/asp-net-core-odata-now-available/#build-the-edm-model
1. install Microsoft.AspNetCore.OData
2. Create models and setup EDM model. It would look like the following
    ``` C#
    public static IEdmModel GetEdmModel()
    {
        ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
        builder.EntitySet<ParentData>("Users");
        builder.EntitySet<ChildData>("Roles");
        return builder.GetEdmModel();
    }
    ```
1. Register Services through Dependency Injection
Register the OData Services
    ``` C#
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // ...
            services.AddOData();
            // ...
        }
    }
1. Register the OData Endpoint. Add an OData route named "odata" with "odata" prefix
    ``` C#
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapODataRoute("odata", "odata", Models.Builder.GetEdmModel());

            });
    ```
1. Query the metadata https://localhost:44304/odata/$metadata. You can see the EMD model.
1. https://localhost:44304/api/Ping?$filter=Id eq 5&$select=hostname, message&$expand=computers