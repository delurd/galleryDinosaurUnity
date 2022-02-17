using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class detailDino : MonoBehaviour
{
    public pointButton pointbutton;
    public closedinoDetail closedinodetail;


    public void show()
    {
        gameObject.SetActive(true);
        Debug.Log("show");
    }

    public void hide()
    {
        gameObject.SetActive(false);
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(pointbutton.toggle == true)
            {
                closedinodetail.aksiClose();
            }
            else
            {
                //pointbutton.aksi();
            }

        }
    }
}
