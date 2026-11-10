using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Pokedex : MonoBehaviour
{
    private Keyboard _myKeyboard;
    [SerializeField] private PokemonData[] _pokemonData = new PokemonData[3];
    [SerializeField] private TextMeshProUGUI _nombre;
    [SerializeField] private TextMeshProUGUI _numPokedex;
    [SerializeField] private Image _pokemonSprite;

    private int _numPokemon = 0;
    void Start()
    {
        _myKeyboard = Keyboard.current;
    }

    void Update()
    {

        if (_myKeyboard.upArrowKey.wasPressedThisFrame)
        {
            _numPokemon++;
        }
        else if (_myKeyboard.downArrowKey.wasPressedThisFrame)
        {
            _numPokemon--;
        }
        if (_numPokemon < 0)
        {
            _numPokemon = 0;
        }
        else if (_numPokemon > _pokemonData.Length - 1)
        {
            _numPokemon = _pokemonData.Length - 1;
        }

        MostrarPokemon();
    }

    private void MostrarPokemon()
    {
        _nombre.text = _pokemonData[_numPokemon].Nombre;
        _numPokedex.text = _pokemonData[_numPokemon].NumPokedex.ToString();
        _pokemonSprite.sprite = _pokemonData[_numPokemon].PokemonSprite;
    }
}
