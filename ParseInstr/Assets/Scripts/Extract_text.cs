using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using TMPro;
using System.IO;
using System.Web;


namespace ParseInstructions  //class to define all operattions while parsing instructions 
{
    public class Extract_text : MonoBehaviour
    {
        private TextMeshProUGUI textmesh; //Creating a textmesh object 
        private string initText = "Welcome to CookAR"; //Initial welcome message as a placeholder to the app 
        private int initdelay = 0; //Inital delay value till we display recipes 
        private Results[] Dish; 
        // Start is called before the first frame update
        void Start()
        {
            textmesh = GetComponent<TextMeshProUGUI>();
            textmesh.text = initText;
            Dish = extract();
        }


        // Update is called once per frame
        void Update()
        {
            initdelay += 1;
            if (initdelay > 1) //Change 1 to delay value 
            {
             
            }
        }

        //function used to extract data from our database
        static string oldextract()
        {

            using (StreamReader r = new StreamReader("C:\\Users\\rksubram\\Desktop\\Cse 218\\CSE218_Fa19_Hololujah\\db.json"))
            {
                string json = r.ReadToEnd();
                List<Results> ro = JsonConvert.DeserializeObject<List<Results>>(json);
               

                string retstr = "";
                
                foreach (Results res in ro) 
                {
                    print(res.id);
                    print(res.name);
                    retstr = retstr + res.name + "\t";
                }

                return retstr;
            }


        }

        //try
        Results[] extract()
        {

            using (StreamReader r = new StreamReader("C:\\Users\\rksubram\\Desktop\\Cse 218\\CSE218_Fa19_Hololujah\\db.json"))
            {
                string json = r.ReadToEnd();
                List<Results> ro = JsonConvert.DeserializeObject<List<Results>>(json);
                int i = 0;

                string retstr = "";

                Results[] Dish = new Results[ro.Count];
                foreach (Results res in ro)
                {
                    Dish[i] = new Results();
                    Dish[i] = res;
                    retstr = retstr + res.name + "\t";
                    Debug.Log(Dish[i].name);
                    Debug.Log(Dish[i].instructions);
                    i += 1;
                }

                return Dish;
            }
        }

        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public System.DateTime BirthDate { get; set; }
        }

        public class Employee : Person
        {
            public string Department { get; set; }
            public string JobTitle { get; set; }
        }

        public class RootObject
        {
            public string count { get; set; }
            public Results[] results { get; set; }
        }

        public class Results
        {
            public string id { get; set; }
            public string name { get; set; }
            public string source { get; set; }
            public int preptime { get; set; }
            public int waittime { get; set; }
            public int cooktime { get; set; }
            public int servings { get; set; }
            public string comments { get; set; }
            public int calories { get; set; }
            public int fat { get; set; }
            public int satfat { get; set; }
            public int carbs { get; set; }
            public int fiber { get; set; }
            public int sugar { get; set; }
            public int protein { get; set; }
            public string instructions { get; set; }
            public List<string> ingredients { get; set; }
            public List<string> tags { get; set; }
        }




    }
}