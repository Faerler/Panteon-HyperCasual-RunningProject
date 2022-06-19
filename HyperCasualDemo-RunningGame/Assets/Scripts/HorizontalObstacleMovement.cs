using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalObstacleMovement : MonoBehaviour
{
    public float speed;

    bool right = true;

    float PosX;

    Vector3 direction;

    //Diğer engeller için animasyon sistemi kullanılmakta ancak bu engel için özel kod yazılmıştır.
    //Bunun sebebi x yörüngesinde hareket edecek olan engelin hızının istenildiği gibi değişitirilebilir olnumasının istenmesidir.
    void Start()
    {
        PosX = transform.position.x;
    }

private void FixedUpdate() {
            if (this.right == true)
        {
            PosX += (+1) * speed * Time.deltaTime;
            if (transform.position.x >= 12)
            {
                this.right = false;
            }
        }
        else
        {
            PosX += (-1) * speed * Time.deltaTime;
            if (transform.position.x <= -12)
            {
                this.right = true;
            
            }
        }

        

        transform.position = new Vector3(PosX, transform.position.y, transform.position.z);
}
}
