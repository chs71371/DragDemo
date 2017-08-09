using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    /// <summary>
    /// 单例，让其他脚本能够访问管理器的数据，调用管理器的函数
    /// </summary>
    public static LevelManager Instance;

    /// <summary>
    /// 当前的关卡信息
    /// </summary>
    public LevelInfo curLevelInfo;

    /// <summary>
    /// 游戏的关卡列表
    /// </summary>
    public List<GameObject> levelList = new List<GameObject>();

    private int currentLevelId = 0;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartLevel();
    }


    public void StartLevel()
    {
        if (curLevelInfo != null)
        {
            Destroy(curLevelInfo.gameObject);    
        }

        if (currentLevelId >= levelList.Count)
        {
            return;
        }

 
        var levelUI=  GameObject.Instantiate(levelList[currentLevelId]);
 
        curLevelInfo = levelUI.GetComponent<LevelInfo>();

        currentLevelId++;
    }

 
    void OnDestory()
    {
        Instance = null;
    }
 
}
