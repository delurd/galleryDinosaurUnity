using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class closedinoDetail : MonoBehaviour
{
    // Start is called before the first frame update
    
    public detailDino DetailDino;
    public panelActive PanelHome;
    public dino3d Dino3d;
    public GameObject bgPlaneRed2;

    void Start()
    {
        close();
    }

    public void close()
    {
        GameObject go = gameObject;
        go.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            aksiClose();
        });
    }

    public void aksiClose()
    {
        PanelHome.show();
        DetailDino.hide();

        for (int i = 0; i < Dino3d.transform.childCount; i++)
        {
            Dino3d.transform.GetChild(i).gameObject.SetActive(false);
            bgPlaneRed2.gameObject.SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
