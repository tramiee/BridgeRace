using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step : MonoBehaviour
{
    [SerializeField] private ColorData colorData;
    [SerializeField] private Renderer stepRenderer;

    public ColorType colorType;
    public void SetColor(ColorType newColorType)
    {
        stepRenderer.material = colorData.GetMaterial(newColorType);
        colorType = newColorType;
    }
}
