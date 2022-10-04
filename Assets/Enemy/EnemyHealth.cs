using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHP = 10;

    [Tooltip("Adds amount to maxHP on enemy death")]
    [SerializeField] int difficultyRamp = 1;

    int currentHP = 0;
    MeshRenderer[] renderers;

    Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>(); 
    }
    void OnEnable()
    {
        currentHP = maxHP;
        renderers = GetComponentsInChildren<MeshRenderer>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        currentHP--;

        if (currentHP <= 0)
        {
            gameObject.SetActive(false);
            maxHP += difficultyRamp;
            //difficultyRamp++;
            enemy.RewardGold();
        }
        else
        {
            StartCoroutine(FlashRed());
        }
    }

    IEnumerator FlashRed()
    {
        foreach(var renderer in renderers)
        {
            renderer.material.color = Color.red;
            yield return new WaitForSeconds(.1f);
            renderer.material.color = Color.white;
        }
        
    }
}
