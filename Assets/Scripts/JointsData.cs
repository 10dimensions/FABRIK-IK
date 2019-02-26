using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointsData : MonoBehaviour
{
   public Vector3 JointsPos;
   public Vector3 DeltaJointPos;

    public JointsData(Vector3 _jointsPos, Vector3 _deltaJointPos)
    {
        this.JointsPos = _jointsPos;
        this.DeltaJointPos = _deltaJointPos;
    }

}