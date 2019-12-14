//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
//
using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace CookARmain
{
    [System.Serializable]
    public class ElementData
    {
        public string name;
        public string category;
        public string spectral_img;
        public int xpos;
        public int ypos;
        public string named_by;
        public float density;
        public string color;
        public float molar_heat;
        public string symbol;
        public string discovered_by;
        public string appearance;
        public float atomic_mass;
        public float melt;
        public string number;
        public string source;
        public int period;
        public string phase;
        public string summary;
        public int boil;
    }

    [System.Serializable]
    class ElementsData
    {
        public List<ElementData> elements;

        public static ElementsData FromJSON(string json)
        {
            return JsonUtility.FromJson<ElementsData>(json);
        }
    }

    public class PeriodicTableLoader : MonoBehaviour
    {
        // What object to parent the instantiated elements to
        public Transform Parent;

        // Generic element prefab to instantiate at each position in the table
        public GameObject ElementPrefab;

        // How much space to put between each element prefab
        public float ElementSeperationDistance;

        // Legend	    //var searchstrs = new List<string>() { "Soup" };
            //searchWithDishName(searchstrs);


        public Transform LegendTransform;

        public GridObjectCollection Collection;
        
        public Material MatTransitionMetal;
        public Material MatMetalloid;
        public Material MatDiatomicNonmetal;
        public Material MatNobleGas;
        public Material MatActinide;
        public Material MatLanthanide;

	public InputField Dishname;
	public InputField Categoryname;
	public Text fText;

        private bool isFirstRun = true;

        private void Start()
        {
            InitializeData();

	    //var searchstrs = new List<string>() { "Soup" };
            //searchWithDishName(searchstrs);

	    //randomRecipe();
        }


	public void ButtonUpdate()
	{
		//var searchstrs = new List<string>() { "Soup" };
		//searchWithDishName(searchstrs);
		fText.text = "Dish name you entered is: " + Dishname.text + " and Category name is: " + Categoryname.text;
		var searchstrs = new List<string>() { "Soup" };
		searchWithDishName(searchstrs);
		Pause(1000);
	}

	private IEnumerator Pause(int p)
	{
		Time.timeScale = 0.1f;
		yield return new WaitForSeconds(p);
		Time.timeScale = 1;
	}	


        public void InitializeData()
        {
            // Parse the elements out of the json file
            TextAsset asset = Resources.Load<TextAsset>("JSON/PeriodicTableJSON");
            List<ElementData> elements = ElementsData.FromJSON(asset.text).elements;

            Dictionary<string, Material> typeMaterials = new Dictionary<string, Material>()
        {
            { "sweet", MatTransitionMetal },
            { "savory", MatMetalloid },
            { "spicy", MatDiatomicNonmetal },
            { "salty", MatNobleGas },
            { "sour", MatActinide },
            { "bitter", MatLanthanide },
        };


            if (isFirstRun == true)
            {
                // Insantiate the element prefabs in their correct locations and with correct text
                foreach (ElementData element in elements)
                {
                    GameObject newElement = Instantiate<GameObject>(ElementPrefab, Parent);
                    newElement.GetComponentInChildren<Element>().SetFromElementData(element, typeMaterials);
                    newElement.transform.localPosition = new Vector3(element.xpos * ElementSeperationDistance - ElementSeperationDistance * 18 / 2, ElementSeperationDistance * 9 - element.ypos * ElementSeperationDistance, 2.0f);
                    newElement.transform.localRotation = Quaternion.identity;
                }

                isFirstRun = false;
            }
            else
            {
                int i = 0;
                // Update position and data of existing element objects
                foreach(Transform existingElementObject in Parent)
                {
                    existingElementObject.parent.GetComponentInChildren<Element>().SetFromElementData(elements[i], typeMaterials);
                    existingElementObject.localPosition = new Vector3(elements[i].xpos * ElementSeperationDistance - ElementSeperationDistance * 18 / 2, ElementSeperationDistance * 9 - elements[i].ypos * ElementSeperationDistance, 2.0f);
                    existingElementObject.localRotation = Quaternion.identity;
                    i++;
                }
                Parent.localPosition = new Vector3(0.0f, -0.7f, 0.7f);
                LegendTransform.localPosition = new Vector3(0.0f, 0.15f, 1.8f);

            }
        }

	public bool searchSubStrings(string origstr, List<string> substrings)
	{
                foreach (string substr in substrings)
		{
			if (!origstr.ToLower().Contains(substr.ToLower())) {
				return false;
			}
		}
		return true;
	}

        public void searchWithDishName(List<string> searchstrs)
        {
            // Parse the elements out of the json file
            TextAsset asset = Resources.Load<TextAsset>("JSON/PeriodicTableJSON");
            List<ElementData> elements = ElementsData.FromJSON(asset.text).elements;

            Dictionary<string, Material> typeMaterials = new Dictionary<string, Material>()
        {
            { "sweet", MatTransitionMetal },
            { "savory", MatMetalloid },
            { "spicy", MatDiatomicNonmetal },
            { "salty", MatNobleGas },
            { "sour", MatActinide },
            { "bitter", MatLanthanide },
        };


            if (isFirstRun == true)
            {
                // Insantiate the element prefabs in their correct locations and with correct text
                foreach (ElementData element in elements)
                {
	            if (searchSubStrings(element.name, searchstrs)) {
                    	GameObject newElement = Instantiate<GameObject>(ElementPrefab, Parent);
                    	newElement.GetComponentInChildren<Element>().SetFromElementData(element, typeMaterials);
                    	newElement.transform.localPosition = new Vector3(element.xpos * ElementSeperationDistance - ElementSeperationDistance * 18 / 2, ElementSeperationDistance * 9 - element.ypos * ElementSeperationDistance, 2.0f);
                    	newElement.transform.localRotation = Quaternion.identity;
		    }
                }

                isFirstRun = false;
            }
            else
            {
                int i = 0;
                // Update position and data of existing element objects
                foreach(Transform existingElementObject in Parent)
                {
	            if (searchSubStrings(existingElementObject.name, searchstrs)) {
                    	existingElementObject.parent.GetComponentInChildren<Element>().SetFromElementData(elements[i], typeMaterials);
                    	existingElementObject.localPosition = new Vector3(elements[i].xpos * ElementSeperationDistance - ElementSeperationDistance * 18 / 2, ElementSeperationDistance * 9 - elements[i].ypos * ElementSeperationDistance, 2.0f);
                    	existingElementObject.localRotation = Quaternion.identity;
                    	i++;
		    }
                }
                Parent.localPosition = new Vector3(0.0f, -0.7f, 0.7f);
                LegendTransform.localPosition = new Vector3(0.0f, 0.15f, 1.8f);

            }
        }

        public void randomRecipe()
        {

            // Parse the elements out of the json file
            TextAsset asset = Resources.Load<TextAsset>("JSON/PeriodicTableJSON");
            List<ElementData> elements = ElementsData.FromJSON(asset.text).elements;

            Dictionary<string, Material> typeMaterials = new Dictionary<string, Material>()
        {
            { "sweet", MatTransitionMetal },
            { "savory", MatMetalloid },
            { "spicy", MatDiatomicNonmetal },
            { "salty", MatNobleGas },
            { "sour", MatActinide },
            { "bitter", MatLanthanide },
        };


	    int index = UnityEngine.Random.Range(0, elements.Count);
	    ElementData element = elements[index];

            GameObject newElement = Instantiate<GameObject>(ElementPrefab, Parent);
            newElement.GetComponentInChildren<Element>().SetFromElementData(element, typeMaterials);
            newElement.transform.localPosition = new Vector3(element.xpos * ElementSeperationDistance - ElementSeperationDistance * 18 / 2, ElementSeperationDistance * 9 - element.ypos * ElementSeperationDistance, 2.0f);
            newElement.transform.localRotation = Quaternion.identity;
        }
    }
}
