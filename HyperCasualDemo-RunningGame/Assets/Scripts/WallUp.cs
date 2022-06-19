using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallUp : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;

    public Animator animator;

    //Animator sayesinde oyuncunun seviyeyi tamamlaması durumunda duvar yukarı kaldırılmaktadır.
    void Update()
    {
        if(playerManager.levelState == PlayerManager.LevelState.Finished){
            animator.SetBool("wallUp", true);
        }
    }
}
