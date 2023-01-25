using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour {

    public float Tension;
    private bool _pressed;
    public Transform RopeTransform;
    public Vector3 RopeNearLocalPosition;
    public Vector3 RopeFarLocalPosition;
     public AnimationCurve RopeReturnAnimation;
    public float ReturnTime;
    public Arrow CurrentArrow=null;
    public float ArrowSpeed;
    public AudioSource ArrowAudio;
    public AudioSource BowAudio;


    private int ArrowIndex = 0;
    private List<Arrow> ArrowsPool=new List<Arrow>();
    public GameObject ar;

    void Start () {
       RopeNearLocalPosition = RopeTransform.localPosition;
      /* for(int i=0 ; i<20 ; i++)
        {
            ArrowsPool.Add(Instantiate(ar).GetComponent<Arrow>());      
        }*/
      
    
    }


	// Update is called once per frame
	void Update () {
        float screenPosition_x = Input.mousePosition.x;
        float screenPosition_y = Input.mousePosition.y;
      

        if(screenPosition_x > 90*Screen.width/100 && screenPosition_y<Screen.width/10)
         return;

        if(!GameManager.Instance.clickArrow)
         return;
       
        if (Input.GetMouseButtonDown(0)) {
            _pressed=true;
           // ArrowsPool.Add(Instantiate(ar).GetComponent<Arrow>());    
            // ArrowIndex++;
           // if (ArrowIndex >= ArrowsPool.Count) {
            //    ArrowIndex = 0;
            //}
            //CurrentArrow = ArrowsPool[ArrowIndex];
            if(CurrentArrow ==null)
              CurrentArrow=Instantiate(ar).GetComponent<Arrow>();

            CurrentArrow.SetToRope(RopeTransform , transform);

            BowAudio.pitch=Random.Range(0.8f , 1.2f);
            BowAudio.Play();
        }
        if (Input.GetMouseButtonUp(0)) {
            _pressed=false;
           
            StartCoroutine(RopeReturn());
            CurrentArrow.Shot(ArrowSpeed * Tension);
            Tension=0;

            BowAudio.Stop();

            ArrowAudio.pitch=Random.Range(0.8f , 1.2f);
            ArrowAudio.Play();
             CurrentArrow=null;
        }

        if(_pressed)
        {
            if(Tension<1f)
            {
                Tension += Time.deltaTime;
            }
            RopeTransform.localPosition=Vector3.Lerp(RopeNearLocalPosition , RopeFarLocalPosition , Tension);
        }
       
    }

   IEnumerator RopeReturn() {
        Vector3 startLocalPosition = RopeTransform.localPosition;
        for (float f = 0; f < 1f; f += Time.deltaTime / ReturnTime) {
            RopeTransform.localPosition = Vector3.LerpUnclamped(startLocalPosition, RopeNearLocalPosition, RopeReturnAnimation.Evaluate(f));
            yield return null;
        }
        RopeTransform.localPosition = RopeNearLocalPosition;
    }

}
