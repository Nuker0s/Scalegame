using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class towergen : MonoBehaviour
{
    public static Vector3Int[] directions = new Vector3Int[] {Vector3Int.up,/*Vector3Int.down,*/Vector3Int.left,Vector3Int.right,Vector3Int.forward,Vector3Int.back};
    public GameObject cubePrefab;
    public List<roomdata> rooms = new List<roomdata>();
    public int height = 10;
    public float cubeSize = 1f;
    public float sidewaysChance = 0.5f;
    public float sidewaysOffset = 1f;
    void Start()
    {
        Vector3 position = transform.position;
        Vector3Int lastdir = -directions[0];
        roomdata lastroom = new roomdata(new Vector3Int(0,0,0));
        for (int i = 0; i < height; i++)
        {

        }
    }
    public class roomdata 
    {
        Vector3Int lastroom;
        Vector3Int room;
        Vector3Int nextroom;
        public roomdata() { }
        public roomdata(Vector3Int newroom)
        {
            room = newroom;
        }
        public roomdata(Vector3Int newroom,Vector3Int prevroom) 
        {
            lastroom = prevroom;
            room = newroom;
        }
        public roomdata( Vector3Int newroom, Vector3Int prevroom, Vector3Int newnewroom)
        {
            lastroom = prevroom;
            room = newroom;
            nextroom = newnewroom;
        }


    }
    public static Vector3Int randirex(Vector3Int exclude)
    {
        List<Vector3Int> tempDirections = new List<Vector3Int>(directions);
        tempDirections.Remove(exclude);

        return tempDirections[Random.Range(0, tempDirections.Count)];
    }
}
