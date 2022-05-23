using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using LitJson;
using TMPro;
using Newtonsoft.Json;
public class Colorall : MonoBehaviour
{

    //Texture passée au shader, elle va servir a envoyer indifféremment au shader les différentes
    //couleurs choisis dans l interface utilisateur
    public Texture2D texture;


    public Material mat;
    [SerializeField]
    GameObject Red_Slider;
    [SerializeField]
    GameObject Blue_Slider;
    [SerializeField]
    GameObject Green_Slider;
    [SerializeField]
    public Dropdown Choice;
    [SerializeField]
    public TMP_InputField savename;
    public int perso;
    public int nbpersomax =3;
    public Material[] mattab;
    public InputField nopersovisible;
    public Button PersoSuivantButton;
    public Button PersoAvantButton;
    public GameObject buttonObj;

//to change by a kind of lead in the tab 

    public GameObject Punk;
    public GameObject f001;
    public GameObject cadre;


    //DICT DE LIAISON : Liaison des standards de parties du corps du drop down
    //avec les nuances de gris associées (et donc les pixels de l'image passée au shader qui
    //seront modifiés)
    public Dictionary<string, int> greyValues = new Dictionary<string, int>(){
	    {"Tshirt", 40},
	    {"Corps", 120},
	    {"Jean", 80},
        {"Manteau", 130},
	    {"Chaussures", 200},

};


 //Array for characters
    public GameObject[] persotab;
//Reference to the right rotation button
    public RotationRight rotationRight;
//Reference to the left rotation button
    public RotationLeft rotationLeft;
//Reference to the gameObject dealing with file opener
    public FileManagerUpdate fileManagerUpdate;



    //soit le materiaux mat a un choix des differents trucs a app selont la valeur de la box
    public Slider red_set;
    private Slider blue_set;
    private Slider green_set;
    private Slider alpha_set;

    // private float Red, Green, Blue;
    public int portion;


    // Start is called before the first frame update
    void Start()
    {
         //init du dropdown et des nuances de gris associées par 
        //Rapport a ce qui a été set dans l alpha masker
        readDict();
        //possibilité de rajouter une fonction qui intere sur la texture et init le 
        //Dropdown exactement avec les parties du corps présentent et non toute la base de donnée


        //CREATION SI BESOIN ET AJOUT DES COULEURS DANS LA TEXTURE QUI SERA LUE PAR LE SHADER
        texture = new Texture2D(256, 1, TextureFormat.RGBAFloat,false);

        for(int i=0;i<256;i++){
            texture.SetPixel(i, 0,new Color(0f, 0f, 0f, 0f)); 
        }
        //Valeurs par défaut pour les pixels de la Texture

        nbpersomax=3;

        mattab = new Material[nbpersomax];
    //We have to be carefull, here we call reference of property of material
    //theses references can be seen and changed by clicking on the property in
    //shadergraph and then going on graph inspector
       mattab[0]=Resources.Load("M_Casual_14_L_Pbr", typeof(Material)) as Material;
       mattab[1]=Resources.Load("f001_body_color", typeof(Material)) as Material;
       mattab[2]=Resources.Load("M_Casual_15_L_Pbr", typeof(Material)) as Material;

        persotab= new GameObject[nbpersomax];

        //load directly in the tab
        Punk=GameObject.Find("Punk");
        f001=GameObject.Find("f001");
        cadre=GameObject.Find("cadre_quarantenaire");
        
    //Addding characters in the array
        persotab[0]=Punk;
        persotab[1]=f001;
        persotab[2]=cadre;

       //Link between GUI Sliders to the sliders values inside the script
        red_set = Red_Slider.gameObject.GetComponent<Slider>();
        blue_set = Blue_Slider.gameObject.GetComponent<Slider>();
        green_set = Green_Slider.gameObject.GetComponent<Slider>();
 
        //Get the dropdown value to know what to modify
        portion = Choice.value;


       for(int i=0;i<nbpersomax;i++){
       //     mattab[i].SetTexture("_Values",texture);
       }
        nopersovisible.text="0";

    //Setting the rotation button on the current character and initializing the path
        rotationRight.rotatedObject=persotab[perso];
        rotationLeft.rotatedObject=persotab[perso];
        
        fileManagerUpdate.pathforJson="";
        fileManagerUpdate.pathforLoad="";
        mat.SetTexture("_Values",texture);
        texture.Apply();
    }

    public void readDict(){
        List<UnityEngine.UI.Dropdown.OptionData> Ourlist = new List<UnityEngine.UI.Dropdown.OptionData>();

         if (File.Exists(fileManagerUpdate.pathforLoad)){
             print("file exist");
             var reader = new StreamReader(File.OpenRead(fileManagerUpdate.pathforLoad));
             //on passe la premiere ligne
             reader.ReadLine();

             while (!reader.EndOfStream)
                {
                var line = reader.ReadLine();
                var value = line.Split(',');
                if(greyValues.ContainsKey(value[0])){  
                    greyValues[value[0]]=int.Parse(value[1]);
                }
                else{
                    greyValues.Add(value[0],int.Parse(value[1]));
                }    
                }}
         else
         {
             print("file dont exist");
             Choice.ClearOptions();
               

             foreach (string key in greyValues.Keys)
            {
                Ourlist.Add(new Dropdown.OptionData(key));
            }
                 Choice.AddOptions(Ourlist);
            RefreshOptions();
             return;

            }

           Choice.ClearOptions();
    

             foreach (string key in greyValues.Keys)
            {
                Ourlist.Add(new Dropdown.OptionData(key));
            }
                 Choice.AddOptions(Ourlist);
            RefreshOptions();

         }



    


    public void RefreshOptions()
        {
        Choice.enabled = false;
        Choice.enabled = true;
        Choice.Show();
        }

    
    public void persosup(){
        //Current character is thrown away from scene and his angle of rotation is reset
        persotab[perso].transform.position = new Vector3(-10f,-10f,-10f);
        persotab[perso].transform.eulerAngles= new Vector3(4.394f,170.553f,-0.73f);
        perso = perso + 1;
        if(perso>nbpersomax-1){
            perso =0;
        }
        nopersovisible.text=perso.ToString();
        mat=mattab[perso];
        
        for(int i=0;i<256;i++){
            texture.SetPixel(i, 0,new Color(0f, 0f, 0f, 0f)); 
        }
        mat.SetTexture("_Values",texture);
        texture.Apply();
        //Next character is brought to the scene
        persotab[perso].transform.position = new Vector3(-0.45f,0.163f,-8.111f);
        //Condition handling the "cadre" character being taller than the reference (the punk) so as to set his position below
        if(persotab[perso]==cadre){
            persotab[perso].transform.position = new Vector3(-0.45f,0.068f,-8.111f);
        }
        //Set of rotation button on new characters
        rotationRight.rotatedObject=persotab[perso];
        rotationLeft.rotatedObject=persotab[perso];
    }

    //Same principle as the previous function 
    public void persomoins(){
        persotab[perso].transform.position = new Vector3(-10f,-10f,-10f);
        persotab[perso].transform.eulerAngles= new Vector3(4.394f,170.553f,-0.73f);
        perso = perso-1;
        if(perso<0){
            perso = nbpersomax -1;
        }
        print(mat);
        nopersovisible.text=perso.ToString();
        mat = mattab[perso];
        for(int i=0;i<256;i++){
            texture.SetPixel(i, 0,new Color(0f, 0f, 0f, 0f)); 
        }
        mat.SetTexture("_Values",texture);
        texture.Apply();
        persotab[perso].transform.position = new Vector3(-0.45f,0.163f,-8.111f);
        if(persotab[perso]==cadre){
            persotab[perso].transform.position = new Vector3(-0.45f,0.068f,-8.111f);
        }
        rotationRight.rotatedObject=persotab[perso];
        rotationLeft.rotatedObject=persotab[perso];

    }

    
    /**
We write the RGB value (not hsv) of sliders
En vrai on aurait pu en faire qu une mais bon une par slider ca sert a rien mais en jette
**/
    public void GetRed()
    {
        int positionTex = greyValues[Choice.options[Choice.value].text];
        print("Here's where we're writing : "+positionTex);
        // print("HUE value : "+red_set.value);

        float  hue = red_set.value;
        float sat =  green_set.value;
        float value = blue_set.value;
        Color a = Color.HSVToRGB(hue, sat, value);
        //Color a = new Color(hue,sat,value,1);
        texture.SetPixel(positionTex, 0, a);
        //We have to be carefull here with the tuning, which value of color is considered as null in multiply ?
        //texture.SetPixel(positionTex, 0, new Color(red_set.value, green_set.value,blue_set.value, alpha_set.value));
        print("Values updated");
        print(Choice.options[Choice.value].text);
        texture.Apply();
        //  byte[] bytes = texture.EncodeToPNG();
        //  File.WriteAllBytes("C:\\Users\\Marius\\Downloads\\" + "debug" + ".png", bytes);
         print("Pixel just set red "+positionTex+"  "+texture.GetPixel(positionTex,0)[0]);

    }


    public void GetGreen()
    {
         int positionTex = greyValues[Choice.options[Choice.value].text];
        print("Here's where we're writing : "+positionTex);
        print("Sat value : "+green_set.value);

        float  hue = red_set.value;
        float sat =  green_set.value;
        float value = blue_set.value;
        Color a = Color.HSVToRGB(hue, sat, value,true);

       texture.SetPixel(positionTex, 0, a);
        print("Values updated");
        print(Choice.options[Choice.value].text);
        texture.Apply();
        print("Pixel just set Green "+positionTex+"  "+texture.GetPixel(positionTex,0)[1]);


    }
     public void GetBlue()
    {
        int positionTex = greyValues[Choice.options[Choice.value].text];
        print("Here's where we're writing : "+positionTex);
        float  hue = red_set.value;
        float sat =  green_set.value;
        float value = blue_set.value;
        print("VALUE value : "+value);

        Color a = Color.HSVToRGB(hue, sat, value);
        texture.SetPixel(positionTex, 0, a);
       // texture.SetPixel(positionTex, 0, new Color(red_set.value, green_set.value, blue_set.value, alpha_set.value));
        print("Values updated");
        texture.Apply();
        print("Pixel just set BLUE "+positionTex+"  "+texture.GetPixel(positionTex,0)[2]);

    }


    public void Reset(){
        texture = new Texture2D(256, 1, TextureFormat.RGBAFloat,false);
          for(int i=0;i<256;i++){
            texture.SetPixel(i, 0,new Color(0f, 0f, 0f, 0f)); 
        }
        mat.SetTexture("_Values",texture);
        texture.Apply();
    }
     public void setPortion()
    {
            portion=Choice.value;
            //On portion changed, reload from the tab great value for the sliders and update ui

    }

       public void saveGame()
    {
            print(fileManagerUpdate.pathforJson+"/"+savename.text);
         if (!Directory.Exists(fileManagerUpdate.pathforJson))
         {
             print("No directory output ! Nothing will be saved unless ");
             print("you add one thanks to this beautiful button setted up by Elouan");
             }
        else{
            Dictionary<string, int[]> SaveValues = new Dictionary<string,int[]>();
                
            foreach(string BodyPart in greyValues.Keys ){
                Color encours = texture.GetPixel(greyValues[BodyPart],0);

                int r = (int)(encours[0]*255);
                int g = (int)(encours[1]*255);
                int b = (int)(encours.b*255);
                print(BodyPart+greyValues[BodyPart] +" red "+ r);
               
                if(r<0 || r>10000){
                    r=-1;
                }
                if(g<0 || g>10000){
                    g=-1;
                }
                if(b<0 || b>10000){
                    b=-1;
                }
                
                int[] letsgo = new int[4] {r,g,b,1};
                
                

                SaveValues.Add(BodyPart,letsgo);
                
            }
            JsonData save = JsonMapper.ToJson(SaveValues);
            File.WriteAllText(fileManagerUpdate.pathforJson+"/"+savename.text+".json", save.ToString());
            //Export of the passage texture directly if we wanna to :
            byte[] bytes = texture.EncodeToPNG();
            File.WriteAllBytes(fileManagerUpdate.pathforJson+"/"+savename.text+".png", bytes);
        }

       
    }

  
    public void loadByJson()
    {
        //2 differents option depending on what kind of load do you want
        //Json oriented one :
        if(File.Exists(fileManagerUpdate.pathforJson+"/"+savename.text+".json")){
            var json = File.ReadAllText(fileManagerUpdate.pathforJson+"/"+savename.text+".json");
            var result = JsonConvert.DeserializeObject<Dictionary<string, int[]>>(json);

        for(int i=0;i<256;i++){
            texture.SetPixel(i, 0,new Color(0f, 0f, 0f, 0f)); 
        }
    
            print("work out by jsonnn");
        foreach(string BodyPart in result.Keys ){
            float r = (float)((double)result[BodyPart][0]/255);
            float g = (float)((double)result[BodyPart][1]/255);
            float b =(float) ((double)result[BodyPart][2]/255);
            print((double)result["Jean"][0]/255);
            Color a = new Color(r,g,b,1);
            texture.SetPixel(greyValues[BodyPart], 0, a);
        }
        texture.Apply();
        // byte[] bytes = texture.EncodeToPNG();
        // File.WriteAllBytes("C:\\Users\\Marius\\Downloads\\" + "debug" + ".png", bytes);

        }
        else{
            print("Wanted save not found, have you properly set the path ?");
        }
        
        //texture oriented one :
        // if(File.Exists(fileManagerUpdate.pathforJson+"/"+savename.text+".png")){
        //     byte[] fileData = File.ReadAllBytes (fileManagerUpdate.pathforJson+"/"+savename.text+".png");
        //     texture.LoadImage(fileData);
        // }
        //  else{
        //     print("Wanted save not found, have you properly set the path ?");
        // }

    }
       

    }        
    //     {
    //         case 0:
    //             filePath = "C:/Users/xinra/3INFO/Etude Pratique/intermidiaire/game_SaveGame/TshirtRGB.txt";
    //             if (File.Exists(filePath))
    //             {
    //                 StreamReader sr = new StreamReader(filePath);
                    
    //                 string jsonStr = sr.ReadToEnd();
                    
    //                 sr.Close();

    //                 Save save = JsonMapper.ToObject<Save>(jsonStr);

    //                 mat.SetFloat("_RedT", (float)save.red);
    //                 mat.SetFloat("_BlueT", (float)save.blue);
    //                 mat.SetFloat("_GreenT", (float)save.green);

    //             }

    //             break;

    //         case 1:
    //             filePath = "C:/Users/xinra/3INFO/Etude Pratique/intermidiaire/game_SaveGame/SkinRGB.txt";
    //             if (File.Exists(filePath))
    //             {
    //                 StreamReader sr = new StreamReader(filePath);

    //                 string jsonStr = sr.ReadToEnd();

    //                 sr.Close();

    //                 Save save = JsonMapper.ToObject<Save>(jsonStr);

    //                 mat.SetFloat("_RedSkin", (float)save.red);
    //                 mat.SetFloat("_BlueSkin", (float)save.blue);
    //                 mat.SetFloat("_GreenSkin", (float)save.green);

    //             }

    //             break;

    //         case 2:
    //             filePath = "C:/Users/xinra/3INFO/Etude Pratique/intermidiaire/game_SaveGame/PantsRGB.txt";
    //             if (File.Exists(filePath))
    //             {
    //                 StreamReader sr = new StreamReader(filePath);

    //                 string jsonStr = sr.ReadToEnd();

    //                 sr.Close();

    //                 Save save = JsonMapper.ToObject<Save>(jsonStr);

    //                 mat.SetFloat("_RedPant", (float)save.red);
    //                 mat.SetFloat("_BluePant", (float)save.blue);
    //                 mat.SetFloat("_GreenPant", (float)save.green);

    //             }

    //             break;

    //         default:

    //             break;
    //     }
    // }
 


