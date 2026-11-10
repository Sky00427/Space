using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerOverloadAbility : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private PlayerLevel playerLevel;

    [SerializeField]
    private InputActionReference overloadAction;

    [SerializeField]
    private Transform firePos;

    [SerializeField]
    private GameObject laserPrefab;

    [Header("Unlock")]
    [SerializeField, Min(1)]
    private int unlockLevel = 10;

    [Header("Cooldown")]
    [SerializeField, Min(0f)]
    private float cooldown = 10f;

    private float nextAvailableTime;
    private GameObject activeLaser;

    public bool IsUnlocked =>
        playerLevel.CurrentLevel >= unlockLevel;

    public float CooldownRemaining =>
        Mathf.Max(0f, nextAvailableTime - Time.time);

    void OnEnable()
    {
        overloadAction.action.performed +=
            OnOverloadPerformed;

        overloadAction.action.Enable();
    }

    void OnDisable()
    {
        overloadAction.action.performed -=
            OnOverloadPerformed;

        overloadAction.action.Disable();

        if (activeLaser != null)
        {
            Destroy(activeLaser);
        }
    }

    void OnOverloadPerformed(
        InputAction.CallbackContext context
    )
    {
        TryActivateOverload();
    }

    public void TryActivateOverload()
    {
        if (!IsUnlocked)
        {
            Debug.Log(
                $"Overload 將在 Lv.{unlockLevel} 解鎖。"
            );

            return;
        }

        if (activeLaser != null)
        {
            return;
        }

        if (Time.time < nextAvailableTime)
        {
            return;
        }

        nextAvailableTime = Time.time + cooldown;

        activeLaser = Instantiate(
            laserPrefab,
            firePos
        );

        activeLaser.transform.localPosition =
            Vector3.zero;

        activeLaser.transform.localRotation =
            Quaternion.identity;
    }
}