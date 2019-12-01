using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace RecipeTable
{
    public class Dish : MonoBehaviour
    {

        public static Dish ActiveDish;

        public TextMesh DishID;
        public TextMesh DishName;
        public TextMesh DishSource;


        public Text Dishpreptime;
        public Text Dishwaittime;
        public Text Dishcooktime;
        public Text Dishservings;
        public TextMesh Dishcomments;
        public Text Dishcalories;
        public Text Dishfat;
        public Text Dishsatfat;
        public Text Dishcarbs;
        public Text Dishfiber;
        public Text Dishsugar;
        public Text Dishprotein;
        public TextMeshProUGUI Dishinstructions;
        public TextMeshProUGUI Dishingredients;
        public TextMeshProUGUI Dishtags;


        public Renderer BoxRenderer;
        public MeshRenderer[] PanelSides;
        public MeshRenderer PanelFront;
        public MeshRenderer PanelBack;
        public MeshRenderer[] InfoPanels;

        [HideInInspector]
        public DishData data;

        //private BoxCollider boxCollider;
        //private Material highlightMaterial;
        //private Material dimMaterial;
        //private Material clearMaterial;
        private PresentToPlayer present;

        public void SetActiveDish()
        {
            Dish dish = gameObject.GetComponent<Dish>();
            ActiveDish = dish;
        }

        public void ResetActiveDish()
        {
            ActiveDish = null;
        }

        public void Start()
        {
            // Turn off our animator until it's needed
            GetComponent<Animator>().enabled = false;
            BoxRenderer.enabled = true;
            present = GetComponent<PresentToPlayer>();
        }

        public void Open()
        {
            if (present.Presenting)
                return;

            StartCoroutine(UpdateActive());
        }

       /* public void Highlight()
        {
            if (ActiveDish == this)
                return;

            for (int i = 0; i < PanelSides.Length; i++)
            {
                PanelSides[i].sharedMaterial = highlightMaterial;
            }
            PanelBack.sharedMaterial = highlightMaterial;
            PanelFront.sharedMaterial = highlightMaterial;
            BoxRenderer.sharedMaterial = highlightMaterial;
        }

        public void Dim()
        {
            if (ActiveDish == this)
                return;

            for (int i = 0; i < PanelSides.Length; i++)
            {
                PanelSides[i].sharedMaterial = dimMaterial;
            }
            PanelBack.sharedMaterial = dimMaterial;
            PanelFront.sharedMaterial = dimMaterial;
            BoxRenderer.sharedMaterial = dimMaterial;
        }
        */
        public IEnumerator UpdateActive()
        {
            present.Present();

            while (!present.InPosition)
            {
                // Wait for the item to be in presentation distance before animating
                yield return null;
            }

            // Start the animation
            Animator animator = gameObject.GetComponent<Animator>();
            animator.enabled = true;
            animator.SetBool("Opened", true);

            //Color elementNameColor = ElementName.GetComponent<MeshRenderer>().material.color;

            while (Dish.ActiveDish == this)
            {
                //ElementName.GetComponent<MeshRenderer>().material.color = elementNameColor;
                // Wait for the player to send it back
                yield return null;
            }

            animator.SetBool("Opened", false);

            yield return new WaitForSeconds(0.66f); // TODO get rid of magic number        

            // Return the item to its original position
            present.Return();
            //Dim();
        }


        /**
         * Set the display data for this element based on the given parsed JSON data
         */
        //public void SetFromDishData(DishData data, Dictionary<string, Material> typeMaterials)
        public void SetFromDishData(DishData data)
        {
            this.data = data;
            //DishID.text = data.id;
            DishName.text = data.name;
            /*DishSource.text = data.source;
            
                Dishpreptime.text = data.preptime.ToString();
            Dishwaittime.text = data.waittime.ToString();
            Dishcooktime.text = data.cooktime.ToString();
            Dishservings.text = data.servings.ToString();
            Dishcomments.text = data.comments;
            Dishcalories.text = data.calories.ToString();
            Dishfat.text = data.fat.ToString();
            Dishsatfat.text = data.satfat.ToString();
            Dishcarbs.text = data.carbs.ToString();
            Dishfiber.text = data.fiber.ToString();
            Dishsugar.text = data.sugar.ToString();
            Dishprotein.text = data.protein.ToString();
            Dishinstructions.text = data.instructions;
            */
            Debug.Log(DishName.text);
            
            //Dishingredients = data.ingredients.ToString();
            //public TextMeshProUGUI Dishtags;


            // Set up our materials
            //if (!typeMaterials.TryGetValue(data.category.Trim(), out dimMaterial))
            //{
            //    Debug.Log("Couldn't find " + data.category.Trim() + " in element " + data.name);
            //}

            // Create a new highlight material and add it to the dictionary so other can use it
            //string highlightKey = data.category.Trim() + " highlight";
           // if (!typeMaterials.TryGetValue(highlightKey, out highlightMaterial))
           // {
           //     highlightMaterial = new Material(dimMaterial);
           //      highlightMaterial.color = highlightMaterial.color * 1.5f;
           //     typeMaterials.Add(highlightKey, highlightMaterial);
           // }

           // Dim();

           // foreach (Renderer infoPanel in InfoPanels)
          //  {
                // Copy the color of the element over to the info panels so they match
          //      infoPanel.material.color = dimMaterial.color;
           // }

            BoxRenderer.enabled = false;

            // Set our name so the container can alphabetize
            transform.parent.name = data.name;
        }

    }
}
