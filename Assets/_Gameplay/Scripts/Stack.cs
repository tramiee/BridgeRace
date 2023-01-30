using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    [SerializeField] private ColorData colorData;
    [SerializeField] private Renderer stackRenderer;

    public void SetColor(ColorType colorType)
    {
        stackRenderer.material = colorData.GetMaterial(colorType);
    }
}
