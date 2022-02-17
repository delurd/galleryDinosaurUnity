using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;


public class pointButton : MonoBehaviour
{
    public Sprite up;
    public Sprite down;

    public bool toggle;
    GameObject panelPoint;
    Vector3 hidePos;

    // Start is called before the first frame update
    void Start()
    {
        toggle = true;

        panelPoint = transform.parent.gameObject;
        hidePos = panelPoint.GetComponent<RectTransform>().localPosition;

        gameObject.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            aksi();
        });
    }

    public void aksi()
    {
        if (toggle == true) //jika true maka naik
        {
            /*                Debug.Log("true");*/
            /* panelPoint.GetComponent<RectTransform>().localPosition = new Vector3(0, 0 , 0);*/
            panelPoint.GetComponent<RectTransform>().DOLocalMove(new Vector3(0, 0, 0), 0.3f);


            transform.GetChild(0).GetComponent<Image>().sprite = down; //icon berubah turun
            toggle = false;
        }
        else //jika false maka turun
        {
            /*                Debug.Log("false");*/
            panelPoint.GetComponent<RectTransform>().DOLocalMove(new Vector3(0, hidePos.y, 0), 0.3f);

            transform.GetChild(0).GetComponent<Image>().sprite = up; //icon berubah naik

            toggle = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
