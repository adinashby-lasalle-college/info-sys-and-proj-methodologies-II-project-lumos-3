using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_FollowUpUI
{
    //Interface for all UI that follow
    //Defines methods for updating UI position
    void SetTarget(Transform target, Vector3 offset);
    void UpdatePosition();
}
