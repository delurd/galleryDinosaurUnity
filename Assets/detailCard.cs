using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;

/*static class ButtonExtension
{
    public static void AddEventListener<T>(this Button button, T param, Action<T> OnClick)
    {
        button.onClick.AddListener(delegate ()
        {
            OnClick(param);
        });
    }
}*/


public class detailCard : MonoBehaviour
{

    public kuisPanel PanelKuis;

    [Serializable]
    public struct detailItem
    {
        int id;
        public string Title;
        public string Desc;
        Sprite Image;

        [Serializable]
        public struct point
        {
            public string pointTitle;
            public string pointDesc;
            public Sprite icon;
        }
        [SerializeField] public point[] allPoint;


    }

    [SerializeField] detailItem[] allitem;



    // Start is called before the first frame update
    void Start()
    {
        GameObject detailTemplate = transform.GetChild(0).gameObject;
        GameObject dItem;

        int jumCard = allitem.Length;
        for (int i = 0; i < jumCard; i++)
        {
            int jumPoint = allitem[i].allPoint.Length;

            dItem = Instantiate(detailTemplate, transform);
            dItem.transform.GetChild(1).GetComponent<Text>().text = allitem[i].Title;
            dItem.transform.GetChild(2).GetComponent<Text>().text = allitem[i].Desc;

            dItem.transform.GetChild(4).GetChild(0).GetComponent<Button>().AddEventListener(i, ItemClicked);

            GameObject pointPoint = dItem.transform.GetChild(4).GetChild(1).GetChild(0).gameObject;
            GameObject pointPointParent = dItem.transform.GetChild(4).GetChild(1).gameObject;
            GameObject dPoint;

            for ( int j = 0; j < jumPoint; j++ )
            {
                dPoint = Instantiate(pointPoint, pointPointParent.transform);
                dPoint.transform.GetChild(0).GetComponent<Image>().sprite = allitem[i].allPoint[j].icon;
                dPoint.transform.GetChild(1).GetComponent<Text>().text = allitem[i].allPoint[j].pointTitle;
                dPoint.transform.GetChild(2).GetComponent<Text>().text = allitem[i].allPoint[j].pointDesc;                

            }
            Destroy(pointPoint);

        }




        Destroy(detailTemplate);
    }
    void ItemClicked(int itemIndex)
    {
        PanelKuis.aktifAllKuisItem();
        /*Debug.Log(itemIndex + " Clicked");*/
        PanelKuis.transform.GetChild(itemIndex).gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
