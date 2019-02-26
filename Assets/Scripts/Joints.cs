using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joints : MonoBehaviour
{   
    [SerializeField] private Transform[] ArmJoints;
    public List<JointsData> jointsData;
    void Start()
    {
        jointsData = new List<JointsData>();
        PopulateList();
    }


    private void PopulateList()
    {
        for(int i=0; i<ArmJoints.Length; i++)
        {   
            if(i==ArmJoints.Length -1)
            {
                jointsData.Add(new JointsData( ArmJoints[i].position, new Vector3(0,0,0)));
            }
            else
            {
                jointsData.Add(new JointsData( ArmJoints[i].position, 
                                            ArmJoints[i+1].position - ArmJoints[i].position
                                        ));
            }
        }
    }
}
