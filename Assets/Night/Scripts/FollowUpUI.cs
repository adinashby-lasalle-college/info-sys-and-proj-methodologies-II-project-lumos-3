using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FollowUpUI : MonoBehaviour, I_FollowUpUI
{
    //Base Class of Followup UI
    protected Transform target;
    protected Vector3 offset;


    public void SetTarget(Transform Target, Vector3 Offset)
    {
        this.target = Target;
        this.offset = Offset;
    }

    public virtual void UpdatePosition()
    {
        if (target != null)
        {
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(target.transform.position + offset);
            this.transform.position = target.transform.position;
            transform.position = screenPoint;
        }
    }

    protected virtual void LateUpdate()
    {
        UpdatePosition();
    }
}
