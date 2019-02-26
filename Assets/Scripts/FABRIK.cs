using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FABRIK : MonoBehaviour
{   
    private Transform EndEffector;
    private Transform GoalObject;
    [SerializeField] private Transform BaseRotor;
    private Vector3 TargetRootDist;

    [SerializeField] private Joints JointsRef;

    void Start()
    {
        EndEffector = GameObject.FindWithTag("end_effector").transform;
        GoalObject = GameObject.FindWithTag("goal").transform;

    }

    private void Update()
    {

    }

    private void Fabrik() 
    {
        TargetRootDist = JointsRef.jointsData[0].JointsPos - GoalObject.position;

        bool _checkReach = CheckForReach(TargetRootDist);
        if(_checkReach)
        {
            TargetOutofReach();
        }
        else
        {

        }


        while( TargetRootDist.magnitude > 0.1 ) 
        {
            FinalToRoot(); // PartOne
            RootToFinal(); // PartTwo
        }
    
    }

    private void FinalToRoot()
    {

    }

    private void RootToFinal()
    {

    }

    private bool CheckForReach(Vector3 _targetroot)
    {   
        float temp=0;
        for(int i=0; i<JointsRef.jointsData.Count;i++)
        {
            temp += JointsRef.jointsData[i].DeltaJointPos.magnitude;
        }

        if(_targetroot.magnitude > temp)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void TargetOutofReach()
    {
        for(int j=0; j<JointsRef.jointsData.Count-1; j++)
        {
            float r_i = (GoalObject.position).magnitude - JointsRef.jointsData[j].JointsPos.magnitude;
            float lamd_i = JointsRef.jointsData[j].DeltaJointPos.magnitude  /  r_i;

            Vector3 _npos = (1-lamd_i)*JointsRef.jointsData[j].JointsPos + lamd_i*GoalObject.position;

            JointsRef.jointsData[j+1].NewJointsPos = _npos;
        }
    }
}