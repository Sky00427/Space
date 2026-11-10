using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBombAbility : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private PlayerLevel playerLevel;

    [SerializeField]
    private InputActionReference bombAction;

    [SerializeField]
    private Transform firePos;

    [SerializeField]
    private GameObject bombPrefab;

    [Header("Unlock")]
    [SerializeField, Min(1)]
    private int unlockLevel = 5;

    [Header("Bomb")]
    [SerializeField, Min(0f)]
    private float cooldown = 5f;

    private float nextAvailableTime;

    public bool IsUnlocked =>
        playerLevel.CurrentLevel >= unlockLevel;

    public float CooldownRemaining =>
        Mathf.Max(0f, nextAvailableTime - Time.time);

    void OnEnable()
    {
        bombAction.action.performed += OnBombPerformed;
        bombAction.action.Enable();
    }

    void OnDisable()
    {
        bombAction.action.performed -= OnBombPerformed;
        bombAction.action.Disable();
    }

    void OnBombPerformed(
        InputAction.CallbackContext context
    )
    {
        TryUseBomb();
    }

    public void TryUseBomb()
    {
        if (!IsUnlocked)
        {
            Debug.Log(
                $"Bomb 將在 Lv.{unlockLevel} 解鎖。"
            );

            return;
        }

        if (Time.time < nextAvailableTime)
        {
            return;
        }

        nextAvailableTime = Time.time + cooldown;

        Instantiate(
            bombPrefab,
            firePos.position,
            firePos.rotation
        );
    }
}