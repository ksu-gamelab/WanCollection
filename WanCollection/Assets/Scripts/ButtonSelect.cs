using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSelect : MonoBehaviour
{


    [SerializeField] private string sceneName; // © Inspector ‚Å“ü—Í‚Å‚«‚éI

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
