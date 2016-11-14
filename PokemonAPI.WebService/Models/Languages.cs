using System.Collections.Generic;
using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public sealed class EFLanguages : IEFIdentifier
    {
        public EFLanguages()
        {
            AbilityChangelogProse = new HashSet<EFAbilityChangelogProse>();
            AbilityFlavorText = new HashSet<EFAbilityFlavorText>();
            AbilityNames = new HashSet<EFAbilityNames>();
            AbilityProse = new HashSet<EFAbilityProse>();
            BerryFirmnessNames = new HashSet<EFBerryFirmnessNames>();
            CharacteristicText = new HashSet<EFCharacteristicText>();
            ConquestEpisodeNames = new HashSet<EFConquestEpisodeNames>();
            ConquestKingdomNames = new HashSet<EFConquestKingdomNames>();
            ConquestMoveDisplacementProse = new HashSet<EFConquestMoveDisplacementProse>();
            ConquestMoveEffectProse = new HashSet<EFConquestMoveEffectProse>();
            ConquestMoveRangeProse = new HashSet<EFConquestMoveRangeProse>();
            ConquestStatNames = new HashSet<EFConquestStatNames>();
            ConquestWarriorNames = new HashSet<EFConquestWarriorNames>();
            ConquestWarriorSkillNames = new HashSet<EFConquestWarriorSkillNames>();
            ConquestWarriorStatNames = new HashSet<EFConquestWarriorStatNames>();
            ContestEffectProse = new HashSet<EFContestEffectProse>();
            ContestTypeNames = new HashSet<EFContestTypeNames>();
            EggGroupProse = new HashSet<EFEggGroupProse>();
            EncounterConditionProse = new HashSet<EFEncounterConditionProse>();
            EncounterConditionValueProse = new HashSet<EFEncounterConditionValueProse>();
            EncounterMethodProse = new HashSet<EFEncounterMethodProse>();
            EvolutionTriggerProse = new HashSet<EFEvolutionTriggerProse>();
            GenerationNames = new HashSet<EFGenerationNames>();
            GrowthRateProse = new HashSet<EFGrowthRateProse>();
            ItemCategoryProse = new HashSet<EFItemCategoryProse>();
            ItemFlagProse = new HashSet<EFItemFlagProse>();
            ItemFlavorSummaries = new HashSet<EFItemFlavorSummaries>();
            ItemFlavorText = new HashSet<EFItemFlavorText>();
            ItemFlingEffectProse = new HashSet<EFItemFlingEffectProse>();
            ItemNames = new HashSet<EFItemNames>();
            ItemPocketNames = new HashSet<EFItemPocketNames>();
            ItemProse = new HashSet<EFItemProse>();
            LanguageNamesLanguage = new HashSet<EFLanguageNames>();
            LanguageNamesLocalLanguage = new HashSet<EFLanguageNames>();
            LocationAreaProse = new HashSet<EFLocationAreaProse>();
            LocationNames = new HashSet<EFLocationNames>();
            MoveBattleStyleProse = new HashSet<EFMoveBattleStyleProse>();
            MoveDamageClassProse = new HashSet<EFMoveDamageClassProse>();
            MoveEffectChangelogProse = new HashSet<EFMoveEffectChangelogProse>();
            MoveEffectProse = new HashSet<EFMoveEffectProse>();
            MoveFlagProse = new HashSet<EFMoveFlagProse>();
            MoveFlavorSummaries = new HashSet<EFMoveFlavorSummaries>();
            MoveFlavorText = new HashSet<EFMoveFlavorText>();
            MoveMetaAilmentNames = new HashSet<EFMoveMetaAilmentNames>();
            MoveMetaCategoryProse = new HashSet<EFMoveMetaCategoryProse>();
            MoveNames = new HashSet<EFMoveNames>();
            MoveTargetProse = new HashSet<EFMoveTargetProse>();
            NatureNames = new HashSet<EFNatureNames>();
            PalParkAreaNames = new HashSet<EFPalParkAreaNames>();
            PokeathlonStatNames = new HashSet<EFPokeathlonStatNames>();
            PokedexProse = new HashSet<EFPokedexProse>();
            PokemonColorNames = new HashSet<EFPokemonColorNames>();
            PokemonFormNames = new HashSet<EFPokemonFormNames>();
            PokemonHabitatNames = new HashSet<EFPokemonHabitatNames>();
            PokemonMoveMethodProse = new HashSet<EFPokemonMoveMethodProse>();
            PokemonShapeProse = new HashSet<EFPokemonShapeProse>();
            PokemonSpeciesFlavorSummaries = new HashSet<EFPokemonSpeciesFlavorSummaries>();
            PokemonSpeciesFlavorText = new HashSet<EFPokemonSpeciesFlavorText>();
            PokemonSpeciesNames = new HashSet<EFPokemonSpeciesNames>();
            PokemonSpeciesProse = new HashSet<EFPokemonSpeciesProse>();
            RegionNames = new HashSet<EFRegionNames>();
            StatNames = new HashSet<EFStatNames>();
            SuperContestEffectProse = new HashSet<EFSuperContestEffectProse>();
            TypeNames = new HashSet<EFTypeNames>();
            VersionNames = new HashSet<EFVersionNames>();
        }

        public int Id { get; set; }
        public string Iso639 { get; set; }
        public string Iso3166 { get; set; }
        public string Identifier { get; set; }
        public bool Official { get; set; }
        public int? Order { get; set; }

        public ICollection<EFAbilityChangelogProse> AbilityChangelogProse { get; set; }
        public ICollection<EFAbilityFlavorText> AbilityFlavorText { get; set; }
        public ICollection<EFAbilityNames> AbilityNames { get; set; }
        public ICollection<EFAbilityProse> AbilityProse { get; set; }
        public ICollection<EFBerryFirmnessNames> BerryFirmnessNames { get; set; }
        public ICollection<EFCharacteristicText> CharacteristicText { get; set; }
        public ICollection<EFConquestEpisodeNames> ConquestEpisodeNames { get; set; }
        public ICollection<EFConquestKingdomNames> ConquestKingdomNames { get; set; }
        public ICollection<EFConquestMoveDisplacementProse> ConquestMoveDisplacementProse { get; set; }
        public ICollection<EFConquestMoveEffectProse> ConquestMoveEffectProse { get; set; }
        public ICollection<EFConquestMoveRangeProse> ConquestMoveRangeProse { get; set; }
        public ICollection<EFConquestStatNames> ConquestStatNames { get; set; }
        public ICollection<EFConquestWarriorNames> ConquestWarriorNames { get; set; }
        public ICollection<EFConquestWarriorSkillNames> ConquestWarriorSkillNames { get; set; }
        public ICollection<EFConquestWarriorStatNames> ConquestWarriorStatNames { get; set; }
        public ICollection<EFContestEffectProse> ContestEffectProse { get; set; }
        public ICollection<EFContestTypeNames> ContestTypeNames { get; set; }
        public ICollection<EFEggGroupProse> EggGroupProse { get; set; }
        public ICollection<EFEncounterConditionProse> EncounterConditionProse { get; set; }
        public ICollection<EFEncounterConditionValueProse> EncounterConditionValueProse { get; set; }
        public ICollection<EFEncounterMethodProse> EncounterMethodProse { get; set; }
        public ICollection<EFEvolutionTriggerProse> EvolutionTriggerProse { get; set; }
        public ICollection<EFGenerationNames> GenerationNames { get; set; }
        public ICollection<EFGrowthRateProse> GrowthRateProse { get; set; }
        public ICollection<EFItemCategoryProse> ItemCategoryProse { get; set; }
        public ICollection<EFItemFlagProse> ItemFlagProse { get; set; }
        public ICollection<EFItemFlavorSummaries> ItemFlavorSummaries { get; set; }
        public ICollection<EFItemFlavorText> ItemFlavorText { get; set; }
        public ICollection<EFItemFlingEffectProse> ItemFlingEffectProse { get; set; }
        public ICollection<EFItemNames> ItemNames { get; set; }
        public ICollection<EFItemPocketNames> ItemPocketNames { get; set; }
        public ICollection<EFItemProse> ItemProse { get; set; }
        public ICollection<EFLanguageNames> LanguageNamesLanguage { get; set; }
        public ICollection<EFLanguageNames> LanguageNamesLocalLanguage { get; set; }
        public ICollection<EFLocationAreaProse> LocationAreaProse { get; set; }
        public ICollection<EFLocationNames> LocationNames { get; set; }
        public ICollection<EFMoveBattleStyleProse> MoveBattleStyleProse { get; set; }
        public ICollection<EFMoveDamageClassProse> MoveDamageClassProse { get; set; }
        public ICollection<EFMoveEffectChangelogProse> MoveEffectChangelogProse { get; set; }
        public ICollection<EFMoveEffectProse> MoveEffectProse { get; set; }
        public ICollection<EFMoveFlagProse> MoveFlagProse { get; set; }
        public ICollection<EFMoveFlavorSummaries> MoveFlavorSummaries { get; set; }
        public ICollection<EFMoveFlavorText> MoveFlavorText { get; set; }
        public ICollection<EFMoveMetaAilmentNames> MoveMetaAilmentNames { get; set; }
        public ICollection<EFMoveMetaCategoryProse> MoveMetaCategoryProse { get; set; }
        public ICollection<EFMoveNames> MoveNames { get; set; }
        public ICollection<EFMoveTargetProse> MoveTargetProse { get; set; }
        public ICollection<EFNatureNames> NatureNames { get; set; }
        public ICollection<EFPalParkAreaNames> PalParkAreaNames { get; set; }
        public ICollection<EFPokeathlonStatNames> PokeathlonStatNames { get; set; }
        public ICollection<EFPokedexProse> PokedexProse { get; set; }
        public ICollection<EFPokemonColorNames> PokemonColorNames { get; set; }
        public ICollection<EFPokemonFormNames> PokemonFormNames { get; set; }
        public ICollection<EFPokemonHabitatNames> PokemonHabitatNames { get; set; }
        public ICollection<EFPokemonMoveMethodProse> PokemonMoveMethodProse { get; set; }
        public ICollection<EFPokemonShapeProse> PokemonShapeProse { get; set; }
        public ICollection<EFPokemonSpeciesFlavorSummaries> PokemonSpeciesFlavorSummaries { get; set; }
        public ICollection<EFPokemonSpeciesFlavorText> PokemonSpeciesFlavorText { get; set; }
        public ICollection<EFPokemonSpeciesNames> PokemonSpeciesNames { get; set; }
        public ICollection<EFPokemonSpeciesProse> PokemonSpeciesProse { get; set; }
        public ICollection<EFRegionNames> RegionNames { get; set; }
        public ICollection<EFStatNames> StatNames { get; set; }
        public ICollection<EFSuperContestEffectProse> SuperContestEffectProse { get; set; }
        public ICollection<EFTypeNames> TypeNames { get; set; }
        public ICollection<EFVersionNames> VersionNames { get; set; }
    }
}
