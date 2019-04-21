using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class STF 
{

    private static UIManager _uiManager;

    public static UIManager uiManager
    {
        get
        {
            return _uiManager ??
                (GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>());
        }
    }

    public static void NullReferences()
    {
        _uiManager = null;
    }


}
