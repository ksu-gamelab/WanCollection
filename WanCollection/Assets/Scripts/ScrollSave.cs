using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollSave : MonoBehaviour
{
    public ScrollRect scrollRect;
    private const string SaveKey = "ScrollPos";

    void Start()
    {
        // •Û‘¶‚µ‚Ä‚ ‚ê‚Î•œŒ³
        if (PlayerPrefs.HasKey(SaveKey))
        {
            scrollRect.verticalNormalizedPosition = PlayerPrefs.GetFloat(SaveKey);
        }
    }

    void OnDestroy()
    {
        // ƒV[ƒ“ˆÚ“®’¼‘O‚É•Û‘¶‚³‚ê‚é
        PlayerPrefs.SetFloat(SaveKey, scrollRect.verticalNormalizedPosition);
    }
}
