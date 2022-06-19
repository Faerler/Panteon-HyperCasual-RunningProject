using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{

    [SerializeField] PlayerManager playerManager;
    public Text rankText;

    public GameObject Player;
    public GameObject Opponent1;
    public GameObject Opponent2;
    public GameObject Opponent3;
    public GameObject Opponent4;
    public GameObject Opponent5;
    public GameObject Opponent6;
    public GameObject Opponent7;
    public GameObject Opponent8;
    public GameObject Opponent9;
    public GameObject Opponent10;

    List<GameObject> players = new List<GameObject>();

    //Bu script içerisinde gameObject verilerini tutan bir liste içerisinde oyuncuların z kordinat verilerine göre yeniden düzenleme yapılmaktadır.
    //Yapılan bu düzenleme sayesinde ekranda oyuncunun canlı olarak kaçıncı sırada olduğu yazılabilmektedir.

    void Start()
    {
        players.Add(Player);
        players.Add(Opponent1);
        players.Add(Opponent2);
        players.Add(Opponent3);
        players.Add(Opponent4);
        players.Add(Opponent5);
        players.Add(Opponent6);
        players.Add(Opponent7);
        players.Add(Opponent8);
        players.Add(Opponent9);
        players.Add(Opponent10);
    }

    void Update()
    {
        if(Player.transform.position.z<245){
            players.Sort(SortFunc); // Sort fonksiyonu içerisinde aşağıda yazmış olduğum fonksiyonu kullanarak kullanıcılar arasında konumlarına göre listelendirme yapılıyor.
            int rank = players.FindIndex(x => x == Player) + 1;
            rankText.text = "" + rank + " / 11";    //Ekranda yer alan boş text objesine yazı gönderiliyor.
            PlayerManager.Ranking = rank;
        }
        
    }

        private int SortFunc(GameObject first, GameObject second) // Elimizde olan oyuncu listesi içerisinde oyuncuların z konumuna göre liste içerisinde ileri ya da geri gideceğini hesaplanayan bir fonksiyon oluşturulmuştur.
    {
        if (first.transform.position.z < second.transform.position.z)
        {
            return 1;
        }
        else if (first.transform.position.z > second.transform.position.z)
        {
            return -1;
        }

        return 0;
    }
}
