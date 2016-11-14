namespace PokemonAPI.Models.Rsc
{
    public class MoveMetaData
    {
        /// <summary>
        /// The status ailment this move inflicts on its target
        /// </summary>
        public NamedAPIResource Ailment { get; set; }

        /// <summary>
        /// The category of move this move falls under, e.g. damage or ailment
        /// </summary>
        public NamedAPIResource Category { get; set; }

        /// <summary>
        /// The minimum number of times this move hits. Null if it always only hits once.
        /// </summary>
        public int? MinHits { get; set; }

        /// <summary>
        /// The maximum number of times this move hits. Null if it always only hits once.
        /// </summary>
        public int? MaxHits { get; set; }

        /// <summary>
        /// The minimum number of turns this move continues to take effect. Null if it always only lasts one turn.
        /// </summary>
        public int? MinTurns { get; set; }

        /// <summary>
        /// The maximum number of turns this move continues to take effect. Null if it always only lasts one turn.
        /// </summary>
        public int? MaxTurns { get; set; }

        /// <summary>
        /// HP drain (if positive) or Recoil damage (if negative), in percent of damage done
        /// </summary>
        public int Drain { get; set; }

        /// <summary>
        /// The amount of hp gained by the attacking Pokemon, in percent of it's maximum HP
        /// </summary>
        public int Healing { get; set; }

        /// <summary>
        /// Critical hit rate bonus
        /// </summary>
        public int CritRate { get; set; }

        /// <summary>
        /// The likelihood this attack will cause an ailment
        /// </summary>
        public int AilmentChance { get; set; }

        /// <summary>
        /// The likelihood this attack will cause the target Pokémon to flinch
        /// </summary>
        public int FlinchChance { get; set; }

        /// <summary>
        /// The likelihood this attack will cause a stat change in the target Pokémon
        /// </summary>
        public int StatChance { get; set; }

    }
}