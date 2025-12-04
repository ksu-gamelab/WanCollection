using UnityEngine;
using UnityEngine.UI;

public class CharacterPageLoader : MonoBehaviour
{
    [Header("キャラID (フォルダ名)")]
    public string characterId;

    [Header("メイン画像（1枚だけ）")]
    public Image bodyImage;
    public Image backgroundImage;

    /*[Header("表情差分（配列）")]
    public Image faceDisplayImage;        // 実際に表示される Image
    public Sprite[] expressionSprites;    // 読み込んだ差分が入る配列
    public int expressionCount = 4;       // 差分枚数（必要な数に調整）*/

    [Header("その他 UI パーツ")]
    public Image[] extraUiImages;         // 複数登録OK
    public string[] extraUiNames;         // それぞれのファイル名

    private void Start()
    {
        LoadBody();
        LoadBackground();
        //LoadExpressions();
        LoadExtraUI();
    }

    // ----------- メイン画像読み込み ---------------
    void LoadBody()
    {
        if (bodyImage == null) return;

        string path = $"characters/{characterId}/body";
        Sprite s = Resources.Load<Sprite>(path);

        if (s != null) bodyImage.sprite = s;
        else Debug.LogError($"[Body] Not found: {path}");
    }

    void LoadBackground()
    {
        if (backgroundImage == null) return;

        string path = $"characters/{characterId}/bg";
        Sprite s = Resources.Load<Sprite>(path);

        if (s != null) backgroundImage.sprite = s;
        else Debug.LogError($"[BG] Not found: {path}");
    }

    // ------------ 表情差分の読み込み --------------
    /*
    void LoadExpressions()
    {
        expressionSprites = new Sprite[expressionCount];

        for (int i = 0; i < expressionCount; i++)
        {
            string path = $"characters/{characterId}/face/{i}";
            Sprite s = Resources.Load<Sprite>(path);

            if (s != null) expressionSprites[i] = s;
            else Debug.LogError($"[Expression] Not found: {path}");
        }
    }
    */

    // ----------- その他 UI パーツ ---------------
    void LoadExtraUI()
    {
        int count = Mathf.Min(extraUiImages.Length, extraUiNames.Length);

        for (int i = 0; i < count; i++)
        {
            string path = $"characters/{characterId}/{extraUiNames[i]}";
            Sprite s = Resources.Load<Sprite>(path);

            if (s != null) extraUiImages[i].sprite = s;
            else Debug.LogError($"[ExtraUI] Not found: {path}");
        }
    }

    // ----------- 表情切り替え ---------------
    /*
    public void SetExpression(int index)
    {
        if (faceDisplayImage == null) return;

        if (index < 0 || index >= expressionSprites.Length)
        {
            Debug.LogError($"[表情] index不正: {index}");
            return;
        }

        faceDisplayImage.sprite = expressionSprites[index];
    }
    */
}
