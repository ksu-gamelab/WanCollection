using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    float scenetime = 0;
    bool flag;
    public void change_button() //change_button‚Æ‚¢‚¤–¼‘O‚É‚µ‚Ü‚·
    {
        flag = true;
        //SceneManager.LoadScene("Select");//second‚ğŒÄ‚Ño‚µ‚Ü‚·      
    }

        // Start is called before the first frame update
        void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (flag == true) {
            scenetime += Time.deltaTime;
            if(scenetime >= 0.1f)
                SceneManager.LoadScene("Select");//second‚ğŒÄ‚Ño‚µ‚Ü‚·      

        }
    }
}
