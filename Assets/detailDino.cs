using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class detailDino : MonoBehaviour
{
    // Start is called before the first frame update



    public void show()
    {
        gameObject.SetActive(true);
        Debug.Log("show");
    }

    public void hide()
    {
        gameObject.SetActive(false);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
