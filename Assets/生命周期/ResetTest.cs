using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTest : MonoBehaviour
{
    public int row =20;
    public int col =20;
    private void Reset() {
         GameObject t = null;
        for(int i = 0; i < row; i++)
        {
            GameObject cylinderObj = GameObject.Find("Cylinder");
            for(int j = 0; j < col; j++)
            {
                Vector3 position = new Vector3(i*2, 0, j*2);
                t = Instantiate(cylinderObj,position,Quaternion.identity);
                t.transform.SetParent(transform,false);
                t.gameObject.name = "Tree"+i+"_"+j;
            }
        }
    }
    

   
}
