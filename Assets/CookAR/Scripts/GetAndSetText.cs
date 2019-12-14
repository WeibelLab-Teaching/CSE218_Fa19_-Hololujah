using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace CookARmain
{
	
	public class GetAndSetText : MonoBehaviour
	{
		public InputField Dishname;
		public InputField Categoryname;
		public Text fText;
	
		public void setget()
		{
			fText.text = "Dish name you entered is: " + Dishname.text + " and Category name is: " + Categoryname.text;
		}
	}
}
