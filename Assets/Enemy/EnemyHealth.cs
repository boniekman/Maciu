using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHP = 10;

    int currentHP = 0;
    MeshRenderer[] renderers;

    // Start is called before the first frame update
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
