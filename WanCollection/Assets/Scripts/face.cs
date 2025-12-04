using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.U2D;   // SpriteAtlas に必要

public class FaceChanger : MonoBehaviour
{
    [Header("アトラス（表情差分が入ったもの）")]
    public SpriteAtlas faceAtlas;

    [Header("表情を表示するUI Image")]
    public SpriteTarget faceImage;

    [Header("表情のキー（0,1,2,3 など）")]
    public string[] faceKeys;

    private int currentIndex = 0;


    // 複数のAnimatorを設定
    public List<Animator> animators;

    // アニメーションのTrigger名
    public string animationTrigger;

    void Start()
    {

        var dummy = faceAtlas.spriteCount;

        // アトラスを明示的に保持
        DontDestroyOnLoad(faceAtlas);

        // または単に参照して Unity に「使ってるよ」と知らせる
        var _ = faceAtlas.spriteCount;




        // faceKeys に何もなければ自動生成 (0,1,2,3)
        if (faceKeys == null || faceKeys.Length == 0)
        {
            faceKeys = new string[] { "0" };
        }

        // 最初に自動で 0 をセット（または最初のキー）
        SetFace(0);
    }


    /// <summary>
    /// 指定 index の表情をセットする
    /// </summary>
    public void SetFace(int index)
    {
        // 範囲チェック
        if (faceKeys == null || faceKeys.Length == 0)
        {
            Debug.LogError("faceKeys が設定されていません。");
            return;
        }

        if (faceAtlas == null)
        {
            Debug.LogError("SpriteAtlas が設定されていません。");
            return;
        }

        if (index < 0 || index >= faceKeys.Length)
        {
            Debug.LogError("SetFace: index が範囲外");
            return;
        }

        // スプライト取得
        Sprite sp = faceAtlas.GetSprite(faceKeys[index]);

        if (sp == null)
        {
            Debug.LogError("アトラスから取得できません: " + faceKeys[index]);
            return;
        }

        // SpriteTarget にセット（ここが重要）
        faceImage.SetSprite(sp);

        currentIndex = index;
    }

    /// <summary>
    /// 次の表情へ切り替える（ループ）
    /// </summary>
    public void NextFace()
    {
        if (faceKeys.Length == 0) return;

        currentIndex = (currentIndex + 1) % faceKeys.Length;
        SetFace(currentIndex);

        // アニメーションを再生
        PlayAnimation();
    }

    // アニメーションを再生するメソッド
    private void PlayAnimation()
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