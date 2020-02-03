using Assets.Scripts;
using Assets.Scripts.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Entity
{
    public int defaultStr = 1;
    public int defaultInt = 1;
    public int defaultDex = 1;
    public int defaultCon = 1;

    public int level;
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
                if (getMP() >= w.quickSpell.cost)
                {
                    w.UseQuickSpell();
                    LoseMP(w.quickSpell.cost);
                }
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
        return GetStat(Stat.Str).GetValue();
    }
    public int getInt()
    {
        return GetStat(Stat.Int).GetValue();
    }
    public int getDex()
    {
        return GetStat(Stat.Dex).GetValue();
    }
    public int getCon()
    {
        return GetStat(Stat.Con).GetValue();
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

    public override void InitializeStats()
    {
        base.InitializeStats();
        foreach (EntityStat stat in stats)
        {
            if (stat.GetStat() == Stat.Str)
            {
                stat.SetValue(defaultStr);
            }
            if (stat.GetStat() == Stat.Int)
            {
                stat.SetValue(defaultInt);
            }
            if (stat.GetStat() == Stat.Con)
            {
                stat.SetValue(defaultCon);
            }
            if (stat.GetStat() == Stat.Dex)
            {
                stat.SetValue(defaultDex);
            }

            Debug.Log(stat.GetStat() + ": " + stat.GetValue());
        }
    }
}
