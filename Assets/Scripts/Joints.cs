using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joints : MonoBehaviour
{   
    public Transform[] ArmJoints;
    public List<JointsData> jointsData;
    void Start()
    {
        jointsData = new List<JointsData>();
        PopulateList();
        GameObject.FindWithTag("fabrik").GetComponent<FABRIK>().Fabrik();
    }


    public void PopulateList()
    {
        for(int i=0; i<ArmJoints.Length; i++)
        {   
            if(i != ArmJoints.Length -1)
            {
               jointsData.Add(new JointsData( ArmJoints[i].position, 
                                            ArmJoints[i+1].position - ArmJoints[i].position
                                        ));
            }
            else
            {
                jointsData.Add(new JointsData( ArmJoints[i].position, new Vector3(0,0,0)));
                print(jointsData[i]);
                
            }
        
        }

    }

    private void UpdateList()
    {
        for(int i=0; i<ArmJoints.Length; i++)
        {
            if(i==ArmJoints.Length -1)
            {
                jointsData[i]=(new JointsData( ArmJoints[i].position, new Vector3(0,0,0)));
            }
            else
            {
                jointsData[i]=(new JointsData( ArmJoints[i].position, 
                                            ArmJoints[i+1].position - ArmJoints[i].position
                                        ));
            }
        }
    }
}
