using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{

    [SerializeField] PlayerManager playerManager;
    public float distance;

    List<Vector3> linePoints;
    float timer;
    public float timerDelay;

    GameObject newLine;
    LineRenderer drawLine;
    public float lineWidth;

    public Vector3 maxBoundries;
    public Vector3 minBoundries;

    //Start içerisinde atamalar yapılmakta ve ekran oranına göre verilen uzaklık değeri üzerinde değişiklik yapılmaktadır.
    void Start()
    {
        linePoints = new List<Vector3>();
        timer = timerDelay;
        distance+=PlayerManager.raitoChange;
    }

    
    void Update()
    {
        if((playerManager.levelState==PlayerManager.LevelState.Finished) && (playerManager.playerState==PlayerManager.PlayerState.Stop) ){

            //Ekrana basılıması durumunda alınan kordinat verisi LineRenderer olarak listeye atılmakta ve renk verisi, çizgi inceliği gibi özellikleri atanmaktadır.
            if(Input.GetMouseButtonDown(0)){
                newLine = new GameObject();
                drawLine = newLine.AddComponent<LineRenderer>();
                drawLine.material= new Material(Shader.Find("Sprites/Default"));
                drawLine.startWidth = lineWidth;
                drawLine.endWidth = lineWidth;
                drawLine.startColor = Color.red;
                drawLine.endColor=Color.red;
            }

            if(Input.GetMouseButton(0)){ //Mouse tuşuna basılırken alınan kordinata göre eleme yapılmaktadır bu şekilde oyuncu duvarın dış tarafını boyayamamaktadır.
                Debug.DrawRay(Camera.main.ScreenToWorldPoint(Input.mousePosition), GetMousePosition(), Color.red);
                timer -= Time.deltaTime;
                if(timer <= 0){
                    if((GetMousePosition().x >= minBoundries.x && GetMousePosition().x<=maxBoundries.x) && (GetMousePosition().y >= minBoundries.y && GetMousePosition().y<=maxBoundries.y)){
                    
                    linePoints.Add(GetMousePosition());
                    drawLine.positionCount = linePoints.Count;
                    drawLine.SetPositions(linePoints.ToArray());
                    }


                }
            }

            //Mouse tuşuna basılmasının kesilmesi durumunda kordinatların girilmekte olduğu liste silinmektedir.
            if(Input.GetMouseButtonUp(0)){
                linePoints.Clear();
            }
        }

    }

    //Bu fonksiyon sayesinde ekrandaki mouse kordinat verisi alınmakta ve Vector3 verisine dönüştürülmektedir.
    Vector3 GetMousePosition(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return ray.origin + ray.direction * distance;
    }
}
