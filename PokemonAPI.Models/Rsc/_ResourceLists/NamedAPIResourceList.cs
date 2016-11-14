using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class NamedAPIResourceList : ResourceList<NamedAPIResource>
    {
        public NamedAPIResourceList(int count, string previous, string next, List<NamedAPIResource> results)
            : base(count, previous, next, results)
        {
        }
    }
}