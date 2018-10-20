using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class SearchPokemon : MonoBehaviour {
	public List<string> ListOfTypes;
	public Toggle CheckboxPrefab;

	SpawnButtons SpawnButtons;
	InputField SearchBar;
	GameObject TypeToggle;
	Dropdown GenSelect;

	List<string> CurrentTypesSearch = new List<string> ();
	int CurrentGenSearch = 0;
	string CurrentNameSearch = "";

	public void Start()
	{
		SpawnButtons = gameObject.GetComponent<SpawnButtons> ();
		SearchBar = gameObject.GetComponentInChildren<InputField> ();
		TypeToggle = GameObject.Find ("TypeToggle");
		GenSelect = GameObject.Find ("GenSelect").GetComponentInChildren<Dropdown>();

		spawnCheckboxes ();

		SearchBar.onValueChanged.AddListener(
			delegate {
				searchByName(); 
			}
		);

		GenSelect.onValueChanged.AddListener (
			delegate{
				searchByGen();
			}
		);

	}

	void spawnCheckboxes(){
		foreach (string type in ListOfTypes) {
			Toggle check = GameObject.Instantiate (CheckboxPrefab,Vector3.zero, Quaternion.identity);
			check.transform.SetParent (TypeToggle.transform, false);
			string checkName =  type+":";
			check.GetComponent<CheckboxData>().setData (checkName);

			check.onValueChanged.AddListener (
				delegate {
					searchByTypes (type,check);
				}
			);
		}
	}

	void searchByTypes(string value, Toggle box){
		if (box.isOn) {
			CurrentTypesSearch.Add (value.ToLower());
		} else {
			CurrentTypesSearch.Remove (value.ToLower());
		}
		filter ();
	}

	void searchByName()
	{
		CurrentNameSearch = SearchBar.text;
		filter ();
	}

	void searchByGen(){
		CurrentGenSearch = GenSelect.value;
		//Debug.Log (CurrentGenSearch);
		filter ();
	}

	List<string[]>filterGen(){
		if (CurrentGenSearch > 0) {
			List<string[]> filteredButtons = new List<string[]> ();
			foreach (string[] item in Global.PokemonList) {
				int gen = int.Parse (item [4]);
					if (gen == CurrentGenSearch) {
						filteredButtons.Add (item);
					}
			}
			return filteredButtons;
		}
		return Global.PokemonList;
	}

	List<string[]> filterType(){
		if (CurrentTypesSearch.Count > 0){
			List<string[]> filteredButtons = new List<string[]> ();
			foreach (string[] item in Global.PokemonList) {
				if (CurrentTypesSearch.Contains (item [2].ToLower ()) ||
					CurrentTypesSearch.Contains (item [3].ToLower ())) {
					filteredButtons.Add (item);
				}
			}
			return filteredButtons;
		}
		return Global.PokemonList;
	}

	List<string[]> filterName(){
		if (CurrentNameSearch != "") {
			List<string[]> filteredButtons = new List<string[]> ();
			foreach (string[] item in Global.PokemonList) {
				if (item [1].ToLower ().StartsWith (CurrentNameSearch.ToLower ())) { 
					filteredButtons.Add (item);
				}
			}
			return filteredButtons;
		}
		return Global.PokemonList;
	}

	void filter(){
		clearButtons ();

		List<string[]> type = filterType ();
		List<string[]> name = filterName ();
		List<string[]> gen = filterGen ();


		foreach(string[] item in Global.PokemonList){
			if(	type.Contains(item)&
				name.Contains(item)&
				gen.Contains(item)){
				SpawnButtons.spawnButton (item [0], item [1], item [2], item [3], item [4]);
			}
		}
	}


	void clearButtons(){
		GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
		foreach (GameObject button in buttons) {
			Destroy (button);
		}
	}
}
