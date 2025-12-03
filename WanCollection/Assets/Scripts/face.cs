using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class face : MonoBehaviour
{
    [Header("Addressables アドレス")]
    public string[] addressables;  // 例: "characters/hiiro/face_00"


    // 画像を格納する配列
    public Sprite[] images;

    // 対象のゲームオブジェクト名
    public string targetObjectName;

    // 現在の画像インデックス
    private int currentIndex = 0;

    // SpriteRendererを保持
    private SpriteRenderer targetSpriteRenderer;
    private Image targetImage; // UI Image 用

    // 複数のAnimatorを設定
    public List<Animator> animators;


    // アニメーションのTrigger名
    public string animationTrigger;

    IEnumerator PreloadSprites()
    {
        for (int i = 0; i < addressables.Length; i++)
        {
            int index = i;
            var handle = Addressables.LoadAssetAsync<Sprite>(addressables[i]);
            yield return handle;

            if (handle.Status == AsyncOperationStatus.Succeeded)
                images[index] = handle.Result;
            else
                Debug.LogError($"[Face] 読み込み失敗: {addressables[index]}");
        }

        // 最初の画像をセット
        if (images.Length > 0)
        {
            if (targetSpriteRenderer != null) targetSpriteRenderer.sprite = images[0];
            if (targetImage != null) targetImage.sprite = images[0];
        }
    }

    void Start()
    {
        StartCoroutine(PreloadSprites());

        // 対象のゲームオブジェクトを名前で検索
        GameObject targetObject = GameObject.Find(targetObjectName);


        images = new Sprite[addressables.Length];
        LoadAllImages();

        if (targetObject == null)
        {
            Debug.LogError($"ゲームオブジェクト '{targetObjectName}' が見つかりません。");
            return;
        }

        // SpriteRenderer か Image を取得
        targetSpriteRenderer = targetObject.GetComponent<SpriteRenderer>();
        targetImage = targetObject.GetComponent<Image>();

        if (targetSpriteRenderer == null && targetImage == null)
        {
            Debug.LogError($"{targetObjectName} に SpriteRenderer も Image もアタッチされていません。");
        }

    }


    void LoadAllImages()
    {
        for (int i = 0; i < addressables.Length; i++)
        {
           

            int index = i;
            Addressables.LoadAssetAsync<Sprite>(addressables[i]).Completed += handle =>
            {
                if (handle.Status == AsyncOperationStatus.Succeeded)
                {
                    images[index] = handle.Result;

                    // 最初の画像を設定
                    if (index == 0 && targetSpriteRenderer != null)
                        targetSpriteRenderer.sprite = images[0];
                        targetImage.sprite = images[0];
                }
                else
                {
                    Debug.LogError($"[Face] 読み込み失敗: {addressables[index]}");
                }
            };
        }
    }


    // 画像を切り替えるメソッド
    public void SwitchImage()
    {
        if (images.Length == 0) return; // 配列が空なら何もしない

        currentIndex = (currentIndex + 1) % images.Length;

        if (targetSpriteRenderer != null)
            targetSpriteRenderer.sprite = images[currentIndex];
        if (targetImage != null)
            targetImage.sprite = images[currentIndex];

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