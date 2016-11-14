using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Controllers;
using PokemonAPI.WebService.Models;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Core
{
    internal static class APIResourceMapper
    {
        #region ApiResources

        internal static APIResource ToApiResource(this EFCharacteristics src)
            => src.ToApiResource<CharacteristicsController>();

        internal static APIResource ToApiResource(this EFContestEffects src)
            => src.ToApiResource<ContestEffectsController>();

        internal static APIResource ToApiResource(this EFEvolutionChains src)
            => src.ToApiResource<EvolutionChainsController>();

        internal static APIResource ToApiResource(this EFMachines src)
            => new APIResource(typeof(MachinesController).RscUrl($"{src.MachineNumber}/{src.VersionGroupId}"));

        internal static APIResource ToApiResource(this EFSuperContestEffects src)
            => src.ToApiResource<SuperContestEffectsController>();

        #endregion

        #region NamedApiResource

        internal static NamedAPIResource ToNamedApiResource(this EFAbilities src)
            => src.ToNamedApiResource<AbilitiesController>();

        internal static NamedAPIResource ToNamedApiResource(this EFBerries src)
            => new NamedAPIResource(
                src.Item.Identifier.Replace("-berry", ""),
                typeof(BerriesController).RscUrl(src.Id)
            );

        internal static NamedAPIResource ToNamedApiResource(this EFBerryFirmness src)
            => src.ToNamedApiResource<BerryFirmnessesController>();

        internal static NamedAPIResource ToNamedApiResource(this EFContestTypes src)
            => src.ToNamedApiResource<ContestTypesController>();

        internal static NamedAPIResource ToNamedApiResource(this EFContestTypeNames src)
            => new NamedAPIResource(
                src.Flavor?.ToLower(),
                typeof(BerryFlavorsController).RscUrl(src.ContestTypeId)
            );

        internal static NamedAPIResource ToNamedApiResource(this EFEggGroups src)
            => src.ToNamedApiResource<EggGroupsController>();

        internal static NamedAPIResource ToNamedApiResource(this EFEncounterConditions src)
            => src.ToNamedApiResource<EncounterConditionsController>();

        internal static NamedAPIResource ToNamedApiResource(this EFEncounterConditionValues src)
            => src.ToNamedApiResource<EncounterConditionValuesController>();

        internal static NamedAPIResource ToNamedApiResource(this EFEncounterMethods src)
            => src.ToNamedApiResource<EncounterMethodsController>();

        internal static NamedAPIResource ToNamedApiResource(this EFEvolutionTriggers src)
            => src.ToNamedApiResource<EvolutionTriggersController>();

        internal static NamedAPIResource ToNamedApiResource(this EFGenders src)
            => src.ToNamedApiResource<GendersController>();

        internal static NamedAPIResource ToNamedApiResource(this EFGenerations src)
            => src.ToNamedApiResource<GenerationsController>();

        internal static NamedAPIResource ToNamedApiResource(this EFGrowthRates src)
            => src.ToNamedApiResource<GrowthRatesController>();

        internal static NamedAPIResource ToNamedApiResource(this EFItemFlags src)
            => src.ToNamedApiResource<ItemAttributesController>();

        internal static NamedAPIResource ToNamedApiResource(this EFItemFlingEffects src)
            => src.ToNamedApiResource<ItemFlingEffectsController>();

        internal static NamedAPIResource ToNamedApiResource(this EFItemCategories src)
            => src.ToNamedApiResource<ItemCategoriesController>();

        internal static NamedAPIResource ToNamedApiResource(this EFItemPockets src)
            => src.ToNamedApiResource<ItemPocketsController>();

        internal static NamedAPIResource ToNamedApiResource(this EFItems src)
            => src.ToNamedApiResource<ItemsController>();

        internal static NamedAPIResource ToNamedApiResource(this EFLanguages src)
            => src.ToNamedApiResource<LanguagesController>();

        internal static NamedAPIResource ToNamedApiResource(this EFLocationAreas src)
            => src.Location == null
                ? src.ToNamedApiResource<LocationAreasController>()
                : new NamedAPIResource(
                    $"{src.Location.Identifier}-{src.Identifier ?? "area"}",
                    typeof(LocationAreasController).RscUrl(src.Id)
                );

        internal static NamedAPIResource ToNamedApiResource(this EFLocations src)
            => src.ToNamedApiResource<LocationsController>();

        internal static NamedAPIResource ToNamedApiResource(this EFMoveMetaAilments src)
            => src.ToNamedApiResource<MoveAilmentsController>();

        internal static NamedAPIResource ToNamedApiResource(this EFMoveBattleStyles src)
            => src.ToNamedApiResource<MoveBattleStylesController>();

        internal static NamedAPIResource ToNamedApiResource(this EFMoveMetaCategories src)
            => src.ToNamedApiResource<MoveCategoriesController>();

        internal static NamedAPIResource ToNamedApiResource(this EFMoveDamageClasses src)
            => src.ToNamedApiResource<MoveDamageClassesController>();

        internal static NamedAPIResource ToNamedApiResource(this EFPokemonMoveMethods src)
            => src.ToNamedApiResource<MoveLearnMethodsController>();

        internal static NamedAPIResource ToNamedApiResource(this EFMoveTargets src)
            => src.ToNamedApiResource<MoveTargetsController>();

        internal static NamedAPIResource ToNamedApiResource(this EFMoves src)
            => src.ToNamedApiResource<MovesController>();

        internal static NamedAPIResource ToNamedApiResource(this EFNatures src)
            => src.ToNamedApiResource<NaturesController>();

        internal static NamedAPIResource ToNamedApiResource(this EFPalParkAreas src)
            => src.ToNamedApiResource<PalParkAreasController>();

        internal static NamedAPIResource ToNamedApiResource(this EFPokeathlonStats src)
            => src.ToNamedApiResource<PokeathlonStatsController>();

        internal static NamedAPIResource ToNamedApiResource(this EFPokedexes src)
            => src.ToNamedApiResource<PokedexesController>();

        internal static NamedAPIResource ToNamedApiResource(this EFPokemonColors src)
            => src.ToNamedApiResource<PokemonColorsController>();

        internal static NamedAPIResource ToNamedApiResource(this EFPokemonForms src)
            => src.ToNamedApiResource<PokemonFormsController>();

        internal static NamedAPIResource ToNamedApiResource(this EFPokemonHabitats src)
            => src.ToNamedApiResource<PokemonHabitatsController>();

        internal static NamedAPIResource ToNamedApiResource(this EFPokemonShapes src)
            => src.ToNamedApiResource<PokemonShapesController>();

        internal static NamedAPIResource ToNamedApiResource(this EFPokemonSpecies src)
            => src.ToNamedApiResource<PokemonSpeciesController>();

        internal static NamedAPIResource ToNamedApiResource(this EFPokemon src)
            => src.ToNamedApiResource<PokemonsController>();

        internal static NamedAPIResource ToNamedApiResource(this EFRegions src)
            => src.ToNamedApiResource<RegionsController>();

        internal static NamedAPIResource ToNamedApiResource(this EFStats src)
            => src.ToNamedApiResource<StatsController>();

        internal static NamedAPIResource ToNamedApiResource(this EFTypes src)
            => src.ToNamedApiResource<TypesController>();

        internal static NamedAPIResource ToNamedApiResource(this EFVersionGroups src)
            => src.ToNamedApiResource<VersionGroupsController>();

        internal static NamedAPIResource ToNamedApiResource(this EFVersions src)
            => src.ToNamedApiResource<VersionsController>();

        #endregion

        #region PrivateMethods

        private static APIResource ToApiResource<TController>(this IEFId id)
            where TController: ApiController
            => new APIResource(typeof(TController).RscUrl(id.Id));

        private static NamedAPIResource ToNamedApiResource<TController>(this IEFIdentifier identifier)
            where TController: ApiController
            => new NamedAPIResource(identifier.Identifier, typeof(TController).RscUrl(identifier.Id));

        #endregion
    }
}