using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PokemonAPI.WebService.Controllers;
using PokemonAPI.WebService.Services.CacheServices;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.Services;
using PokemonAPI.WebService.Services.ServicesAbstractions;
using Swashbuckle.Swagger.Model;

namespace PokemonAPI.WebService
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            // JSON options issue solved
            // http://stackoverflow.com/questions/39024354/asp-net-core-api-only-returning-first-result-of-list

            services
                .AddMvc(o =>
                {
                    o.ReturnHttpNotAcceptable = true;
                    o.RespectBrowserAcceptHeader = true;
                })
                .AddJsonOptions(o =>
                {
                    o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    o.SerializerSettings.Formatting = Formatting.Indented;

                    // Use Snake Case Naming
                    var resolver = o.SerializerSettings.ContractResolver;
                    var res = resolver as DefaultContractResolver;
                    if (res != null)
                        res.NamingStrategy = new SnakeCaseNamingStrategy(); // <<!-- this change the camelcasing
                });

            var connection = @"Server=(localdb)\MSSQLLocalDB;Database=veekun;Trusted_Connection=True;";
            services.AddDbContext<VeekunContext>(options => options
                .UseSqlServer(connection)
                .ConfigureWarnings(warnings => warnings.Throw(CoreEventId.IncludeIgnoredWarning)));

            // Add Memory Caching
            services.AddMemoryCache();

            // Add Services
            AddServices(services);
            AddCacheServices(services);

            // Inject an implementation of ISwaggerProvider with defaulted settings applied
            services.AddSwaggerGen();

            // Add the detail information for the API.
            services.ConfigureSwaggerGen(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "PokedexG API",
                    Description =
                        "All the Pokémon data you'll ever need, in one place, and easily accessible through a modern RESTful API.",
                    Contact =
                        new Contact
                        {
                            Name = "Philippe Matray",
                            Email = "phmatray@outlook.com",
                            Url = "http://phmatray.net"
                        }
                });

                //Determine base path for the application.
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;

                //Set the comments path for the swagger json and ui.
                options.IncludeXmlComments(basePath + "\\PokemonAPI.WebService.xml");
            });
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddTransient<IAbilitiesService, AbilitiesService>();
            services.AddTransient<IBerriesService, BerriesService>();
            services.AddTransient<IBerryFirmnessesService, BerryFirmnessesService>();
            services.AddTransient<IBerryFlavorsService, BerryFlavorsService>();
            services.AddTransient<ICharacteristicsService, CharacteristicsService>();
            services.AddTransient<IContestEffectsService, ContestEffectsService>();
            services.AddTransient<IContestTypesService, ContestTypesService>();
            services.AddTransient<IEggGroupsService, EggGroupsService>();
            services.AddTransient<IEncounterConditionsService, EncounterConditionsService>();
            services.AddTransient<IEncounterConditionValuesService, EncounterConditionValuesService>();
            services.AddTransient<IEncounterMethodsService, EncounterMethodsService>();
            services.AddTransient<IEvolutionChainsService, EvolutionChainsService>();
            services.AddTransient<IEvolutionTriggersService, EvolutionTriggersService>();
            services.AddTransient<IGendersService, GendersService>();
            services.AddTransient<IGenerationsService, GenerationsService>();
            services.AddTransient<IGrowthRatesService, GrowthRatesService>();
            services.AddTransient<IItemAttributesService, ItemAttributesService>();
            services.AddTransient<IItemCategoriesService, ItemCategoriesService>();
            services.AddTransient<IItemFlingEffectsService, ItemFlingEffectsService>();
            services.AddTransient<IItemPocketsService, ItemPocketsService>();
            services.AddTransient<IItemsService, ItemsService>();
            services.AddTransient<ILanguagesService, LanguagesService>();
            services.AddTransient<ILocationAreasService, LocationAreasService>();
            services.AddTransient<ILocationsService, LocationsService>();
            services.AddTransient<IMachinesService, MachinesService>();
            services.AddTransient<IMoveAilmentsService, MoveAilmentsService>();
            services.AddTransient<IMoveBattleStylesService, MoveBattleStylesService>();
            services.AddTransient<IMoveCategoriesService, MoveCategoriesService>();
            services.AddTransient<IMoveDamageClassesService, MoveDamageClassesService>();
            services.AddTransient<IMoveLearnMethodsService, MoveLearnMethodsService>();
            services.AddTransient<IMoveTargetsService, MoveTargetsService>();
            services.AddTransient<IMovesService, MovesService>();
            services.AddTransient<INaturesService, NaturesService>();
            services.AddTransient<IPalParkAreasService, PalParkAreasService>();
            services.AddTransient<IPokeathlonStatsService, PokeathlonStatsService>();
            services.AddTransient<IPokedexesService, PokedexesService>();
            services.AddTransient<IPokemonColorsService, PokemonColorsService>();
            services.AddTransient<IPokemonFormsService, PokemonFormsService>();
            services.AddTransient<IPokemonHabitatsService, PokemonHabitatsService>();
            services.AddTransient<IPokemonShapesService, PokemonShapesService>();
            services.AddTransient<IPokemonSpeciesService, PokemonSpeciesService>();
            services.AddTransient<IPokemonsService, PokemonsService>();
            services.AddTransient<IRegionsService, RegionsService>();
            services.AddTransient<IStatsService, StatsService>();
            services.AddTransient<ISuperContestEffectsService, SuperContestEffectsService>();
            services.AddTransient<ITypesService, TypesService>();
            services.AddTransient<IVersionGroupsService, VersionGroupsService>();
            services.AddTransient<IVersionsService, VersionsService>();
        }

        private static void AddCacheServices(IServiceCollection services)
        {
            services.AddTransient<IAbilitiesCacheService, AbilitiesCacheService>();
            services.AddTransient<IBerriesCacheService, BerriesCacheService>();
            services.AddTransient<IBerryFirmnessesCacheService, BerryFirmnessesCacheService>();
            services.AddTransient<IBerryFlavorsCacheService, BerryFlavorsCacheService>();
            services.AddTransient<ICharacteristicsCacheService, CharacteristicsCacheService>();
            services.AddTransient<IContestEffectsCacheService, ContestEffectsCacheService>();
            services.AddTransient<IContestTypesCacheService, ContestTypesCacheService>();
            services.AddTransient<IEggGroupsCacheService, EggGroupsCacheService>();
            services.AddTransient<IEncounterConditionsCacheService, EncounterConditionsCacheService>();
            services.AddTransient<IEncounterConditionValuesCacheService, EncounterConditionValuesCacheService>();
            services.AddTransient<IEncounterMethodsCacheService, EncounterMethodsCacheService>();
            services.AddTransient<IEvolutionChainsCacheService, EvolutionChainsCacheService>();
            services.AddTransient<IEvolutionTriggersCacheService, EvolutionTriggersCacheService>();
            services.AddTransient<IGendersCacheService, GendersCacheService>();
            services.AddTransient<IGenerationsCacheService, GenerationsCacheService>();
            services.AddTransient<IGrowthRatesCacheService, GrowthRatesCacheService>();
            services.AddTransient<IItemAttributesCacheService, ItemAttributesCacheService>();
            services.AddTransient<IItemCategoriesCacheService, ItemCategoriesCacheService>();
            services.AddTransient<IItemFlingEffectsCacheService, ItemFlingEffectsCacheService>();
            services.AddTransient<IItemPocketsCacheService, ItemPocketsCacheService>();
            services.AddTransient<IItemsCacheService, ItemsCacheService>();
            services.AddTransient<ILanguagesCacheService, LanguagesCacheService>();
            services.AddTransient<ILocationAreasCacheService, LocationAreasCacheService>();
            services.AddTransient<ILocationsCacheService, LocationsCacheService>();
            services.AddTransient<IMachinesCacheService, MachinesCacheService>();
            services.AddTransient<IMoveAilmentsCacheService, MoveAilmentsCacheService>();
            services.AddTransient<IMoveBattleStylesCacheService, MoveBattleStylesCacheService>();
            services.AddTransient<IMoveCategoriesCacheService, MoveCategoriesCacheService>();
            services.AddTransient<IMoveDamageClassesCacheService, MoveDamageClassesCacheService>();
            services.AddTransient<IMoveLearnMethodsCacheService, MoveLearnMethodsCacheService>();
            services.AddTransient<IMoveTargetsCacheService, MoveTargetsCacheService>();
            services.AddTransient<IMovesCacheService, MovesCacheService>();
            services.AddTransient<INaturesCacheService, NaturesCacheService>();
            services.AddTransient<IPalParkAreasCacheService, PalParkAreasCacheService>();
            services.AddTransient<IPokeathlonStatsCacheService, PokeathlonStatsCacheService>();
            services.AddTransient<IPokedexesCacheService, PokedexesCacheService>();
            services.AddTransient<IPokemonColorsCacheService, PokemonColorsCacheService>();
            services.AddTransient<IPokemonFormsCacheService, PokemonFormsCacheService>();
            services.AddTransient<IPokemonHabitatsCacheService, PokemonHabitatsCacheService>();
            services.AddTransient<IPokemonShapesCacheService, PokemonShapesCacheService>();
            services.AddTransient<IPokemonSpeciesCacheService, PokemonSpeciesCacheService>();
            services.AddTransient<IPokemonsCacheService, PokemonsCacheService>();
            services.AddTransient<IRegionsCacheService, RegionsCacheService>();
            services.AddTransient<IStatsCacheService, StatsCacheService>();
            services.AddTransient<ISuperContestEffectsCacheService, SuperContestEffectsCacheService>();
            services.AddTransient<ITypesCacheService, TypesCacheService>();
            services.AddTransient<IVersionGroupsCacheService, VersionGroupsCacheService>();
            services.AddTransient<IVersionsCacheService, VersionsCacheService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            // Enable middleware to caching
            //app.UsePokemonsMiddleware();

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();

            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUi();
        }
    }
}
