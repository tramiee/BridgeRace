using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] Renderer bodyRenderer;
    [SerializeField] ColorData colorData;

    [SerializeField] private Animator anim;
    private string currentAnimName;

    public ColorType colorPlayer;

    public Stack stackPrefad;
    private List<Stack> stacks = new List<Stack>();

    public Transform stackHolder;
    protected int numberOfStack;

    [SerializeField] protected Transform rayCastPoint;

    private void Update()
    {
        BuildBridge();
    }
    protected void ChangeAnim(string animName)
    {
        if(currentAnimName != animName)
        {
            anim.ResetTrigger(currentAnimName);
            currentAnimName = animName;
            anim.SetTrigger(currentAnimName);
        }
    }
  
    public void SetColor(ColorType colorType)
    {
        bodyRenderer.material = colorData.GetMaterial(colorType);
    }

    public void AddBrick()
    {

        GameObject newStack = SimplePool.Spawn(stackPrefad.gameObject, stackHolder.position + Vector3.up * numberOfStack * 0.15f, stackHolder.rotation);
        newStack.transform.SetParent(stackHolder);
        Stack stack = newStack.GetComponent<Stack>();
        stack.SetColor(colorPlayer);
        numberOfStack += 1;
        stacks.Add(stack);
    }

    public void RemoveBrick()
    {
        if (stacks.Count > 0)
        {
            SimplePool.Despawn(stacks[stacks.Count - 1].gameObject);
            stacks.RemoveAt(stacks.Count - 1);
            numberOfStack -= 1;
        }
    }

    public void BuildBridge()
    {
        int stepLayerMask = LayerMask.GetMask(Constant.LAYER_STEP);
        if (Physics.Raycast(rayCastPoint.position, Vector3.down, out RaycastHit hit, Mathf.Infinity, stepLayerMask))
        {
            Step hitStep = hit.collider.gameObject.GetComponent<Step>();
            if (hitStep.colorType != colorPlayer)
            {
                hitStep.gameObject.GetComponent<Renderer>().enabled = true;
                hitStep.SetColor(colorPlayer);
                RemoveBrick();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_BRICK))
        {
            //TODO: CACHE COMPONENT
            Brick colliderBrick = other.gameObject.GetComponent<Brick>();
            if (colliderBrick.ColorType == colorPlayer)
            {
                AddBrick();
                SimplePool.Despawn(other.gameObject);
            }
        }
    }
}