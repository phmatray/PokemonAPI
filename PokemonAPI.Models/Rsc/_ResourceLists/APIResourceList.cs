using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class APIResourceList : ResourceList<APIResource>
    {
        public APIResourceList(int count, string previous, string next, List<APIResource> results)
            : base(count, previous, next, results)
        {
        }
    }
}
