using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalRank : MonoBehaviour
{
    public Text rankText;

    void Start()
    {
        //Final ekranı içerisinde oyuncunun kaçındı olduğu yazısı yazdırılmaktadır.
        rankText.text = "Your Rank : #" + PlayerManager.Ranking;
    }

}
