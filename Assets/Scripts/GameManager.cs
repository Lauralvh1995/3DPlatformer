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

    }
}
