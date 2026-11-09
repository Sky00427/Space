using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerInvincibility : MonoBehaviour
{
    [Header("Invincibility")]
    [SerializeField, Min(0f)]
    private float invincibleDuration = 2f;

    [SerializeField, Min(0.05f)]
    private float blinkInterval = 0.1f;

    [SerializeField]
    private SpriteRenderer playerSpriteRenderer;

    [SerializeField]
    private bool isInvincible;

    private int normalLayer;
    private int invincibleLayer;
    private Coroutine invincibilityCoroutine;

    public bool IsInvincible => isInvincible;

    void Awake()
    {
        if (playerSpriteRenderer == null)
        {
            playerSpriteRenderer =
                GetComponent<SpriteRenderer>();
        }

        normalLayer = gameObject.layer;

        invincibleLayer =
            LayerMask.NameToLayer(
                "PlayerInvincible"
            );

        if (invincibleLayer == -1)
        {
            Debug.LogError(
                "PlayerInvincible Layer 尚未建立。"
            );
        }
    }

    public void Activate()
    {
        if (isInvincible || invincibleLayer == -1) return;

        invincibilityCoroutine = StartCoroutine(InvincibilityRoutine());
    }

    IEnumerator InvincibilityRoutine()
    {
        isInvincible = true;
        gameObject.layer = invincibleLayer;

        float elapsedTime = 0f;

        while (elapsedTime < invincibleDuration)
        {
            playerSpriteRenderer.enabled = false;

            yield return new WaitForSeconds(
                blinkInterval
            );

            elapsedTime += blinkInterval;
            playerSpriteRenderer.enabled = true;

            yield return new WaitForSeconds(
                blinkInterval
            );

            elapsedTime += blinkInterval;
        }

        RestoreState();
    }

    void RestoreState()
    {
        playerSpriteRenderer.enabled = true;
        gameObject.layer = normalLayer;
        isInvincible = false;
        invincibilityCoroutine = null;
    }

    void OnDisable()
    {
        if (invincibilityCoroutine != null)
        {
            StopCoroutine(invincibilityCoroutine);
        }

        if (playerSpriteRenderer != null)
        {
            RestoreState();
        }
    }
}