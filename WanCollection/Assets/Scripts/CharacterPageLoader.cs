using UnityEngine;
using UnityEngine.UI;


public class CharacterPageLoader : MonoBehaviour
{
    [Header("キャラID (フォルダ名)")]
    public string characterId;

    [Header("メイン画像（1枚だけ）")]
    public SpriteTarget body;
    public SpriteTarget background;

    [Header("その他 UI / 2D パーツ")]
    public SpriteTarget[] extras;
    public string[] extraUiNames;         // それぞれのファイル名

    private void Start()
    {
        LoadToTarget(body, "body");
        LoadToTarget(background, "bg");
        LoadExtras();
    }

    // =============================
    // Sprite のロード + 自動セット
    // =============================
    void LoadToTarget(SpriteTarget target, string fileName)
    {
        if (target == null || !target.IsValid()) return;

        string path = $"characters/{characterId}/{fileName}";
        Sprite s = Resources.Load<Sprite>(path);

        if (s == null)
        {
            Debug.LogError($"[LoadFailed] {path}");
            return;
        }

        target.SetSprite(s);
    }

    // =============================
    // その他 UI / 2D パーツ
    // =============================
    void LoadExtras()
    {
        int count = Mathf.Min(extras.Length, extraUiNames.Length);

        for (int i = 0; i < count; i++)
        {
            LoadToTarget(extras[i], extraUiNames[i]);
        }
    }
}