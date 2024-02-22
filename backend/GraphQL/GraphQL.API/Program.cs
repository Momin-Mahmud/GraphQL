using GraphQL.API.Schema.Mutations;
using GraphQL.API.Schema.Query;
using GraphQL.API.Schema.Query.Query;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddGraphQLServer()
    .AddMutationType<Mutation>()
    .AddQueryType<Query>();

var app = builder.Build();

app.MapGraphQL();


app.MapGet("/", () => "Hello World!");


app.Run();
