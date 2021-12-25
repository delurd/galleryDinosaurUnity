using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertLock : MonoBehaviour
{

    public void show(string dino)
    {
        gameObject.SetActive(true);
        transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Selesaikan kuis " + dino + " untuk membuka !";
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetChild(1).GetComponent<Button>().onClick.AddListener(delegate () { close(); });
    }

    void close()
    {
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
