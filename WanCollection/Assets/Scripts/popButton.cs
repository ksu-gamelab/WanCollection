using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popButton : MonoBehaviour
{
    [SerializeField] private GameObject[] targetImages; // ← 複数登録OK！
    private bool isShown = false;

    public void ShowImages()
    {
        // 全部表示
        foreach (var img in targetImages)
        {
            img.SetActive(true);
        }
        isShown = true;
    }

    private void Update()
    {
        // 表示中 & タップで非表示
        if (isShown && Input.GetMouseButtonDown(0))
        {
            foreach (var img in targetImages)
            {
                img.SetActive(false);
            }
            isShown = false;
        }
    }
}
