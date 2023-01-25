using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool clickArrow=false;
    public Button btn_touch;
    public Sprite[] Image;

    void Awake()
    {
        if(Instance==null)
          Instance=this;
    }
   public void click_arrow()
   {
       clickArrow = !clickArrow;
       if(clickArrow)
         btn_touch.image.sprite = Image[1];
        else
         btn_touch.image.sprite = Image[0];
   }
}
