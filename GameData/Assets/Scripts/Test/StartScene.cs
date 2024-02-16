using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    void Update()
    {
        GameDataManager.Instance.UpdateLogic();
    }
}
