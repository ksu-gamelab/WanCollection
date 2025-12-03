using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public static class AddressableImageLoader
{
    // Sprite を読み込んで Image に適用
    public static void LoadToImage(string address, Image target)
    {
        if (target == null)
        {
            Debug.LogWarning($"[Loader] Image が指定されていません: {address}");
            return;
        }

        Addressables.LoadAssetAsync<Sprite>(address).Completed += (handle) =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                target.sprite = handle.Result;
            }
            else
            {
                Debug.LogError($"[Loader] Sprite 読み込み失敗: {address}");
            }
        };
    }

    // Sprite を読み込んで **配列に格納**（表情差分用）
    public static void LoadToArray(string address, Sprite[] array, int index)
    {
        Addressables.LoadAssetAsync<Sprite>(address).Completed += (handle) =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                array[index] = handle.Result;
            }
            else
            {
                Debug.LogError($"[Loader] 差分読み込み失敗: {address}");
            }
        };
    }
}
