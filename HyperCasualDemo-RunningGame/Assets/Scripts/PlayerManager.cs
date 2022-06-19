using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    /*PlayerManager içerisinde oyun içerisinde farklı dosyalarda kullanılacak olan veriler tutulmaktadır. Örnek vermek gerekirse oyuncunun hareket edip
    etmeme durumunda göre oyun içerisinde durumlar değişebilmektedir. Bu tutulacak veriler playermanager içerisinde tutulmaktadır.*/


    public PlayerState playerState;

    public LevelState levelState;

    public static int Ranking;

    public static float raitoChange;

    public enum PlayerState{
        Stop,
        Move
    }

    public enum LevelState{
        NotFinished,
        Finished
    }
}
