using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelActive : MonoBehaviour
{
    public option quitoption;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void show()
    {
        gameObject.SetActive(true);
    }

    public void hide()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            quitoption.show();
        }
    }
}

