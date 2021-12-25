using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AlertCorrect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetChild(0).GetComponent<Button>().onClick.AddListener(delegate () { correct(); });
    }

    void correct()
    {
        gameObject.SetActive(false);
    }

    public void tampil()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
