using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    public Material mat;
    [SerializeField]
    GameObject Red_Slider_Tshirt;
    [SerializeField]
    GameObject Blue_Slider_Tshirt;
    [SerializeField]
    GameObject Green_Slider_Tshirt;
    [SerializeField]
    GameObject Red_Slider_Pants;
    [SerializeField]
    GameObject Blue_Slider_Pants;
    [SerializeField]
    GameObject Green_Slider_Pants;
    [SerializeField]
    GameObject Red_Slider_Skin;
    [SerializeField]
    GameObject Blue_Slider_Skin;
    [SerializeField]
    GameObject Green_Slider_Skin;
    [SerializeField]
    GameObject Selector;
 
    private Slider red_set_Tshirt;
    private Slider red_set_Pants;
    private Slider red_set_Skin;
    private Slider blue_set_Tshirt;
    private Slider blue_set_Pants;
    private Slider blue_set_Skin;
    private Slider green_set_Tshirt;
    private Slider green_set_Pants;
    private Slider green_set_Skin;

    // Start is called before the first frame update
    void Start()
    {
        red_set_Tshirt = Red_Slider_Tshirt.gameObject.GetComponent<Slider>();
        red_set_Pants = Red_Slider_Pants.gameObject.GetComponent<Slider>();
        red_set_Skin = Red_Slider_Skin.gameObject.GetComponent<Slider>();
        blue_set_Tshirt = Blue_Slider_Tshirt.gameObject.GetComponent<Slider>();
        blue_set_Pants = Blue_Slider_Pants.gameObject.GetComponent<Slider>();
        blue_set_Skin = Blue_Slider_Skin.gameObject.GetComponent<Slider>();
        green_set_Tshirt = Green_Slider_Tshirt.gameObject.GetComponent<Slider>();
        green_set_Pants = Green_Slider_Pants.gameObject.GetComponent<Slider>();
        green_set_Skin = Green_Slider_Skin.gameObject.GetComponent<Slider>();

       mat.SetFloat("_redTshirt",(float)1);
       mat.SetFloat("_redPants", (float)1);
       mat.SetFloat("_redSkin", (float)1);
       mat.SetFloat("_blueTshirt", (float)1);
       mat.SetFloat("_bluePants", (float)1);
       mat.SetFloat("_blueSkin", (float)1);
       mat.SetFloat("_greenTshirt", (float)1);
       mat.SetFloat("_greenPants", (float)1);
       mat.SetFloat("_greenSkin", (float)1);
    }

    public void GetRedTshirt()
    {
       mat.SetFloat("_redTshirt",red_set_Tshirt.value);
    }

    public void GetRedPants()
    {
        mat.SetFloat("_redPants", red_set_Pants.value);
    }
    public void GetRedTSkin()
    {
        mat.SetFloat("_redSkin", red_set_Skin.value);
    }

    public void GetBlueTshirt()
    {
        mat.SetFloat("_blueTshirt", blue_set_Tshirt.value);
    }

    public void GetBluePants()
    {
        mat.SetFloat("_bluePants", blue_set_Pants.value);
    }
    public void GetBlueTSkin()
    {
        mat.SetFloat("_blueSkin", blue_set_Skin.value);
    }
    public void GetGreenTshirt()
    {
        mat.SetFloat("_greenTshirt", green_set_Tshirt.value);
    }

    public void GetGreenPants()
    {
        mat.SetFloat("_greenPants", green_set_Pants.value);
    }
    public void GetGreenTSkin()
    {
        mat.SetFloat("_greenSkin", green_set_Skin.value);
    }
}
