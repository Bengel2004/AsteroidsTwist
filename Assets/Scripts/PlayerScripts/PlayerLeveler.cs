using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeveler : MonoBehaviour
{
    public float GetScrap { get { return scrap; } }
    [SerializeField]
    private Sprite[] levelSprites;
    [SerializeField]
    private Weapon[] allWeapons;
    [SerializeField]
    private SpriteRenderer playerSpriteRenderer;
    [SerializeField]
    private int levelSpriteChangeModifier;

    private float scrap;
    private PlayerFire playerGunner;

    // Manages the current sprite progress of the player
    private void Start()
    {
        playerGunner = GetComponent<PlayerFire>();
    }

    private void Update()
    {
        // checks the current "level" of the player based on the amount of scrap he has collected
        int _tempFloat = Mathf.RoundToInt(scrap);
        _tempFloat = _tempFloat / levelSpriteChangeModifier;
        
        GameManager.playerLevel = _tempFloat < levelSprites.Length ? _tempFloat : (levelSprites.Length - 1);
        if (playerSpriteRenderer.sprite != levelSprites[GameManager.playerLevel] && GameManager.playerLevel < levelSprites.Length)
        {
            playerSpriteRenderer.sprite = levelSprites[GameManager.playerLevel];
            playerGunner.chosenWeapon = allWeapons[GameManager.playerLevel];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IPickable _tempPick = collision.gameObject.GetComponent<IPickable>();
        if (_tempPick != null)
            scrap = Mathf.Round(scrap + _tempPick.PickItem());
    }
}
