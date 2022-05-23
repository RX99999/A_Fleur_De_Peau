using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colorskin : MonoBehaviour
{
    public Material mat1;
    public Material mat2;
    public Material mat3;
    [SerializeField]
    GameObject Red_Slider_Skin;
    [SerializeField]
    GameObject Blue_Slider_Skin;
    [SerializeField]
    GameObject Green_Slider_Skin;


    public Slider red_set_Skin;
    public Slider blue_set_Skin;
    public Slider green_set_Skin;

    // Start is called before the first frame update
    void Start()
    {
        red_set_Skin = Red_Slider_Skin.gameObject.GetComponent<Slider>();
        blue_set_Skin = Blue_Slider_Skin.gameObject.GetComponent<Slider>();
        green_set_Skin = Green_Slider_Skin.gameObject.GetComponent<Slider>();

       mat1.SetFloat("_Red", (float)0);
       mat2.SetFloat("_Red", (float)0);
       mat3.SetFloat("_Red", (float)0);
       mat1.SetFloat("_Blue", (float)1);
       mat2.SetFloat("_Blue", (float)1);
       mat3.SetFloat("_Blue", (float)1);
       mat1.SetFloat("_Green", (float)0);
       mat2.SetFloat("_Green", (float)0);
       mat3.SetFloat("_Green", (float)0);
    }

    //il serait sans doute mieux de faire un tableau de materiaux et d iterer dessus.
    //de plus, on peut créer un script qui load toutes nos entitées, jsp trop comment au debut du bail
    public void GetBlueSkin()
    {
        mat1.SetFloat("_Blue", blue_set_Skin.value);
        mat2.SetFloat("_Blue", blue_set_Skin.value);
        mat3.SetFloat("_Blue", blue_set_Skin.value);
    }
    public void GetRedSkin()
    {
        mat1.SetFloat("_Red", red_set_Skin.value);
        mat2.SetFloat("_Red", red_set_Skin.value);
        mat3.SetFloat("_Red", red_set_Skin.value);
    }
    public void GetGreenSkin()
    {
        mat1.SetFloat("_Green", green_set_Skin.value);
        mat2.SetFloat("_Green", green_set_Skin.value);
        mat3.SetFloat("_Green", green_set_Skin.value);
    }

    public void Reset(){
        red_set_Skin.value=0;
        green_set_Skin.value=0;
        blue_set_Skin.value=1;
        mat1.SetFloat("_Green", green_set_Skin.value);
        mat2.SetFloat("_Green", green_set_Skin.value);
        mat3.SetFloat("_Green", green_set_Skin.value);
        mat1.SetFloat("_Red", red_set_Skin.value);
        mat2.SetFloat("_Red", red_set_Skin.value);
        mat3.SetFloat("_Red", red_set_Skin.value);
        mat1.SetFloat("_Blue", blue_set_Skin.value);
        mat2.SetFloat("_Blue", blue_set_Skin.value);
        mat3.SetFloat("_Blue", blue_set_Skin.value);
    }
}
