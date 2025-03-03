using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SimpleImageBehaviour : MonoBehaviour
{

    private Image imageObj;
    public SimpleFloatData dataObj;
    // Start is called before the first frame update
    void Start()
    {
        imageObj = GetComponent<Image>();
        imageObj.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        imageObj.fillAmount = dataObj.value;

        /*if (imageObj.fillAmount > 1)
        {
            imageObj.fillAmount = 1;
        }*/
    }
}
