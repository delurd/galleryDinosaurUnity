using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using DG.Tweening;

public class splashScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(eksekusi());
    }

    IEnumerator eksekusi()
    {
        yield return new WaitForSeconds(0.2f);
        transform.GetComponent<Image>().DOFade(0f, 1f);
        yield return new WaitForSeconds(1f);

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
