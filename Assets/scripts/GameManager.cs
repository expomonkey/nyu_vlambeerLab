using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    public int tileCount;
    public float highestX, highestZ, lowestX, lowestZ;
    public List<Tile> tileList;
    public GameObject firstCamera;
    public GameObject pathmaker;
    bool shouldRestart;
        float aveX=0, aveZ=0;
    int counter;
	// Use this for initialization
	void Start () {
        tileCount = 0;
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
            aveX = (highestX+lowestX)/ 2;
            aveZ = (highestZ+lowestZ)/2;
            Vector3 pos = new Vector3(aveX, firstCamera.transform.position.y, aveZ);

           firstCamera.transform.position=pos;


        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
            
        }
       
	}
    public void Restart()
    {
        shouldRestart = true;
        if (shouldRestart)
        {
            foreach (Tile tileToDie in tileList)
            {
                Destroy(tileToDie.gameObject);

            }
        }
        tileList.Clear();
        shouldRestart = false;
        tileCount = 0;
        Instantiate(pathmaker, new Vector3(4.226264f, 8.04957f, -14.78f), Quaternion.identity);
    }
}
