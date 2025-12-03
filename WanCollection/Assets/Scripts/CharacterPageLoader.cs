using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Collections.Generic;
using UnityEngine.UI;

public class CharacterPageLoader : MonoBehaviour
{
    [Header("キャラID (フォルダ名)")]
    public string characterId;

    [Header("メイン画像（1枚だけ）")]
    public Image bodyImage;
    public Image backgroundImage;

    [Header("表情差分（配列）")]
    public Image faceDisplayImage;        // 実際に表示される Image
    public Sprite[] expressionSprites;    // 読み込んだ差分が入る配列
    public int expressionCount = 4;       // 差分枚数（必要な数に調整）

    [Header("その他 UI パーツ")]
    public Image[] extraUiImages;         // 複数登録OK
    public string[] extraUiNames;         // それぞれのファイル名

    private void Start()
    {
        LoadBody();
        LoadBackground();
       // LoadExpressions();
        LoadExtraUI();
    }

    // ----------- メイン画像読み込み ---------------
    void LoadBody()
    {
        if (bodyImage == null) return;
        string address = $"characters/{characterId}/body";
        AddressableImageLoader.LoadToImage(address, bodyImage);
    }

    void LoadBackground()
    {
        if (backgroundImage == null) return;
        string address = $"characters/{characterId}/bg";
        AddressableImageLoader.LoadToImage(address, backgroundImage);
    }

    // ------------ 表情差分の読み込み --------------
   /* void LoadExpressions()
    {
        expressionSprites = new Sprite[expressionCount];

        for (int i = 0; i < expressionCount; i++)
        {
            string address = $"characters/{characterId}/face/{i}.png";
            AddressableImageLoader.LoadToArray(address, expressionSprites, i);
        }
    }*/

    // ----------- その他 UI パーツ ---------------
    void LoadExtraUI()
    {
        int count = Mathf.Min(extraUiImages.Length, extraUiNames.Length);

        for (int i = 0; i < count; i++)
        {
            string address = $"characters/{characterId}/{extraUiNames[i]}";
            AddressableImageLoader.LoadToImage(address, extraUiImages[i]);
        }
    }

    // ----------- 表情切り替え ---------------
    /*public void SetExpression(int index)
    {
        if (faceDisplayImage == null) return;

        if (index < 0 || index >= expressionSprites.Length)
        {
            Debug.LogError($"[表情] index不正: {index}");
            return;
        }

        faceDisplayImage.sprite = expressionSprites[index];
    }*/
}