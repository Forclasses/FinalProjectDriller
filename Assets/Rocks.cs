using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

[RequireComponent( typeof(BoundsCheck))]
public class Rocks : MonoBehaviour
{
    [Header("Inscribed")]

    protected bool calledRockDestoryed = false;
   
    
    public float health = 10;
    public int score = 10;

    //protected bool calledShipDestoryed = false;

    protected BoundsCheck bndCheck;

    void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    }

    public Vector3 pos {
        get {
            return this.transform.position;
        }
        set {
            this.transform.position = value;
        }
    }

        void Update()
    {

        //this is not wokring
        //At this point I can't tell if bndCheck is a thing or not.. am to afriad to touch it to check

       if( bndCheck.LocIs( BoundsCheck.eScreenLocs.offDown )){

            //print("Is getting singal");
            Destroy( gameObject );
        }
        //this works well enough for now something is off with my bounds check and locis..

        if (pos.y < -50){
            Destroy( gameObject );

        }
        if (pos.y > 50){
            Destroy( gameObject );

        }
        if (pos.x < -20){
            Destroy( gameObject );

        }
        if (pos.x > 20){
            Destroy( gameObject );

        }


    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject otherGO = coll.gameObject;
        Playercharacter p = otherGO.GetComponent<Playercharacter>();
        
            
            health -= 5;
            if( health <= 0){  
                if(!calledRockDestoryed){
                        calledRockDestoryed = true;
                        Driller.ROCK_DESTORYED( this );
                    }   
                Destroy(this.gameObject);
            }
            

            //back up code incase of annance with bnd check

            //if( (pos.x < 16) && (pos.x > -16) && (pos.y < 34)  ){
             //   health -= Main.GET_WEAPON_DEFINITION( p.type ).damageOnHit;
             //   if( health <= 0){
             //       Destroy(this.gameObject);
             //   }
            //}
            

        
    }
}

