using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class JointsData
{
   public Vector3 JointsPos;
   public Vector3 DeltaJointPos;

    public JointsData(Vector3 _jointsPos, Vector3 _deltaJointPos)
    {
        JointsPos = _jointsPos;
        DeltaJointPos = _deltaJointPos;
    }

    // public JointsData(Vector3 _newjointsPos)
    // {
    //     this.NewJointsPos = _newjointsPos;
    // }

}