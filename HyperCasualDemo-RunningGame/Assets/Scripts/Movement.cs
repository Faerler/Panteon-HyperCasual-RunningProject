using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;

    public float movementSpeed;
    public float controlSpeed;
    public float backForce;
    public float fallSpeed;

    private bool right=false;
    private bool force = false;
    private bool fall = false;

    public bool isTouching;
    public Animator animator;
    public GameObject finishButton;

    float touchPosX;

    Vector3 direction;
    public Vector3 returnPoint;

    //Oyun bitirme butonu oyun devam ederken oyuncuya gösterilmemektedir.
    void Start()
    {
        finishButton.SetActive(false);
    }

    
    void Update()
    {
        GetInput();
    }

    //Oyuncunun ekrana basıp basmadığı verisi alınmaktadır.
    void GetInput(){
        if(Input.GetMouseButton(0)){
            isTouching=true;
        }
        else{
            isTouching=false;
        }
    }

    /*Oyuncunun hareket, düşme, sağa çekilme ve geri itilem durumları burada yapılmaktadır.
     Oyuncunun kordinatları devamlı olarak değiştirildiği için transform ile işlem gerçekleştirilmektedir.*/
    private void FixedUpdate() {
        if(playerManager.playerState == PlayerManager.PlayerState.Move && (!force)){
            transform.position += Vector3.forward * movementSpeed * Time.fixedDeltaTime;
        }

        if(isTouching && playerManager.levelState == PlayerManager.LevelState.NotFinished){
            if(touchPosX >12){
                touchPosX-=0.5f;
            }
            else if(touchPosX<-12){
                touchPosX+=0.5f;
            }

            touchPosX += Input.GetAxis("Mouse X") * controlSpeed * Time.deltaTime;
        }

        if(right){
            if(transform.position.z>166){
                right=false;
            }
            touchPosX+=0.15f;
        }
        if(force){
            if(transform.position.z<=67){
                force=false;
            }
            transform.position -= Vector3.forward * Time.fixedDeltaTime * backForce;
        }

        if(fall){
            touchPosX+=0.30f;
            transform.position += Vector3.down * Time.fixedDeltaTime * fallSpeed;

        }


        transform.position = new Vector3(touchPosX, transform.position.y, transform.position.z);
    }

    //Oyuncunun belli alanlara girmesi durumunda yaşanacak değişken değişimleri burada gerçekleştirilmektedir.
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("FinishLine")){
            playerManager.levelState = PlayerManager.LevelState.Finished;
        }
        if(other.gameObject.CompareTag("FinishPlace")){
            animator.SetBool("hasWon", true);
            playerManager.playerState = PlayerManager.PlayerState.Stop;
            finishButton.SetActive(true);
        }
        if(other.gameObject.CompareTag("Obstacle")){
            force=false;
            right=false;
            fall=false;
            animator.SetBool("hasKnockedDown", true);
            playerManager.playerState = PlayerManager.PlayerState.Stop;
            StartCoroutine(WaitForFewSeconds(3));
        }
        if(other.gameObject.CompareTag("RotatingObstacle") && playerManager.playerState!=PlayerManager.PlayerState.Stop){
            force=true;
        }
        if(other.gameObject.CompareTag("RotatingPlatform")){
            right=true;
        }
        if(other.gameObject.CompareTag("FallEdge")){
            fall=true;
            animator.SetBool("isFalling", true);
            StartCoroutine(WaitForFewSeconds(2));
        }
    }

    //Oyuncunun belli bir alanda farklı bir animasyona geçmesi durumunda oyuncuyu belli bir süre bekletebilmek amaçlanmaktadır
    IEnumerator WaitForFewSeconds(int second)
    {
        yield return new WaitForSeconds(second);
        touchPosX= returnPoint.x;
        transform.position = new Vector3(returnPoint.x, returnPoint.y, returnPoint.z);
        playerManager.playerState = PlayerManager.PlayerState.Move;
        animator.SetBool("hasKnockedDown", false);
        animator.SetBool("isFalling", false);
        right=false;
        fall=false;
    }

}
