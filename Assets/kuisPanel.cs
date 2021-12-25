using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class kuisPanel : MonoBehaviour
{
    public bool submitPilihan; // penetapan warna tombol jawab

    public int answer; //nilai untuk alertKuis
    public int currentSoal;
    cardDino carddino;


    [Serializable]
    public struct detailKuis
    {
        public string dino;
        public bool kuisSelesai;

        [Serializable]
        public struct kuis
        {
            public string soal;
            public string pilihan1;
            public string pilihan2;
            public string pilihan3;
            public string pilihan4;
            public int pilihanBenar;
        }
        /*[SerializeField] public kuis[] GetKuis;*/
        [SerializeField] public List<kuis> GetKuis;


    }

    [SerializeField] detailKuis[] allKuis;

    // Start is called before the first frame update
    void Start()
    {
        carddino = FindObjectOfType<cardDino>();

        //inisialisai pertama untuk penyimpanan data kuis unlock
        /*setKuisDone();*/

        answer = 2; 

        generateKuis();//Memulai pengisian setiap kuis 

    }

    void generateKuis()
    {
        GameObject goKuisDino = transform.GetChild(0).gameObject;
        GameObject kuisDino;

        //perulangan untuk kuis dinosaurus
        for (int i = 0; i < allKuis.Length; i++)
        {
            kuisDino = Instantiate(goKuisDino, transform);

            GameObject goItemKuis = kuisDino.transform.GetChild(0).GetChild(1).gameObject;
            GameObject itemKuis;

            //menginisialisasi nilai random untuk kuis
            List<int> intRandom = new List<int>();
            for (int rand = 0; rand < allKuis[i].GetKuis.Count; rand++)
            {
                intRandom.Add(rand);
            }

            //perulangan untuk item kuis dinosaurus
            for (int j = 0; j < allKuis[i].GetKuis.Count; j++)
            {
                //merandom nilai
                currentSoal = UnityEngine.Random.Range(0, intRandom.Count);
                //random nilai terpilih
                int randomNilai = intRandom[currentSoal];

                itemKuis = Instantiate(goItemKuis, kuisDino.transform.GetChild(0).gameObject.transform);
                itemKuis.transform.GetChild(0).GetComponent<Text>().text = allKuis[i].GetKuis[randomNilai].soal;

                setPilihan(i, randomNilai, itemKuis);


                //menghapus nilai random terpilih
                intRandom.RemoveAt(currentSoal);
            }
            Destroy(goItemKuis);
        }
        Destroy(goKuisDino);
    }

    void setPilihan(int i, int j, GameObject itemKuis)
    {
        Transform itemkuisPilihan = itemKuis.transform.GetChild(1);
        //Mengisikan setiap pilihan
        itemkuisPilihan.GetChild(0).GetChild(0).GetComponent<Text>().text = allKuis[i].GetKuis[j].pilihan1;
        itemkuisPilihan.GetChild(1).GetChild(0).GetComponent<Text>().text = allKuis[i].GetKuis[j].pilihan2;
        itemkuisPilihan.GetChild(2).GetChild(0).GetComponent<Text>().text = allKuis[i].GetKuis[j].pilihan3;
        itemkuisPilihan.GetChild(3).GetChild(0).GetComponent<Text>().text = allKuis[i].GetKuis[j].pilihan4;

        //menetapkan kebenaran jawaban untuk setiap pilihan
        for(int k = 0; k < itemkuisPilihan.childCount; k++)
        {
            itemkuisPilihan.GetChild(k).GetComponent<pilihan>().jawaban = false;
            if(allKuis[i].GetKuis[j].pilihanBenar == k + 1)
            {
                itemkuisPilihan.GetChild(k).GetComponent<pilihan>().jawaban = true;
            }
        }
    }

    public void resetKuis()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        generateKuis();
    }

    public void aktifAllKuisItem()  //MengAktifkan semua item kuis
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            for(int j = 0; j < transform.GetChild(i).GetChild(0).childCount; j++)
            {
                transform.GetChild(i).GetChild(0).GetChild(j).gameObject.SetActive(true);
            }
        }
    }

    //menonAktifkan semua Kuis
    public void closeAllKuis()  
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }


    public void setKuisDone()  //Menginputkan nilai true pada kuisSelesai
    {
        for(int j = 0; j <= PlayerPrefs.GetInt("kuisDone"); j++)
        {
            allKuis[j].kuisSelesai = true;
        }
        PlayerPrefs.SetInt("cardUnlocked", PlayerPrefs.GetInt("kuisDone") + 1);
        carddino.setUnlock();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (PlayerPrefs.GetInt("cardUnlocked") >= carddino.allCard.Length)
        {
            Debug.Log("Semua Kuis Selesai");
            PlayerPrefs.SetInt("cardUnlocked", carddino.allCard.Length - 1);
        }*/
        /*if(PlayerPrefs.GetInt("kuisDone") >= allKuis.Length)
        {
            PlayerPrefs.SetInt("kuisDone", allKuis.Length-1);
        }*/
    }
}
