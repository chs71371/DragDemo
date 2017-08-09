using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; 


public class DragUI : MonoBehaviour, IDragHandler, IPointerUpHandler
{

    public Collider2D targetAren;

    private Vector3 initPos;

    private bool isPass;

    public void Start()
    {
        initPos = gameObject.transform.position;
    }
 
    public void OnDrag(PointerEventData eventData)
    {
        if (isPass)
        {
            return;
        }
        gameObject.transform.position = eventData.position;
    }
 
    private bool CheckIsEnterTargetAren(PointerEventData eventData)
    {
       var cols= Physics2D.OverlapCircleAll(gameObject.transform.position,1);
        
        foreach (var col in cols)
        {
            if (col == targetAren)
            {
                return true;
            }
        }
 
        return false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isPass)
        {
            return;
        }

        if (CheckIsEnterTargetAren(eventData))
        {
            isPass = true;
            gameObject.transform.position = targetAren.gameObject.transform.position;

            Invoke("PassLevel", 1.5f);
        }
        else
        {
            isPass = false;
            gameObject.transform.position=initPos;
        }

    }


    public void PassLevel()
    {
        LevelManager.Instance.curLevelInfo.mPassWindow.gameObject.SetActive(true);
        LevelManager.Instance.curLevelInfo.mPuzzleWindow.gameObject.SetActive(false);
    }


}
