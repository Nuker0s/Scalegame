using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UIElements;

public class towergen : MonoBehaviour
{
    public static Vector3Int[] directions = new Vector3Int[] {Vector3Int.up,/*Vector3Int.down,*/Vector3Int.left,Vector3Int.right,Vector3Int.forward,Vector3Int.back};
    public GameObject cubePrefab;
    public List<roomdata> rooms = new List<roomdata>();//list of all rooms
    public int height = 10;
    public float cubeSize = 1f;
    public float sidewaysChance = 50;
    public float sidewaysOffset = 1f;
    public bool regenerate;
    void Start()
    {
        
        Vector3Int lastdir = -directions[0];
        roomdata lastroom = new roomdata(new Vector3Int(0,0,0));

        for (int i = 0; i < height; i++)
        {
            Vector3Int nextdir;
            Vector3Int newroompos;
            while (true) 
            { 
                if (Random.Range(0, 100)<sidewaysChance)
                {
                    nextdir = randirex(-lastdir);
                }
                else
                {
                    nextdir = lastdir;
                }


                newroompos = nextdir + lastroom.room;
                if (IsPositionTaken(newroompos))
                {
                    
                }
                else
                {
                    break;
                }
            }
            roomdata roomdata = new roomdata(newroompos);

            lastdir = nextdir;
            roomdata.lastroom = lastroom.room;
            lastroom.nextroom = roomdata.room;
            lastroom = roomdata;
            rooms.Add(roomdata);
        }
        //Debug.Log(rooms[31].nextroom + ", " + rooms[31].room + ", " + rooms[31].lastroom);
        /*foreach (var item in rooms)
        {
            Instantiate(cubePrefab, item.room, Quaternion.identity);
        }*/
    }
    private void Update()
    {
        if (regenerate)
        {
            rooms.Clear();
            regenerate = false;
            Vector3Int lastdir = -directions[0];
            roomdata lastroom = new roomdata(new Vector3Int(0, 0, 0));

            for (int i = 0; i < height; i++)
            {
                Vector3Int nextdir;
                Vector3Int newroompos;
                while (true)
                {
                    if (Random.Range(0, 100) < sidewaysChance)
                    {
                        nextdir = randirex(-lastdir);
                    }
                    else
                    {
                        nextdir = lastdir;
                    }


                    newroompos = nextdir + lastroom.room;
                    if (IsPositionTaken(newroompos))
                    {

                    }
                    else
                    {
                        break;
                    }
                }
                roomdata roomdata = new roomdata(newroompos);

                lastdir = nextdir;
                roomdata.lastroom = lastroom.room;
                lastroom.nextroom = roomdata.room;
                lastroom = roomdata;
                rooms.Add(roomdata);
            }

        }
    }
    private void OnDrawGizmos()
    {
        
        if (rooms.Count > 1)
        {
            for (int i = 0; i < rooms.Count - 1; i++)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(rooms[i].room, rooms[i + 1].room);
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(rooms[i].room, 0.1f);
            }
        }
        
    }
    public class roomdata 
    {
        public Vector3Int lastroom;
        public Vector3Int room;
        public Vector3Int nextroom;
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
        /*if (exclude != -directions[0])
        {
            tempDirections.Remove(exclude);
        }*/
        

        return tempDirections[Random.Range(0, tempDirections.Count)];
    }
    public bool IsPositionTaken(Vector3Int position)
    {
        foreach (var room in rooms)
        {
            if (room.room == position)
            {
                return true;
            }
        }
        return false;
    }

}
