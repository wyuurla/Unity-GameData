using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataTest_Start : MonoBehaviour
{
    void Update()
    {
        GameDataManager.Instance.UpdateLogic();
    }
}
