using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_script : MonoBehaviour
{
    // 表示対象のオブジェクトリスト
    public List<GameObject> objectsToShow;

    // 非表示対象のオブジェクトリスト
    public List<GameObject> objectsToHide;

    // 複数のAnimatorを設定
    public List<Animator> animators;

    // アニメーションのTrigger名
    public string animationTrigger;

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
