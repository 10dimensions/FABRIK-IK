using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FABRIK : MonoBehaviour
{   
    private Transform EndEffector;
    private Transform GoalObject;
    [SerializeField] private Transform BaseRotor;
    private Vector3 TargetRootDist;

    [SerializeField] private GameObject JointsObjRef;
    private Joints JointsRef;
    public int JointsCount;

    private Vector3 _b;
    private float _diff_a;


    void Start()
    {   
        
        EndEffector = GameObject.FindWithTag("end_effector").transform;
        GoalObject = GameObject.FindWithTag("goal").transform;
        JointsRef = JointsObjRef.GetComponent<Joints>();

        //JointsRef.PopulateList();
        //Fabrik();

    }

    public void Fabrik() 
    {   
        JointsCount = JointsRef.jointsData.Count;

        TargetRootDist = JointsRef.jointsData[0].JointsPos - GoalObject.position;

        bool _checkReach = CheckForReach(TargetRootDist);
        if(_checkReach)
        {
            TargetOutofReach();
        }
        else
        {
            TargetWithinReach();
        }

    
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
            float r_i = (GoalObject.position - JointsRef.jointsData[j].JointsPos).magnitude;
            float lamd_i = JointsRef.jointsData[j].DeltaJointPos.magnitude  /  r_i;

            Vector3 _npos = (1-lamd_i)*JointsRef.jointsData[j].JointsPos + lamd_i*GoalObject.position;

            //JointsRef.jointsData[j+1].NewJointsPos = _npos;
            JointsRef.jointsData[j+1].JointsPos = _npos;

            //print(JointsRef.jointsData[j+1].JointsPos);
            
        }
        print("target out of reach");
    }

    private void TargetWithinReach()
    {   
        print("target within reach");

        _b = JointsRef.jointsData[0].JointsPos;

        _diff_a = (JointsRef.jointsData[JointsCount-1].JointsPos - GoalObject.position).magnitude;
        print(_diff_a);

        /* */
        while( _diff_a > 0.05 ) 
        {
            FinalToRoot(); // PartOne
            RootToFinal(); // PartTwo

            _diff_a = (JointsRef.jointsData[JointsCount-1].JointsPos - GoalObject.position).magnitude;
            print(_diff_a.ToString("F4"));
        }

    }


    private void FinalToRoot()
    {
        JointsRef.jointsData[JointsCount-1].JointsPos = GoalObject.position;

        for(int k=JointsCount-2; k>=0; k--)
        {
            float r_if = (JointsRef.jointsData[k+1].JointsPos - JointsRef.jointsData[k].JointsPos).magnitude;
            float lamd_if = JointsRef.jointsData[k].DeltaJointPos.magnitude  /  r_if;

            //print("r : " + r_if + "lambda :" + lamd_if);
            //print("before: " + JointsRef.jointsData[k].JointsPos.ToString("F4"));

            JointsRef.jointsData[k].JointsPos = (1-lamd_if) * JointsRef.jointsData[k+1].JointsPos + 
                                                                lamd_if * JointsRef.jointsData[k].JointsPos;
            
            //print("after: " + JointsRef.jointsData[k].JointsPos.ToString("F4"));

        } 
    }

    private void RootToFinal()
    {
        JointsRef.jointsData[0].JointsPos = _b;
        print("root_final" + JointsRef.jointsData[0].JointsPos);

        /* */
        for(int m=0; m<=JointsCount-2; m++)
        {
            float r_ir = (JointsRef.jointsData[m+1].JointsPos - JointsRef.jointsData[m].JointsPos).magnitude;
            float lamd_ir = JointsRef.jointsData[m].DeltaJointPos.magnitude  /  r_ir;

            JointsRef.jointsData[m+1].JointsPos = (1-lamd_ir) * JointsRef.jointsData[m].JointsPos + 
                                                                lamd_ir * JointsRef.jointsData[m+1].JointsPos;
        
           // print(JointsRef.jointsData[m+1].JointsPos);
        }
    }

}