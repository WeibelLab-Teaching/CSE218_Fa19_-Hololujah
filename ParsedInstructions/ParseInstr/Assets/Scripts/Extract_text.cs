using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using TMPro;
using System.IO;
using System.Web;

public class Extract_text : MonoBehaviour
{
    private TextMeshProUGUI textmesh;
    private string initText = "Welcome to CookAR";
    private int initdelay = 0;

    // Start is called before the first frame update
    void Start()
    {
        textmesh = GetComponent<TextMeshProUGUI>();
        textmesh.text = initText;
    }

    
    // Update is called once per frame
    void Update()
    {
        initdelay += 1;
        if (initdelay > 1)
        {
            textmesh.text = extract();
        }
    }

    static string extract()
    {
        /*
        string json = @"['Starcraft','Halo','Legend of Zelda']";


        List<string> videogames = JsonConvert.DeserializeObject<List<string>>(json);
        return string.Join(", ", videogames.ToArray());
        */

        /*
        string json1 = @"{
          'Department': 'Furniture',
          'JobTitle': 'Carpenter',
          'FirstName': 'John',
          'LastName': 'Joinery',
          'BirthDate': '1983-02-02T00:00:00'
        }";

        Person person = JsonConvert.DeserializeObject<Person>(json1);

        print(person.FirstName);
        // Employee

        return person.GetType().Name;
        */


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


        /*
        using (StreamReader r = new StreamReader("C:\\Users\\rksubram\\Desktop\\Cse 218\\CSE218_Fa19_Hololujah\\db.json"))
        {
            string json = r.ReadToEnd();
            //return json;
            //List<RootObject> ro = JsonConvert.DeserializeObject<List<RootObject>>(json);
            RootObject ro = JsonConvert.DeserializeObject<RootObject>(json);
            //Debug.Log(ro);
            //Debug.Log(ro.GetType());
            print("I am Dharmendra");
            print(ro.results[0]);
            
            return ro.ToString();
        }
        */


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