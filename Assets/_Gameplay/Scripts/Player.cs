using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody),typeof(CapsuleCollider))]
public class Player : Character
{
    [SerializeField] private Transform tf;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private VariableJoystick variableJoystick;
    [SerializeField] private float speed;
    private Vector3 direction;

    private bool isSteped = true;

    // Start is called before the first frame update
    void Start()
    {
        SetColor(ColorType.Yellow);
    }

    private void FixedUpdate()
    {
        Moving();
    }

    private void Moving()
    {
        direction = new Vector3(variableJoystick.Horizontal * speed * Time.fixedDeltaTime, rb.velocity.y, variableJoystick.Vertical * speed * Time.fixedDeltaTime);

        isSteped = CheckStep();

        if (isSteped)
        {
           
            if (numberOfStack == 0 && direction.z > 0)
            {
                direction = Vector3.zero;
            }
            rb.velocity = direction;
        }

        if(variableJoystick.Horizontal != 0 || variableJoystick.Vertical != 0)
        {
            rb.velocity = direction;
            tf.rotation = Quaternion.LookRotation(rb.velocity);
            ChangeAnim("Run");
        }
        else
        {
            rb.velocity = Vector3.zero;
            ChangeAnim("Idle");
        }
    }

    private bool CheckStep()
    {
        int stepLayerMask = LayerMask.GetMask(Constant.LAYER_STEP);
        Physics.Raycast(rayCastPoint.position, Vector3.down, out RaycastHit hit, Mathf.Infinity, stepLayerMask);
        return hit.collider != null;
    }
}
