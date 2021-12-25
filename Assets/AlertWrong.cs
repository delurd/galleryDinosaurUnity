using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AlertWrong : MonoBehaviour
{
    closeKuis closekuis;
    kuisPanel panelKuis;
    submitPilihan submitpilihan;

    // Start is called before the first frame update
    void Start()
    {
        panelKuis = FindObjectOfType<kuisPanel>();
        submitpilihan = FindObjectOfType<submitPilihan>();

        closekuis = FindObjectOfType<closeKuis>();
        transform.GetChild(0).GetChild(2).GetComponent<Button>().onClick.AddListener(delegate () { tutupKuis(); });
        transform.GetChild(0).GetChild(3).GetComponent<Button>().onClick.AddListener(delegate () { closeAlert(); });

    }

    public void tutupKuis()
    {
        panelKuis.closeAllKuis();
       /* closekuis.closeDinoKuis();*/
        closeAlert();
        Debug.Log("Pelajari lagi");
    }

    void closeAlert()
    {
        gameObject.SetActive(false);

        //merubah warna tombol jawab ke grey
        panelKuis.submitPilihan = false;
    }

    public void show()
    {
        gameObject.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
