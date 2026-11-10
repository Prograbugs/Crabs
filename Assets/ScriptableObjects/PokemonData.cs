using UnityEngine;

[CreateAssetMenu(fileName = "PokemonData", menuName = "Pokemons/Pokemon Data")]
public class PokemonData : ScriptableObject
{
    [SerializeField] private string _nombre;
    [SerializeField] private int _numPokedex;
    [SerializeField] private Sprite _pokemonSprite;

    public string Nombre { get { return _nombre; } }
    public int NumPokedex { get { return _numPokedex; } }
    public Sprite PokemonSprite { get { return _pokemonSprite; } }
}
