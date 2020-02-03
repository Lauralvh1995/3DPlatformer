using Assets.Scripts.ScriptableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        #region Singleton
        public static GameManager instance;
        public void Awake()
        {
            instance = this;
            player = FindObjectOfType<Player>();
            DontDestroyOnLoad(this.gameObject);
        }
        #endregion
        public List<SpellEffect> spellEffects;
        public Player player;

        public Transform weaponAttachPoint;

        public EntityStat[] playerStats;
        public Equipment[] defaultEquipment;

        private void Start()
        {
            player = FindObjectOfType<Player>();

            foreach(EntityStat s in playerStats)
            {
                player.stats.Add(s);
            }
            player.InitializeStats();
            foreach(Equipment e in defaultEquipment)
            {
                player.Equip(e);
            }

        }

    }
}
