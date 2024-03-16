var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.EliteFlex_ApiService>("apiservice");

builder.AddProject<Projects.EliteFlex_Web>("webfrontend")
    .WithReference(apiService);

builder.Build().Run();