using System.Collections.Generic;

namespace HTTPApplication
{
    public class Legendary
    {
        public string form { get; set; }
        public int pokemon_id { get; set; }
        public string pokemon_name { get; set; }
        public string rarity { get; set; }
    }

    public class Mythic
    {
        public string form { get; set; }
        public int pokemon_id { get; set; }
        public string pokemon_name { get; set; }
        public string rarity { get; set; }
    }

    public class Standard
    {
        public string form { get; set; }
        public int pokemon_id { get; set; }
        public string pokemon_name { get; set; }
        public string rarity { get; set; }
    }

    public class PokemonResponse
    {
        public Legendary[] Legendary { get; set; }
        public Mythic[] Mythic { get; set; }
        public Standard[] Standard { get; set; }
    }
}