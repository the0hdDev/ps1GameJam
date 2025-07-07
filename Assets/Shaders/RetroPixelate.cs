using UnityEngine;

[ExecuteInEditMode]
public class RetroPixelateEffect : MonoBehaviour
{
    public Material EffectMaterial;

    [Range(1, 64)]
    public float PixelSize = 4;

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (EffectMaterial != null)
        {
            EffectMaterial.SetFloat("_PixelSize", PixelSize);
            Graphics.Blit(src, dest, EffectMaterial);
        }
        else
        {
            // Fallback, falls kein Material gesetzt
            Graphics.Blit(src, dest);
        }
    }
}
