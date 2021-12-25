using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class coba : MonoBehaviour
{
    public detailDino DetailDino;

    [Serializable]
    public struct isinya
    {
       public string text;
    }
    [SerializeField] isinya[] isi;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("coba");

       

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void instatiatChildofChild()
    {
        GameObject Go = transform.GetChild(0).GetChild(0).gameObject;
        GameObject GoParent = transform.GetChild(0).gameObject; //Parent of Button Go

        GameObject duplikat;
        int jumlah = isi.Length;

        for (int i = 0; i < jumlah; i++)
        {
            duplikat = Instantiate(Go, GoParent.transform);
            duplikat.transform.GetChild(0).GetComponent<Text>().text = isi[i].text;
        }

    }



    void changePosition()
    {
        GameObject go = gameObject;

        float wid = go.GetComponent<RectTransform>().rect.width;
        Vector3 goPos = go.GetComponent<RectTransform>().localPosition;
        Vector2 goDelta = go.GetComponent<RectTransform>().sizeDelta;
        Vector2 goDeltaChange;

        goDeltaChange = go.GetComponent<RectTransform>().sizeDelta = new Vector2(goDelta.x * 2, goDelta.y);


        go.GetComponent<RectTransform>().localPosition = new Vector3((goDeltaChange.x - wid) / 2, goPos.y, goPos.z);

        /*    transform.position = new Vector3(1.5f, transform.position.y, transform.position.z);*/
        Debug.Log(goPos.y);
        Debug.Log(go.GetComponent<RectTransform>().sizeDelta.y);

    }
}
