using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //Kameranın ekran oranlarına göre düzeni bu script içerisinde gerçekleşmektedir.

    [SerializeField] PlayerManager playerManager;
    [SerializeField] float smoothSpeed;
    [SerializeField] Vector3 offset;//Oyunun 1920x1080 oranına göre çalışması durumunda offset olarak alınan oran tam olarak kullanılacaktır.

    public Vector2 ReferenceResolution;//Asıl ayarlanmış olan ekran referansı yapılmaktadır.

    public Vector3 ZoomFactor;

    [HideInInspector]
    public Vector3 OriginPosition;

    public Transform target;//Oyuncuyu takip etmemiz için target olarak oyuncu verilmektedir.


    private void Start() {
         if (ReferenceResolution.y == 0 || ReferenceResolution.x == 0) // Belli bir referans oranı verildiğinden emin olunmaktadır.
                return;

            var refRatio = ReferenceResolution.x / ReferenceResolution.y; // Verilen referans oranlarına göre kameranın işlemlerinde kullanılacak bir oran elde edilmektedir.

            var ratio = (float)Screen.width / (float)Screen.height; 

            PlayerManager.raitoChange=offset.z; //Duvara çizimin yapılması için ekran büyüklüğüne göre verilen değişiklik oranı tutulmakta ve sonrasında LineDrawer scripti içerisinde kullanılmaktadır.

            offset = new Vector3(offset.x + (1f - refRatio / ratio) * ZoomFactor.x, offset.y + (1f - refRatio / ratio) * ZoomFactor.y, offset.z + (1f - refRatio / ratio) * ZoomFactor.z );
            //Normalde oyuncudan uzaklığı belirlemekte olan offset, farklı bir ratio içerisinde çalıştırılacak ise yapılan işlemler sayesinde offset oranı tekrar hesaplanmaktadır.

            PlayerManager.raitoChange-=offset.z;
    }

    private void LateUpdate() {
        if(playerManager.playerState == PlayerManager.PlayerState.Move){

           
            
            Vector3 desiredPos = target.position + offset; // Hesaplanmış olan offset oranına göre istenilen kordinat hesaplanmaktadır.
            Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);

            transform.position = new Vector3(transform.position.x, smoothedPos.y, smoothedPos.z);//Hesaplanan kordinata göre kamera yerleştirilmektedir.
        }
    }
}
