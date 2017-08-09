using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelOver : MonoBehaviour
{
    void Start()
    {
        var btn = gameObject.GetComponent<Button>();

        btn.onClick.AddListener(OnLevelOver);
    }


    public void OnLevelOver()
    {
        LevelManager.Instance.StartLevel();
    }
}
