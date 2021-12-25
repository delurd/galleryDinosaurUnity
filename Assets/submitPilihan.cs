using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class submitPilihan : MonoBehaviour
{
    kuisPanel kuispanel;
    public AlertCorrect alertcorrect;
    public AlertFinish alertfinish;
    public AlertWrong alertwrong;


    // Start is called before the first frame update
    void Start()
    {
        kuispanel = FindObjectOfType<kuisPanel>();
        Debug.Log("submit");
    }

    public void click()
    {
        
        if (kuispanel.answer == 1)
        {
            //menonaktifkan kuis ketika pilihan benar
            transform.parent.gameObject.SetActive(false);

            Debug.Log("Corect Answer");

            if (transform.parent.parent.GetChild(1).gameObject.activeSelf) //jika kuis terakhir masih aktif maka akan memanggil alert correct
            {
                alertcorrect.tampil();
            }
            else // jika kuis terakhir tidak aktif maka akan menampilkan alert finish
            {
                int kuisNumber = transform.parent.parent.parent.GetSiblingIndex();

                alertfinish.show(kuisNumber);

                //Menetapkan true ketika kuis selesai
                PlayerPrefs.SetInt("kuisDone", kuisNumber);
                Debug.Log("kuis " + PlayerPrefs.GetInt("kuisDone") + " selesai");
                kuispanel.setKuisDone();

                removeActive();

            }


        }
        if (kuispanel.answer == 0)
        {
            Debug.Log("Wrong Answer");
            alertwrong.show();
        }
        if (kuispanel.answer == 2)
        {
            Debug.Log("Submit Answer !");
        }

        removeActive();
        
        //merestart pilihan
        kuispanel.answer = 2;
    }


    public void removeActive()  //untuk mereset warna tombol pilihan
    {
        int sibling = transform.GetSiblingIndex();
    
        GameObject answerScript = transform.parent.GetChild(sibling - 1).gameObject;  //untuk mengakses panelPilihan
        for (int i = 0; i<answerScript.transform.childCount; i++)
        {
           answerScript.transform.GetChild(i).GetComponent<Image>().color = new Color32(245, 245, 245, 255);
        }

        kuispanel.submitPilihan = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (kuispanel.submitPilihan) // jika true warna tombol hijau
        {
            transform.GetComponent<Image>().color = new Color32(82, 182, 154, 255);
            transform.GetChild(0).GetComponent<Text>().color = new Color32(5, 113, 83, 255);
        }
        else //sebaliknya warna tombol grey
        {
            transform.GetComponent<Image>().color = new Color32(221, 221, 221, 255);
            transform.GetChild(0).GetComponent<Text>().color = new Color32(132, 132, 132, 255);
            removeActive();
        }
        
    }
}
