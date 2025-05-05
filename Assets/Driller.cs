using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;



public class Driller : MonoBehaviour
{
    static private Driller S;
 //   static private Dictionary<eWeaponType, WeaponDefinition> WEAP_DICT;

    [Header("Inscribed")]
    public bool spawnRocks= true;
    public GameObject[] prefabRocks;

    
    public Text ScoreBoard;
    public float gameRestartDelay = 2;

    

    [Header("Dynamic")]
    public static int Score;
    public Button Restart1;

    public Button Upgrade;

    public Playercharacter speed;

 //   public WeaponDefinition[] weaponDefinitions;
//    public eWeaponType[] powerUpFrequency = new eWeaponType[] {
 //                               eWeaponType.blaster, eWeaponType.blaster,
 //                               eWeaponType.spread , eWeaponType.shield    
 //   };

    private BoundsCheck bndCheck;

    void Awake()
    {
        S = this;

        Score = 0;

        bndCheck = GetComponent<BoundsCheck>();
        UpdateGUI();
        Restart1.onClick.AddListener(restarting);
        Upgrade.onClick.AddListener(Upgrader);

        //Invoke( nameof(SpawnEnemy), 1f/enemySpawnPerSecond );
        /*WEAP_DICT = new Dictionary<eWeaponType, WeaponDefinition>();
        foreach ( WeaponDefinition def in weaponDefinitions ){
            WEAP_DICT[def.type] = def;
        }*/
    }
    /*public void SpawnEnemy(){
        if ( !spawnRocks ){
            Invoke( nameof( SpawnEnemy ), 1f/enemySpawnPerSecond);
            return;
        }
        int ndx = Random.Range(0, prefabEnemies.Length);
        GameObject go = Instantiate<GameObject>( prefabEnemies[ ndx ] );

        float enemyInset = enemyInsetDefault;
        if(go.GetComponent<BoundsCheck>() != null){
            enemyInset = Mathf.Abs( go.GetComponent<BoundsCheck>().radius );
        }

        Vector3 pos = Vector3.zero;
        float xMin = -bndCheck.camWidth + enemyInset;
        float xMax = bndCheck.camWidth - enemyInset;
        
        pos.x = Random.Range( xMin, xMax);
        pos.y = bndCheck.camHeight + enemyInset;
        go.transform.position = pos;

        Invoke( nameof(SpawnEnemy), 1f/enemySpawnPerSecond );
    }*/

    void restarting(){
        Restart();
    }

    void Upgrader(){
        if(Score >= 20){
            Score -=20;
            Playercharacter.speed += 2;
        }
    }



    void UpdateGUI() {
        ScoreBoard.text = "Score: "+Score;

    }

    void Update()
    {
        UpdateGUI();
    }


    void DelayedRestart(){
        Invoke( nameof(Restart), gameRestartDelay);
    }

    void Restart() {
        //Score = 0;
        SceneManager.LoadScene( "__Scene_0" );
    }

    static public void HERO_DIED() {
         
        S.DelayedRestart();
    }

    /*static public WeaponDefinition GET_WEAPON_DEFINITION( eWeaponType wt){
        if(WEAP_DICT.ContainsKey(wt)) {
            return(WEAP_DICT[wt]);
        }

        return( new WeaponDefinition() );
    }*/

    static public void ROCK_DESTORYED( Rocks e){

        
       

    }

    public static void AddScore(){
        Score +=10;

    }




}


