using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class face : MonoBehaviour
{

    // 画像を格納する配列
    public Sprite[] images;

    // 対象のゲームオブジェクト名
    public string targetObjectName;

    // 現在の画像インデックス
    private int currentIndex = 0;

    // SpriteRendererを保持
    private SpriteRenderer targetSpriteRenderer;

    // 複数のAnimatorを設定
    public List<Animator> animators;


    // アニメーションのTrigger名
    public string animationTrigger;



    void Start()
    {
        // 対象のゲームオブジェクトを名前で検索
        GameObject targetObject = GameObject.Find(targetObjectName);

        if (targetObject != null)
        {
            targetSpriteRenderer = targetObject.GetComponent<SpriteRenderer>();

            if (targetSpriteRenderer == null)
            {
                Debug.LogError($"{targetObjectName} に SpriteRenderer がアタッチされていません。");
            }
            else if (images.Length > 0)
            {
                // 最初の画像を設定
                targetSpriteRenderer.sprite = images[currentIndex];
            }
        }
        else
        {
            Debug.LogError($"ゲームオブジェクト '{targetObjectName}' が見つかりません。");
        }
    }

    // 画像を切り替えるメソッド
    public void SwitchImage()
    {
        if (targetSpriteRenderer == null || images.Length == 0) return;

        // 次の画像に切り替え
        currentIndex = (currentIndex + 1) % images.Length;

        // SpriteRendererにスプライトを設定
        targetSpriteRenderer.sprite = images[currentIndex];

        // アニメーションを再生
        PlayAnimations();
    }

    // 全てのAnimatorでアニメーションを再生するメソッド
    private void PlayAnimations()
    {
        if (animators.Count == 0)
        {
            Debug.LogWarning("Animatorリストが空です。");
            return;
        }

        foreach (Animator animator in animators)
        {
            if (animator != null && !string.IsNullOrEmpty(animationTrigger))
            {
                // Triggerをリセットしてから設定
                animator.ResetTrigger(animationTrigger);
                animator.SetTrigger(animationTrigger);
            }
            else
            {
                Debug.LogWarning("AnimatorまたはTrigger名が設定されていません。");
            }
        }

    }
}