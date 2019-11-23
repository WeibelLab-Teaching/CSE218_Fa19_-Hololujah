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

        using (StreamReader r = new StreamReader("C:\\Users\\rksubram\\Desktop\\Cse 218\\CSE218_Fa19_Hololujah\\db.json"))
        {
            string json = r.ReadToEnd();
            List<RootObject> ro = JsonConvert.DeserializeObject<List<RootObject>>(json);
            Debug.Log(ro);
            return ro.ToString();
        }
       
        
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