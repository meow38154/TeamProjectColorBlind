using UnityEngine;

public class HealthBySize : MonoBehaviour
{
    [SerializeField] private HealthSystem _healthSystem;

    private void Start()
    {
        _healthSystem.OnGetDamage += SizeUpdate;
    }
    private void SizeUpdate(int a, Transform b)
    {
        float currentPer = (float)_healthSystem.CurrentHealth / (float)_healthSystem.MaxHealth;
        Debug.Log(currentPer);
        transform.localScale = new Vector3(3.25f * currentPer, transform.localScale.y, transform.localScale.z);
    }
}
