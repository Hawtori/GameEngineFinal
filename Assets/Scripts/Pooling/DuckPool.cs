using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckPool : MonoBehaviour
{
    public static DuckPool instance { get; set; }
    public Queue<GameObject> ducks;
    //public GameObject[] ducks;

    public GameObject duckPrefab;

    public int numberOfDucks;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this); 
    }

    private void Start()
    {
        ducks = new Queue<GameObject>();
        for(int i = 0; i < numberOfDucks; i++)
        {
            GameObject d = Instantiate(duckPrefab, Vector3.zero, Quaternion.identity, transform);
            d.SetActive(false);
            ducks.Enqueue(d);
        }
    }

    public GameObject GetDuck()
    {
        if(ducks.Count > 0)
        {
            GameObject d = ducks.Dequeue();
            d.SetActive(true);
            return d;
        }
        else
        {
            return Instantiate(duckPrefab, Vector3.zero, Quaternion.identity);
        }
    }

    public void ReturnDuck(GameObject d)
    {
        d.SetActive(false);
        d.transform.position = Vector3.zero;
        ducks.Enqueue(d);
    }
    
}
