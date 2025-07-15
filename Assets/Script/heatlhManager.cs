using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthManager : MonoBehaviour
{
    public float healthAmount = 100f;
    public Image healthBar;

    private DiChuyenNhanVat player;

    void Start()
    {
        player = FindObjectOfType<DiChuyenNhanVat>();
    }

    void Update()
    {
        healthBar.fillAmount = healthAmount / 100f;

        // Gọi Die nếu máu hết
        if (healthAmount <= 0f)
        {
            if (player != null)
            {
                player.Die();
            }
        }
    }
    public void takeDamage(float damage)
    {
        healthAmount -= damage;
        healthAmount = Mathf.Clamp(healthAmount, 0f, 100f);
    }
}
    