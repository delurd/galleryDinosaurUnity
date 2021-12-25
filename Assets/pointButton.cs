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


    // Start is called before the first frame update
    void Start()
    {
        bool toggle = true;

        GameObject panelPoint = transform.parent.gameObject;
        Vector3 hidePos = panelPoint.GetComponent<RectTransform>().localPosition;

        gameObject.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            if(toggle == true)
            {
/*                Debug.Log("true");*/
               /* panelPoint.GetComponent<RectTransform>().localPosition = new Vector3(0, 0 , 0);*/
                panelPoint.GetComponent<RectTransform>().DOLocalMove(new Vector3(0, 0, 0), 0.3f);


                transform.GetChild(0).GetComponent<Image>().sprite = down;
                toggle = false;
            }
            else
            {
/*                Debug.Log("false");*/
                panelPoint.GetComponent<RectTransform>().DOLocalMove(new Vector3(0, hidePos.y, 0), 0.3f);

                transform.GetChild(0).GetComponent<Image>().sprite = up;

                toggle = true;
            }

        }); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
