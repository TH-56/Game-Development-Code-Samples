using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    [Header("Attributes:")]
    [SerializeField] private int health = 3;
    [SerializeField] private bool nonDestructable;
    [SerializeField] private float lightIntensity;
    [SerializeField] private float lightRadius;
    [SerializeField] private bool isBarrier;
    [HideInInspector] private string name;
    [HideInInspector] private bool hasLighting;
    [HideInInspector] private bool rewardSpawned = false;

    [Header("Components:")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private BoxCollider2D boxCollider2D;
    [SerializeField] private GameObject hitFeedback, destroyFeedback, lighting;

    public void Initialize(ItemData itemData)
    {
        spriteRenderer.sprite = itemData.sprite;
        spriteRenderer.transform.localPosition = new Vector2(0.5f * itemData.size.x, 0.5f * itemData.size.y);
        lighting.transform.localPosition = new Vector2(0.5f * itemData.size.x, 0.5f * itemData.size.y);
        boxCollider2D.size = itemData.size;
        boxCollider2D.offset = spriteRenderer.transform.localPosition;
        this.health = itemData.health;
        this.name = itemData.name;
        this.hasLighting = itemData.hasLighting;
        this.lightIntensity = itemData.lightIntensity;
        this.lightRadius = itemData.lightRadius;

        if (itemData.nonDestructable)
        {
            this.nonDestructable = true;
        }
    }

    public void GetHit(int damage, GameObject damageDealer)
    {
        if(nonDestructable)
        {
            return;
        }

        spriteRenderer.transform.DOShakePosition(0.2f, 0.3f, 75, 1, false, true).OnComplete(ReduceHealth);
    }

    private void ReduceHealth()
    {
        health--;
        
        if(health <= 0)
        {
            if(!rewardSpawned)
                SpawnReward();

            spriteRenderer.transform.DOComplete();
            Destroy(gameObject);
        }
    }

    public int GetHealth()
    {
        return health;
    }

    public string GetName()
    {
        return name;
    }

    private void SpawnReward()
    {
        rewardSpawned = true;
        GetComponent<LootBag>().InstantiateLoot(transform.position);
    }
}