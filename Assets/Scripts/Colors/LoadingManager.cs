using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
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
        if (Input.GetMouseButtonDown(0))
        {
            buttonObj.GetComponent<Button>().onClick.AddListener(loadGame);
        }
    }
}
