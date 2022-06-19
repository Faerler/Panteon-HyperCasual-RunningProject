using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OpponentMovement : MonoBehaviour
{

    private NavMeshAgent agent;

    private Rigidbody rb;

    public Transform target;

    public Animator animator;

    public float rightSpeed;

    public Vector3 returnPoint;


    private bool right=false;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }

    //Diğer oyuncuların hareketleri verilen navmesh agent sayesinde gerçekleşmektedir. Navmesh agent'lara özel targetler verilemkte ve bu oyuncular hedeflerine en yakın olan yolu hesaplarlar.
    void Update()
    {

        agent.SetDestination(target.position);
        if(right){
            rb.AddForce(Vector3.right*rightSpeed);
            if(transform.position.z > 160 || transform.position==returnPoint){
                right=false;
            }
        }

    }

    //Yapay zekalar belli alanlara geçemeleri durumunda üzerlerinde uygulanacak olan etkiler ve başlangıca dönmeleri burada gerçekleşmektedir.
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("RotatingPlatform")){
            right=true;
        }
        if(other.gameObject.CompareTag("Ground")){
            right=false;
        }
        if(other.gameObject.CompareTag("Obstacle")){
            transform.position = new Vector3(returnPoint.x, returnPoint.y, returnPoint.z);
            right=false;
        }
        if(other.gameObject.CompareTag("FallEdge")){
            transform.position = new Vector3(returnPoint.x, returnPoint.y, returnPoint.z);
            right=false;
        }
        if(other.gameObject.CompareTag("Target")){
            agent.speed=0;
            rb.constraints = RigidbodyConstraints.FreezePosition;
            animator.SetBool("hasWon", true);
        }

    }
}
