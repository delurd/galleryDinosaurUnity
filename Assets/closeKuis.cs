using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class closeKuis : MonoBehaviour
{

    public KuisDino dinoKuis;
    submitPilihan submitpilihan;
    // Start is called before the first frame update
    void Start()
    {

        gameObject.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            closeDinoKuis();
        });
    }

    public void closeDinoKuis()
    {
        submitpilihan = FindObjectOfType<submitPilihan>();

        dinoKuis.gameObject.SetActive(false);
        submitpilihan.removeActive();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
