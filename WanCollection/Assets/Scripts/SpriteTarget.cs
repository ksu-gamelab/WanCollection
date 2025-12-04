using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SpriteTarget
{
    public Image image;
    public SpriteRenderer spriteRenderer;

    public bool IsValid()
    {
        return image != null || spriteRenderer != null;
    }

    public void SetSprite(Sprite s)
    {
        if (image != null) image.sprite = s;
        if (spriteRenderer != null) spriteRenderer.sprite = s;
    }
}
