using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EndlessSpawner : MonoBehaviour
{
    public Transform player;
    public float generateRate = 10f;

    public GameObject[] challengeObjects;
    public GameObject colorChanger;

    public int lastObjPos = -3;

    private void Start()
    {
        //for(int i=0; i<3;i++)
        //{
        //    challengeCreator();
        //}

        StartCoroutine(challengeTimer());
    }
    
    IEnumerator challengeTimer()
    {
        while(true)
        {
            challengeCreator();

            yield return new WaitForSeconds(2f);

        }
    }


    void challengeCreator()
    {
        int coin = Random.Range(0, 5);
        if (coin % 2 == 0)
        {
            int which = Random.Range(0, challengeObjects.Length);

            int whereY = lastObjPos + Random.Range(5, 10);

            lastObjPos = whereY;

            Vector3 location = new Vector3(0f, whereY, 0);

            Instantiate(challengeObjects[which], location, Quaternion.identity);
        }
        else
        {
            int whereY = lastObjPos + Random.Range(3, 5);

            lastObjPos = whereY;

            Vector3 location = new Vector3(0f, whereY, 0);

            Instantiate(colorChanger, location, Quaternion.identity);

        }
    }
}
