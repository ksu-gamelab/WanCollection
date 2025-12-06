using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSelect : MonoBehaviour
{
    //public string nextSceneName = "NextScene";   // 遷移先の名前
    public float transitionDelay = 0.15f;         // 音やアニメの長さ

    private AudioSource audioSource;
    private Animator animator;

    [SerializeField] private string sceneName; // ← Inspector で入力できる！




    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    public void LoadScene()
    {
        StartCoroutine(PlayAndTransition());
    }


    private System.Collections.IEnumerator PlayAndTransition()
    {
        // 音を鳴らす
        if (audioSource != null)
            audioSource.Play();

        // アニメーション再生（"Pressed" は Animator のトリガー名）
        if (animator != null)
            animator.SetTrigger("Click");

        // 音やアニメーションが終わるまで待つ
        yield return new WaitForSeconds(transitionDelay);

        // シーン遷移
        SceneManager.LoadScene(sceneName);
    }
}
