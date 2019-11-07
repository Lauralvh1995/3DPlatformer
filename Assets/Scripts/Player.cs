using Assets.Scripts;
using Assets.Scripts.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Entity
{
    public int strength;
    public int intelligence;
    public int dexterity;
    public int constitution;

    public List<Item> inventory;

    public Light ghostLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Die()
    {
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
    }

    public int getStr()
    {
        return strength;
    }
    public int getInt()
    {
        return intelligence;
    }
    public int getDex()
    {
        return dexterity;
    }
    public int getCon()
    {
        return constitution;
    }
}
