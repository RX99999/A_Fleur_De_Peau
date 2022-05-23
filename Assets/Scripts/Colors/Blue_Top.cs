using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blue_Top : MonoBehaviour
{
    public Material mat;

    private Slider blue_set;
    public float blue;
    // Start is called before the first frame update
    void Start()
    {
        blue_set=this.gameObject.GetComponent<Slider>();
        mat.SetFloat("_blueTshirt",(float)1);
    }

    public void GetBlue()
    {
       blue= blue_set.value;
       mat.SetFloat("_blueTshirt",blue);
    }

}
