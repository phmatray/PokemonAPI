using System.Collections.Generic;

namespace PokemonAPI.Models.Rsc
{
    public class ResourceList<T>
    {
        public ResourceList(int count, string previous, string next, List<T> results)
        {
            Count    = count;
            Previous = previous;
            Next     = next;
            Results  = results;
        }

        /// <summary>
        /// The total number of resources available from this API
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// The URL for the next page in the list
        /// </summary>
        public string Next { get; set; }

        /// <summary>
        /// The URL for the previous page in the list
        /// </summary>
        public string Previous { get; set; }

        /// <summary>
        /// A list of resources
        /// </summary>
        public List<T> Results { get; set; }

    }
}