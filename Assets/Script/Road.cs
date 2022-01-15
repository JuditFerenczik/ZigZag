using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject roadPrefeb;
    public float offset = 0.707f;
    public Vector3 lastPos;
    private int rowCount = 0;
    // Start is called before the first frame update
    public void StartBulding()
    {
        InvokeRepeating("CreateNewRoadPart", 1f, 0.5f);
    }
    public void CreateNewRoadPart()
    {
        Debug.Log("Create new part");
        Vector3 spawPos = Vector3.zero;
        float chance = Random.Range(0,100);
        if(chance < 50)
        {
            spawPos = new Vector3(lastPos.x + offset, lastPos.y, lastPos.z + offset);
        }
        else
        {
            spawPos = new Vector3(lastPos.x - offset, lastPos.y, lastPos.z + offset);
        }
        GameObject g = Instantiate(roadPrefeb, spawPos, Quaternion.Euler(0,45,0));
        lastPos = g.transform.position;
        rowCount++;
        if(rowCount % 5 == 0)
        {
            g.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
 
}
