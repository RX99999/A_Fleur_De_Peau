using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This script is just setting properties on materials and sliders for presets regarding the skin
public class SkinPresets : MonoBehaviour
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

    }

    //il serait sans doute mieux de faire un tableau de materiaux et d iterer dessus.
    //de plus, on peut créer un script qui load toutes nos entitées, jsp trop comment au debut du bail
    public void SetVar1()
    {
        mat1.SetFloat("_Blue", 0.176f);
        mat2.SetFloat("_Blue", 0.176f);
        mat3.SetFloat("_Blue", 0.176f);
        mat1.SetFloat("_Red", 0.04f);
        mat2.SetFloat("_Red", 0.04f);
        mat3.SetFloat("_Red", 0.04f);
        mat1.SetFloat("_Green", 0.333f);
        mat2.SetFloat("_Green", 0.333f);
        mat3.SetFloat("_Green", 0.333f);
        red_set_Skin.value=0.04f;
        green_set_Skin.value=0.333f;
        blue_set_Skin.value=0.176f;
    }

    public void SetVar2()
    {
        mat1.SetFloat("_Blue", 0.443f);
        mat2.SetFloat("_Blue", 0.443f);
        mat3.SetFloat("_Blue", 0.443f);
        mat1.SetFloat("_Red", 0.052f);
        mat2.SetFloat("_Red", 0.052f);
        mat3.SetFloat("_Red", 0.052f);
        mat1.SetFloat("_Green", 0.513f);
        mat2.SetFloat("_Green", 0.513f);
        mat3.SetFloat("_Green", 0.513f);
        red_set_Skin.value=0.052f;
        green_set_Skin.value=0.513f;
        blue_set_Skin.value=0.443f;
    }

    public void SetVar3()
    {
        mat1.SetFloat("_Blue", 0.937f);
        mat2.SetFloat("_Blue", 0.937f);
        mat3.SetFloat("_Blue", 0.937f);
        mat1.SetFloat("_Red", 0.083f);
        mat2.SetFloat("_Red", 0.083f);
        mat3.SetFloat("_Red", 0.083f);
        mat1.SetFloat("_Green", 0.075f);
        mat2.SetFloat("_Green", 0.075f);
        mat3.SetFloat("_Green", 0.075f);
        red_set_Skin.value=0.083f;
        green_set_Skin.value=0.075f;
        blue_set_Skin.value=0.443f;
    }

    public void SetVar4()
    {
        mat1.SetFloat("_Blue", 0.843f);
        mat2.SetFloat("_Blue", 0.843f);
        mat3.SetFloat("_Blue", 0.843f);
        mat1.SetFloat("_Red", 0.056f);
        mat2.SetFloat("_Red", 0.056f);
        mat3.SetFloat("_Red", 0.056f);
        mat1.SetFloat("_Green", 0.233f);
        mat2.SetFloat("_Green", 0.233f);
        mat3.SetFloat("_Green", 0.233f);
        red_set_Skin.value=0.056f;
        green_set_Skin.value=0.233f;
        blue_set_Skin.value=0.843f;
    }

    public void SetVar5()
    {
        mat1.SetFloat("_Blue", 1f);
        mat2.SetFloat("_Blue", 1f);
        mat3.SetFloat("_Blue", 1f);
        mat1.SetFloat("_Red", 0.089f);
        mat2.SetFloat("_Red", 0.089f);
        mat3.SetFloat("_Red", 0.089f);
        mat1.SetFloat("_Green", 0.42f);
        mat2.SetFloat("_Green", 0.42f);
        mat3.SetFloat("_Green", 0.42f);
        red_set_Skin.value=0.089f;
        green_set_Skin.value=0.42f;
        blue_set_Skin.value=1f;
    }

    public void SetVar6()
    {
        mat1.SetFloat("_Blue", 1f);
        mat2.SetFloat("_Blue", 1f);
        mat3.SetFloat("_Blue", 1f);
        mat1.SetFloat("_Red", 0.117f);
        mat2.SetFloat("_Red", 0.117f);
        mat3.SetFloat("_Red", 0.117f);
        mat1.SetFloat("_Green", 0.376f);
        mat2.SetFloat("_Green", 0.376f);
        mat3.SetFloat("_Green", 0.376f);
        red_set_Skin.value=0.117f;
        green_set_Skin.value=0.376f;
        blue_set_Skin.value=1f;
    }

    public void SetVar7()
    {
        mat1.SetFloat("_Blue", 0.749f);
        mat2.SetFloat("_Blue", 0.749f);
        mat3.SetFloat("_Blue", 0.749f);
        mat1.SetFloat("_Red", 0.078f);
        mat2.SetFloat("_Red", 0.078f);
        mat3.SetFloat("_Red", 0.078f);
        mat1.SetFloat("_Green", 0.450f);
        mat2.SetFloat("_Green", 0.450f);
        mat3.SetFloat("_Green", 0.450f);
        red_set_Skin.value=0.078f;
        green_set_Skin.value=0.450f;
        blue_set_Skin.value=0.749f;
    }

    public void SetVar8()
    {
        mat1.SetFloat("_Blue", 0.349f);
        mat2.SetFloat("_Blue", 0.349f);
        mat3.SetFloat("_Blue", 0.349f);
        mat1.SetFloat("_Red", 0.044f);
        mat2.SetFloat("_Red", 0.044f);
        mat3.SetFloat("_Red", 0.044f);
        mat1.SetFloat("_Green", 0.607f);
        mat2.SetFloat("_Green", 0.607f);
        mat3.SetFloat("_Green", 0.607f);
        red_set_Skin.value=0.044f;
        green_set_Skin.value=0.607f;
        blue_set_Skin.value=0.349f;
    }

    
    
}
