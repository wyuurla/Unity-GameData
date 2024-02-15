using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCode_Main : MonoBehaviour
{
    void Update()
    {
        GameDataManager.Instance.UpdateLogic();
    }
}
