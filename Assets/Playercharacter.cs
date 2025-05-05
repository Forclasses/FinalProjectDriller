using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;


public class Playercharacter : MonoBehaviour
{
    static public Playercharacter  S { get; private set; }

    [Header("Inscribed")]
    public static  float speed = 10;
    public float rollMult = -10;
    public float pitchMult = 10;

    [Header("Dynamic")] [SerializeField]
    
    //public float shieldLevel = 1;

    [Tooltip( "This field holds a reference to the last triggering GameObject")]
    private GameObject lastTriggerGo = null; //new GameObject();


    void Awake()
    {
        
        if(S == null) {
        S = this;
    } else {
        Debug.LogError(" Playercharacter.Awake() - Attempted to assign second Hero.S!");
        // is it bad I think a  second hero ship could be fun
    }

    }

    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");


        //HEY JUST AS AN ASIDE HERE PLEASE NOTIFY THE CLASS THAT WE NEED TO CHANG OUT INPUT SETTINGS WHEN USING tHE BOOK
        // reddit post You can't use Input.GetAxis or Input.GetKey etc. if you are using the new Unity input system. 
        // Check your settings in Edit > Project Settings > Player > Other Settings > Active Input Handling
        // my add: it needs to be set to hold. I am so glad someone else had this error a few days ago
        // reddit linkly https://www.reddit.com/r/Unity3D/comments/1ixyuwk/how_do_i_fix_the_invalidoperationexception_you/

        Vector3 pos = transform.position;
        pos.x += hAxis * speed * Time.deltaTime;
        pos.y += vAxis * speed * Time.deltaTime;
        transform.position = pos;

        transform.rotation = Quaternion.Euler(vAxis*pitchMult,hAxis*rollMult,0);

    }

    void OnTriggerEnter(Collider other)
    {
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;
        //Debug.Log("Shield trigger hit by " + go.gameObject.name);

        if( go == lastTriggerGo ) return;
        lastTriggerGo = go;
        Rocks enemy = go.GetComponent<Rocks>();
        
        if(enemy != null){
            Driller.AddScore();
            Destroy(go);
        }
        else {
            Debug.LogWarning("Shield trigger hit by non-Enemy" + go.name);
        }
    }
}
