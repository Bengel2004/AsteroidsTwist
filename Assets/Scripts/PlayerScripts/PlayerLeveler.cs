using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeveler : MonoBehaviour
{
    [SerializeField]
    private Sprite[] levelSprites;
    [SerializeField]
    private Weapon[] allWeapons;
    [SerializeField]
    private SpriteRenderer playerSpriteRenderer;
    [SerializeField]
    private int levelSpriteChangeModifier;

    private int scrap;

    private PlayerFire playerGunner;

    // Manages the current sprite progress of the player
    private void Start()
    {
        playerGunner = GetComponent<PlayerFire>();
    }

    private void Update()
    {
        Debug.Log(scrap);
        int _tempValue = Mathf.RoundToInt(ScoreManager.Instance.getPoints());
        _tempValue = _tempValue / levelSpriteChangeModifier;
        if (playerSpriteRenderer.sprite != levelSprites[_tempValue] && _tempValue < levelSprites.Length)
        {
            playerSpriteRenderer.sprite = levelSprites[_tempValue];
            playerGunner.chosenWeapon = allWeapons[_tempValue];
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //float flap = scrap == 1 ? 0 : (true ? 1 : 2);
        //if (scrap == 1)
        //{
        //    flap = 0;
        //} else {
        //    if (true)
        //    {
        //        flap = 1;

        //    }
        //    else
        //    {
        //        flap = 2;
        //    }
        //}
        IPickable _tempPick = collision.gameObject.GetComponent<IPickable>();
        _tempPick?.PickItem();
    }
}
