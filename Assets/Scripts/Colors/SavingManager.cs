using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class SavingManager : MonoBehaviour
{
    [SerializeField]
    GameObject Red_Slider;
    [SerializeField]
    GameObject Blue_Slider;
    [SerializeField]
    GameObject Green_Slider;
    [SerializeField]
    public Dropdown Choice;
    public int portion;
    public GameObject buttonObj;

    public void saveGame()
    {
        
        if (!Directory.Exists("C:/Users/xinra/3INFO/Etude Pratique/intermidiaire/game_SaveGame"))
        {
            Directory.CreateDirectory("C:/Users/xinra/3INFO/Etude Pratique/intermidiaire/game_SaveGame");
        }

        BinaryFormatter formatter = new BinaryFormatter();
        portion = Choice.value;
        FileStream file = null ;

        switch (portion)
        {
            case 0 :
                file = File.Create("C:/Users/xinra/3INFO/Etude Pratique/intermidiaire/game_SaveGame/TshirtRGB.txt");
                break;

            case 1:
                file = File.Create("C:/Users/xinra/3INFO/Etude Pratique/intermidiaire/game_SaveGame/SkinRGB.txt");
                break;

            case 2:
                file = File.Create("C:/Users/xinra/3INFO/Etude Pratique/intermidiaire/game_SaveGame/PantsRGB.txt");
                break;

            default:
                // code block
                break;
        }

        var json0 = JsonUtility.ToJson(Red_Slider.GetComponent<Slider>().value);
        var json1 = JsonUtility.ToJson(Blue_Slider.GetComponent<Slider>().value);
        var json2 = JsonUtility.ToJson(Green_Slider.GetComponent<Slider>().value);

        formatter.Serialize(file, json0);
        formatter.Serialize(file, json1);
        formatter.Serialize(file, json2);

        file.Close();

    }

    public void loadGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        portion = Choice.value;
        FileStream file = null;

        switch (portion)
        {
            case 0:
                if (File.Exists("C:/Users/xinra/3INFO/Etude Pratique/intermidiaire/game_SaveGame/TshirtRGB.txt"))
                {
                    file = File.Open("C:/Users/xinra/3INFO/Etude Pratique/intermidiaire/game_SaveGame/TshirtRGB.txt", FileMode.Open);
                }
                    break;

            case 1:
                if (File.Exists("C:/Users/xinra/3INFO/Etude Pratique/intermidiaire/game_SaveGame/SkinRGB.txt"))
                {
                    file = File.Open("C:/Users/xinra/3INFO/Etude Pratique/intermidiaire/game_SaveGame/SkinRGB.txt", FileMode.Open);
                }
                break;

            case 2:
                if (File.Exists("C:/Users/xinra/3INFO/Etude Pratique/intermidiaire/game_SaveGame/PantsRGB.txt"))
                {
                    file = File.Open("C:/Users/xinra/3INFO/Etude Pratique/intermidiaire/game_SaveGame/PantsRGB.txt", FileMode.Open);
                }
                break;

            default:
                // code block
                break;
        }

        JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), Red_Slider.GetComponent<Slider>().value);
        JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), Blue_Slider.GetComponent<Slider>().value);
        JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), Green_Slider.GetComponent<Slider>().value);

            file.Close();
        

    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
            
    }
}
