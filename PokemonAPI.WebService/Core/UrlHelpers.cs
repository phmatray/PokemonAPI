using System;
using System.Collections.Generic;
using PokemonAPI.WebService.Controllers;

namespace PokemonAPI.WebService.Core
{
    public static class UrlHelpers
    {
        private static readonly Dictionary<Type, string> Segments;

        static UrlHelpers()
        {
            Segments = new Dictionary<Type, string>
            {
                {typeof(AbilitiesController)               , "abilities"},
                {typeof(BerriesController)                 , "berries"},
                {typeof(BerryFirmnessesController)         , "berry-firmnesses"},
                {typeof(BerryFlavorsController)            , "berry-flavors"},
                {typeof(CharacteristicsController)         , "characteristics"},
                {typeof(ContestEffectsController)          , "contest-effects"},
                {typeof(ContestTypesController)            , "contest-types"},
                {typeof(EggGroupsController)               , "egg-groups"},
                {typeof(EncounterConditionsController)     , "encounter-conditions"},
                {typeof(EncounterConditionValuesController), "encounter-condition-values"},
                {typeof(EncounterMethodsController)        , "encounter-methods"},
                {typeof(EvolutionChainsController)         , "evolution-chains"},
                {typeof(EvolutionTriggersController)       , "evolution-triggers"},
                {typeof(GendersController)                 , "genders"},
                {typeof(GenerationsController)             , "generations"},
                {typeof(GrowthRatesController)             , "growth-rates"},
                {typeof(ItemAttributesController)          , "item-attributes"},
                {typeof(ItemCategoriesController)          , "item-categories"},
                {typeof(ItemFlingEffectsController)        , "item-fling-effects"},
                {typeof(ItemPocketsController)             , "item-pockets"},
                {typeof(ItemsController)                   , "items"},
                {typeof(LanguagesController)               , "languages"},
                {typeof(LocationAreasController)           , "location-areas"},
                {typeof(LocationsController)               , "locations"},
                {typeof(MachinesController)                , "machines"},
                {typeof(MoveAilmentsController)            , "move-ailments"},
                {typeof(MoveBattleStylesController)        , "move-battle-styles"},
                {typeof(MoveCategoriesController)          , "move-categories"},
                {typeof(MoveDamageClassesController)       , "move-damage-classes"},
                {typeof(MoveLearnMethodsController)        , "move-learn-methods"},
                {typeof(MoveTargetsController)             , "move-targets"},
                {typeof(MovesController)                   , "moves"},
                {typeof(NaturesController)                 , "natures"},
                {typeof(PalParkAreasController)            , "pal-park-areas"},
                {typeof(PokeathlonStatsController)         , "pokeathlon-stats"},
                {typeof(PokedexesController)               , "pokedexes"},
                {typeof(PokemonColorsController)           , "pokemon-colors"},
                {typeof(PokemonFormsController)            , "pokemon-forms"},
                {typeof(PokemonHabitatsController)         , "pokemon-habitats"},
                {typeof(PokemonShapesController)           , "pokemon-shapes"},
                {typeof(PokemonSpeciesController)          , "pokemon-species"},
                {typeof(PokemonsController)                , "pokemons"},
                {typeof(RegionsController)                 , "regions"},
                {typeof(StatsController)                   , "stats"},
                {typeof(SuperContestEffectsController)     , "super-contest-effects"},
                {typeof(TypesController)                   , "types"},
                {typeof(VersionGroupsController)           , "version-groups"},
                {typeof(VersionsController)                , "versions"}
            };
        }

        public static string RscUrl(this Type controllerType)
            => $"{Constants.SiteUrl}{Constants.BaseUrl}{Segments[controllerType]}/";

        public static string RscUrl(this Type controllerType, int id)
            => $"{controllerType.RscUrl()}{id}/";

        public static string RscUrl(this Type controllerType, string id)
            => $"{controllerType.RscUrl()}{id}/";

        public static string Previous(this Type controllerType, int limit, int offset)
            => offset - limit >= 0
                ? $"{controllerType.RscUrl().Trim('/')}?limit={limit}&offset={offset - limit}"
                : null;

        public static string Next(this Type controllerType, int limit, int offset, int count)
            => offset + limit < count
                ? $"{controllerType.RscUrl().Trim('/')}?limit={limit}&offset={offset + limit}"
                : null;
    }
}