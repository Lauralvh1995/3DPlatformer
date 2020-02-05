using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBarController : MonoBehaviour
{
    public GameManager manager;

    public Slider HPslider;
    public Slider MPslider;

    public Text HPText;
    public Text MPText;

    private void Start()
    {
        manager = GetComponent<GameManager>();
    }

    private void Update()
    {
        HPslider.value = manager.player.getHP() / (float)manager.player.getMHP();
        MPslider.value = manager.player.getMP() / (float)manager.player.getMMP();

        HPText.text = manager.player.getHP() + "/" + manager.player.getMHP();
        MPText.text = manager.player.getMP() + "/" + manager.player.getMMP();
    }
}
