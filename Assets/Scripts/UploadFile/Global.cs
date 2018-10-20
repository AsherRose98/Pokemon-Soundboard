using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Global {
	public static List<string[]> PokemonList = new List<string[]> ();

	public static string[] _debugGetPokemonListAtIndex(int index){
		return PokemonList [index];
	}

	public static void Filter(string field, string value){

	}
}

