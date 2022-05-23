using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Green_Top : MonoBehaviour
{
    public Material mat;

    private Slider green_set;
    public float green;
    // Start is called before the first frame update
    void Start()
    {
        green_set=this.gameObject.GetComponent<Slider>();
        mat.SetFloat("_greenTshirt",(float)1);
    }

    public void Getgreen()
    {
       green= green_set.value;
       mat.SetFloat("_greenTshirt",green);
    }

}
