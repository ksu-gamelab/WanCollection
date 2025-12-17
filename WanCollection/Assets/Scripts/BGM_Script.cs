using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM_Script : MonoBehaviour
{
    private static BGM_Script instance;

    public AudioSource bgm;
    bool started = false;


    private void Awake()
    {
        if (instance == null)
        {
            // このオブジェクトがシングルトンのインスタンスとして設定される
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // 既にインスタンスが存在する場合、このオブジェクトを破棄
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SceneManager.LoadScene("TitleScene");
    }

    void Update()
    {
        if (!started && Input.GetMouseButtonDown(0))
        {
            bgm.Play();
            started = true;
        }
    }
}
