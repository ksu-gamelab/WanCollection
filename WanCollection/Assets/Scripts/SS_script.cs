using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_script : MonoBehaviour
{
    // 表示対象のオブジェクトリスト
    public List<GameObject> objectsToShow;

    // 非表示対象のオブジェクトリスト
    public List<GameObject> objectsToHide;

    // アニメーション用のAnimator
    public Animator animator;

    // アニメーションのTrigger名
    public string Click;

    // 現在の表示・非表示状態を管理
    private bool isVisible = true;

    // ボタンで呼び出すメソッド
    public void ToggleVisibility()
    {
        // 表示状態を切り替え
        isVisible = !isVisible;

        // 表示するオブジェクトを切り替え
        foreach (GameObject obj in objectsToShow)
        {
            if (obj != null)
            {
                obj.SetActive(isVisible);
            }
        }

        // 非表示にするオブジェクトを切り替え
        foreach (GameObject obj in objectsToHide)
        {
            if (obj != null)
            {
                obj.SetActive(!isVisible);
            }
        }

        // アニメーションを再生
        PlayAnimation();
    }

    // アニメーションを再生するメソッド
    private void PlayAnimation()
    {
        if (animator != null && !string.IsNullOrEmpty(Click))
        {
            animator.SetTrigger(Click);
        }
        else
        {
            Debug.LogWarning("AnimatorまたはTrigger名が設定されていません。");
        }
    }
}
