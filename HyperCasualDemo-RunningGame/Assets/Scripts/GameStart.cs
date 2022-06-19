using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{

    [SerializeField] PlayerManager playerManager;

    private Rigidbody rb;

    [SerializeField] bool isGround;
    
    //Oyunun başlaması amacıyla oyuncunun yere değmesi beklenmekte ve bu durumda oyun başlatılmaktadır.
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Ground")){
            Grounded();
        }
    }

    void Grounded(){
        isGround=true;
        playerManager.playerState=PlayerManager.PlayerState.Move;
        //rb.useGravity=false;
        rb.constraints = RigidbodyConstraints.FreezeAll;

        Destroy(this, 1);
    }
}
