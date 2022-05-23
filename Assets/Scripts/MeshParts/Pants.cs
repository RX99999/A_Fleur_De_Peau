using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pants : MonoBehaviour
{
    public Material mat;
    public Slider sliding;
    // Start is called before the first frame update
    void Start()
    {
        mat.SetFloat("_isPant",0);
        mat.SetFloat("_isTshirt",0);
        mat.SetFloat("_isSkin",0);
        sliding=this.gameObject.GetComponent<Slider>();
        sliding.onValueChanged.AddListener(delegate{SetOn();});
    }

    public void SetOn()
    {
        mat.SetFloat("_isPant",1);
    }
}
