using UnityEngine;

public class MouthMovement : MonoBehaviour
{
    public SkinnedMeshRenderer mouthRenderer; // Blend Shape olan SkinnedMeshRenderer
    public int blendShapeIndex = 0;           // Kontrol edilecek Blend Shape index
    
    void Update()
    {
        // Zamanla sinüs dalgası oluşturup 0-100 arasına map edelim
        float mouthValue = (Mathf.Sin(Time.time * 2f) + 1f) * 50f;
        mouthRenderer.SetBlendShapeWeight(blendShapeIndex, mouthValue);
    }
}
