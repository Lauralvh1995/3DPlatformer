﻿using Assets.Scripts;
using Assets.Scripts.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Entity
{
    public int level;
    public int strength;
    public int intelligence;
    public int dexterity;
    public int constitution;

    public List<Item> inventory;

    public Light ghostLight;
    // Start is called before the first frame update
    void Awake()
    {
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlots)).Length;
        equipment = new Equipment[numSlots];
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(equipment[0] is Weapon)
            {
                Weapon w = equipment[0] as Weapon;
                w.UseQuickSpell();
            }
        }
    }
    public override void Die()
    {
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
    }
    public int getLvl()
    {
        return level;
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
    public override void Equip(Equipment e)
    {
        int slot = (int)e.slot;
        if (equipment[slot] != null)
        {
            inventory.Add(equipment[slot]);
            equipment[slot].Unequip(this);
            equipment[slot] = null;
        }
        equipment[slot] = e;
        equipment[slot].Equip(this);
    }
}
