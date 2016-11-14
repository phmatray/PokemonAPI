using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class PokemonSpecies
    {
        /// <summary>
        /// The identifier for this Pokémon species resource
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name for this Pokémon species resource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The order in which species should be sorted. Based on National Dex order, except families are grouped together and sorted by stage.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The chance of this Pokémon being female, in eighths; or -1 for genderless
        /// </summary>
        public int GenderRate { get; set; }

        /// <summary>
        /// The base capture rate; up to 255. The higher the number, the easier the catch.
        /// </summary>
        public int CaptureRate { get; set; }

        /// <summary>
        /// The happiness when caught by a normal Pokéball; up to 255. The higher the number, the happier the Pokémon.
        /// </summary>
        public int BaseHappiness { get; set; }

        /// <summary>
        /// Whether or not this is a baby Pokémon
        /// </summary>
        public bool IsBaby { get; set; }

        /// <summary>
        /// Initial hatch counter: one must walk 255 × (hatch_counter + 1) steps before this Pokémon's egg hatches, unless utilizing bonuses like Flame Body's
        /// </summary>
        public int HatchCounter { get; set; }

        /// <summary>
        /// Whether or not this Pokémon has visual gender differences
        /// </summary>
        public bool HasGenderDifferences { get; set; }

        /// <summary>
        /// Whether or not this Pokémon has multiple forms and can switch between them
        /// </summary>
        public bool FormsSwitchable { get; set; }

        /// <summary>
        /// The rate at which this Pokémon species gains levels
        /// </summary>
        public NamedAPIResource GrowthRate { get; set; }

        /// <summary>
        /// A list of Pokedexes and the indexes reserved within them for this Pokémon species
        /// </summary>
        public List<PokemonSpeciesDexEntry> PokedexNumbers { get; set; }

        /// <summary>
        /// A list of egg groups this Pokémon species is a member of
        /// </summary>
        public List<NamedAPIResource> EggGroups { get; set; }

        /// <summary>
        /// The color of this Pokémon for gimmicky Pokédex search
        /// </summary>
        public NamedAPIResource Color { get; set; }

        /// <summary>
        /// The shape of this Pokémon for gimmicky Pokédex search
        /// </summary>
        public NamedAPIResource Shape { get; set; }

        /// <summary>
        /// The Pokémon species that evolves into this Pokemon_species
        /// </summary>
        public NamedAPIResource EvolvesFromSpecies { get; set; }

        /// <summary>
        /// The evolution chain this Pokémon species is a member of
        /// </summary>
        public APIResource EvolutionChain { get; set; }

        /// <summary>
        /// The habitat this Pokémon species can be encountered in
        /// </summary>
        public NamedAPIResource Habitat { get; set; }

        /// <summary>
        /// The generation this Pokémon species was introduced in
        /// </summary>
        public NamedAPIResource Generation { get; set; }

        /// <summary>
        /// The name of this Pokémon species listed in different languages
        /// </summary>
        public List<Name> Names { get; set; }

        /// <summary>
        /// The encounter that can be had with this Pokémon species in pal park
        /// </summary>
        public PalParkEncounterArea PalParkEncounter { get; set; }

        /// <summary>
        /// A list of flavor text entries for this Pokémon species
        /// </summary>
        public List<FlavorTextVersion> FlavorTextEntries { get; set; }

        /// <summary>
        /// Descriptions of different forms Pokémon take on within the Pokémon species
        /// </summary>
        public List<Description> FormDescriptions { get; set; }

        /// <summary>
        /// The genus of this Pokémon species listed in multiple languages
        /// </summary>
        public List<Genus> Genera { get; set; }

        /// <summary>
        /// A list of the Pokémon that exist within this Pokémon species
        /// </summary>
        public List<PokemonSpeciesVariety> Varieties { get; set; }

    }
}