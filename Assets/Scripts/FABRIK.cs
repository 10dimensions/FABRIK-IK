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
        TargetRootDist = JointsRef.jointsData[0].JointsPos - EndEffector.position;

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
}
