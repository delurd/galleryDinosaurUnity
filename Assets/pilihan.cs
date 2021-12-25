using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class pilihan : MonoBehaviour
{
    public bool jawaban = false;
    kuisPanel kuispanel;

    public void click()
    {
        clearAnswer();
        GetComponent<Image>().color = new Color32(176, 229, 214, 255);
        int SiblingIndex = transform.parent.GetSiblingIndex();

        //Merubah warna Tombol jawab 
        kuispanel.submitPilihan = true;
        

        if (jawaban)
        {
            kuispanel.answer = 1;  //jika benar
        }
        else
        {
            kuispanel.answer = 0;
        }

    }


    public void clearAnswer()
    {
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            transform.parent.GetChild(i).GetComponent<Image>().color = new Color32(245, 245, 245, 255);
        }
    }





    // Start is called before the first frame update
    void Start()
    {
        kuispanel = FindObjectOfType<kuisPanel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
