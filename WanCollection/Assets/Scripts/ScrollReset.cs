using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollReset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteKey("ScrollPos");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
