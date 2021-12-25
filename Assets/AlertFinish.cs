using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertFinish : MonoBehaviour
{
    closeKuis closekuis;
    kuisPanel panelKuis;
    detailDino detaildino;
    closedinoDetail finishandclose;
    public cardDino carddino;
    public Sprite trophy;
    // Start is called before the first frame update
    void Start()
    {
        /*detaildino = FindObjectOfType<detailDino>();*/
        panelKuis = FindObjectOfType<kuisPanel>();
        closekuis = FindObjectOfType<closeKuis>();
        transform.GetChild(0).GetChild(1).GetComponent<Button>().onClick.AddListener(delegate () { finish(); });
    }

    void finish()
    {
        panelKuis.answer = 2;
        panelKuis.submitPilihan = false;
        panelKuis.closeAllKuis();
        /*closekuis.closeDinoKuis();*/
        /*detaildino.hide();*/
        gameObject.SetActive(false);
    }

    public void show(int kuisNumber)
    {
        gameObject.SetActive(true);

        if (kuisNumber + 1 >= carddino.allCard.Length)
        {
            transform.GetChild(0).GetChild(4).GetComponent<Text>().text = "Kamu berhasil menyelesaikan seluruh kuis";
            transform.GetChild(0).GetChild(2).GetComponent<Image>().sprite = trophy;

        }
        else
        {
            transform.GetChild(0).GetChild(4).GetComponent<Text>().text = "Kamu berhasil menyelesaikan kuis dan " + carddino.allCard[kuisNumber + 1].Title + " sudah dapat kamu pelajari";
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
