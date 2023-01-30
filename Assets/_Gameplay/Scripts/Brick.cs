using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private Renderer brickRenderer;
    [SerializeField] private ColorData colorData;
    private ColorType colorType;
    public ColorType ColorType => colorType;

    public void SetColor(ColorType colorType)
    {
        this.colorType = colorType;
        brickRenderer.material = colorData.GetMaterial(colorType);
    }

   /* public ColorType GetColorType()
    {
        return colorType;
    }*/
}
