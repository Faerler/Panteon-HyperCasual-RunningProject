using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    //Oyun içerisinde basılacak butonlara verilen fonksiyonlar bu script içerisinde tutulmaktadır.

    public void PlayGame()  //Scene Manager kullanılarak oyunun oynandığı sahneye yönlendirme yapılıyor.
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame() //Oyundan çıkma butonunun kullanılması durumunda uygulamanın kapatılması sağlanıyor.
    {
        Application.Quit();
    }

    public void FinishGame()    //Duvara çizim işleminin yapılmasının ardından "FINISH" butonuna basılması durumunda oyunun bitiş ekranına yönlendirme yapılıyor.
    {
        SceneManager.LoadScene(2);
    }

    public void MainMenu() //Kullanıcının oyunu bir daha oynamak istemesi durumu için kullanıcı ana ekrana yönlendiriliyor.
    {
        SceneManager.LoadScene(0);
    }
}
