using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public static class ButtonExtension
{
    public static void AddEventListener<T> (this Button button, T param, Action<T> OnClick)
    {
        button.onClick.AddListener(delegate ()
        {
            OnClick(param);
        });
    }
}

public class cardDino : MonoBehaviour
{
    public detailDino DetailDino;
    public detailCard DetailCard;
    public dino3d Dino3d;
    public panelActive PanelHome;
    public AlertLock alertlock;
    public GameObject planeBg;

    public enum colorEnum
    {
        Red, Blue, Green
    }
    

    [Serializable]
    public struct cardItem
    {
        public bool unlock;
        int id;
        public string Title;
        public Sprite Image;

        public colorEnum color;
    }

    [SerializeField] public cardItem[] allCard;

    

    // Start is called before the first frame update
    void Start()
    {
        GameObject buttonTemplate = transform.GetChild(0).gameObject;
        GameObject GO = gameObject;
        GameObject dCard;

        int jumCard = allCard.Length;

        //PlayerPrefs.SetInt("cardUnlocked", 4);
        // PlayerPrefs.GetInt("cardUnlocked", 1); //inisialisai pertama untuk penyimpanan data carddino unlock

        for (int i = 0; i < jumCard; i++)
        {
            dCard = Instantiate(buttonTemplate, transform); /*Menduplikan card*/
            dCard.transform.GetChild(3).GetComponent<Text>().text = allCard[i].Title;
            dCard.transform.GetChild(3).GetComponent<RectTransform>();
            dCard.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = allCard[i].Image;

            setColor(i, dCard);

            /*Ketika card DiKlik*/
            dCard.GetComponent<Button>().AddEventListener(i, ItemClicked);
        }


        float wid = GO.GetComponent<RectTransform>().rect.width;
        Vector3 goPos = GO.GetComponent<RectTransform>().localPosition;
        Vector2 goDelta = GO.GetComponent<RectTransform>().sizeDelta;
        Vector2 goDeltaChange;

        /*Merubah ukuran dan posisi dari Content*/
        /*        goDeltaChange = GO.GetComponent<RectTransform>().sizeDelta = new Vector2(goDelta.x * jumCard - (jumCard*17+1), goDelta.y);*/
        //Card Width = 286.62  v
        /*goDeltaChange = GO.GetComponent<RectTransform>().sizeDelta = new Vector2(goDelta.x + ((goDelta.x-25)*(jumCard-1)+(jumCard*2)), goDelta.y);*/
        goDeltaChange = GO.GetComponent<RectTransform>().sizeDelta = new Vector2(((250+27)*(jumCard))+25, goDelta.y);
       /* GO.GetComponent<RectTransform>().localPosition = new Vector3((goDeltaChange.x - wid) / 2, goPos.y, goPos.z);*/ 
        GO.GetComponent<RectTransform>().localPosition = new Vector3((goDeltaChange.x) / 2, goPos.y, goPos.z);

        /*Menghapus card Asli sesudah diduplikasi*/
        Destroy(buttonTemplate);

        Debug.Log("cardDino");

        setUnlock();

    }

    void ItemClicked(int itemIndex)
    {
        
        Debug.Log(allCard[itemIndex].Title + " Clicked");

        if (allCard[itemIndex].unlock)
        {
            setMaterialColor(itemIndex);
            DetailCard.transform.GetChild(itemIndex).GetComponent<detailDino>().show();
            Dino3d.transform.GetChild(itemIndex).gameObject.SetActive(true);
            PanelHome.hide();
        }
        else
        {
            Debug.Log("Card Locked");
            alertlock.show(allCard[itemIndex-1].Title);
        }
    }

    void setMaterialColor(int index)
    {
        planeBg.gameObject.SetActive(true);
        if (allCard[index].color == colorEnum.Red)
        {
            planeBg.GetComponent<Renderer>().material.SetColor("_Color", new Color32(255, 89, 85, 255));
        }
        if (allCard[index].color == colorEnum.Green)
        {
            planeBg.GetComponent<Renderer>().material.SetColor("_Color", new Color32(85, 255, 174, 255));
        }
        if (allCard[index].color == colorEnum.Blue)
        {
            planeBg.GetComponent<Renderer>().material.SetColor("_Color", new Color32(77, 161, 207, 255));
        }
    }

    public void setUnlock()
    {
        //Menginputkan nilai true pada variabel Unlock
        for (int j = 0; j <= PlayerPrefs.GetInt("cardUnlocked"); j++)
        {
            allCard[j].unlock = true;

            
        }
        Debug.Log("card " + PlayerPrefs.GetInt("cardUnlocked") + " unlock");
    }


    void setColor(int i, GameObject dCard)
    {
        if (allCard[i].color == colorEnum.Red)
        {
            dCard.transform.GetComponent<Image>().color = new Color32(255, 201, 150, 255);
            dCard.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color32(204, 57, 57, 255);
        }
        if (allCard[i].color == colorEnum.Blue)
        {
            dCard.transform.GetComponent<Image>().color = new Color32(150, 221, 255, 255);
            dCard.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color32(74, 51, 140, 255);
            
        }
        if (allCard[i].color == colorEnum.Green)
        {
            dCard.transform.GetComponent<Image>().color = new Color32(131, 250, 192, 255);
            dCard.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color32(34, 113, 97, 255);

        }
    }



    void Update()
    {

        if (PlayerPrefs.GetInt("cardUnlocked") >= allCard.Length)
        {
            Debug.Log("Semua Kuis Selesai");
            PlayerPrefs.SetInt("cardUnlocked", allCard.Length - 1);
        }

        for (int i = 0; i <= PlayerPrefs.GetInt("cardUnlocked"); i++)
        {
            if (allCard[i].unlock)
            {
                transform.GetChild(i).GetChild(4).gameObject.SetActive(false);
            }

        }
    }
}
