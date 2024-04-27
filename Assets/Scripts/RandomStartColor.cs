using UnityEngine;

public class RandomStartColor : MonoBehaviour
{
    private const float MinHue = 0f;
    private const float MaxHue = 1f;
    private const float MinSaturation = 0f;
    private const float MaxSaturation = 1f;
    private const float MinValue = 0.5f;
    private const float MaxValue = 1f;
    private const string ColorAtribute = "_Color";

    private void Start()
    {
        if (TryGetComponent(out Renderer renderer))
            renderer.material.SetColor(ColorAtribute, Random.ColorHSV(MinHue, MaxHue, MinSaturation, MaxSaturation, MinValue, MaxValue));
    }
}
