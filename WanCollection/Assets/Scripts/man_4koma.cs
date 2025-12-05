using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

[System.Serializable]
public class AtlasImageData
{
    [Header("キャラID（例: 001, yume, man_01 など）")]
    public string characterID;

    [Header("対応するボタン")]
    public Button button;
}

public class man_4koma : MonoBehaviour
{
    [Header("画像アトラス")]
    public SpriteAtlas atlas;

    [Header("画像を表示するImage")]
    public Image targetImage;

    [Header("ボタンと対応画像の設定リスト")]
    public List<AtlasImageData> imageDataList;

    [Header("表示するオブジェクト（画像表示時にONにする）")]
    public List<GameObject> objectsToShow;

    [Header("非表示にするオブジェクト（元ボタン、ロゴなど）")]
    public List<GameObject> objectsToHide;

    [Header("戻るボタン（Buttonにしてください）")]
    public Button backButton;

    [Header("再生するAnimatorのリスト")]
    public List<Animator> animators;

    [Header("AnimatorのTrigger名")]
    public string animationTrigger;

    private void Start()
    {
        // 各ボタンに対して設定
        foreach (var data in imageDataList)
        {
            // ===== ボタン画像名を自動生成 =====
            string buttonSpriteName = "icon_" + data.characterID;

            // ボタンのImageにセット
            Image btnImg = data.button.GetComponent<Image>();
            if (btnImg != null)
            {
                Sprite btnSprite = atlas.GetSprite(buttonSpriteName);
                if (btnSprite != null)
                {
                    btnImg.sprite = btnSprite;
                }
                else
                {
                    Debug.LogError("ボタン画像がアトラス内にありません: " + buttonSpriteName);
                }
            }

            // ---- ② ボタン押下時の表示画像を設定 ----
            string displaySpriteName = data.characterID;
            data.button.onClick.AddListener(() => ShowImage(displaySpriteName));
        }

        // 戻るボタン設定
        if (backButton != null)
        {
            backButton.onClick.AddListener(HideImage);
        }
    }

    /// <summary>
    /// 画像表示
    /// </summary>
    public void ShowImage(string spriteName)
    {
        Sprite sp = atlas.GetSprite(spriteName);

        if (sp == null)
        {
            Debug.LogError("アトラス内に Sprite が見つかりません: " + spriteName);
            return;
        }

        // 画像セット
        targetImage.sprite = sp;
        targetImage.enabled = true;

        // 表示切り替え
        foreach (var obj in objectsToShow) obj.SetActive(true);
        foreach (var obj in objectsToHide) obj.SetActive(false);

        PlayAnimation();
    }

    /// <summary>
    /// 戻る（元UIへ）
    /// </summary>
    public void HideImage()
    {
        targetImage.sprite = null;
        targetImage.enabled = false;

        foreach (var obj in objectsToShow) obj.SetActive(false);
        foreach (var obj in objectsToHide) obj.SetActive(true);

        PlayAnimation();
    }

    private void PlayAnimation()
    {
        foreach (Animator animator in animators)
        {
            if (animator != null && !string.IsNullOrEmpty(animationTrigger))
            {
                animator.ResetTrigger(animationTrigger);
                animator.SetTrigger(animationTrigger);
            }
        }
    }
}
