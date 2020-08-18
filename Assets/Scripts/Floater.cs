using UnityEngine;
using UnityEngine.EventSystems;

public class Floater : MonoBehaviour
{

    [SerializeField] private Rigidbody RB;
    private float SubmergeHeight = 1f;
    private float BuoyMult = 1f;
    private float FloaterCount = 4;
    private float WaterLinearDrag = 0.99f;
    private float WaterAngularDrag = 0.99f;

    void FixedUpdate()
    {
        RB.AddForceAtPosition(Physics.gravity / FloaterCount, transform.position);
        float WaveHeight = WaveManager.Instance.GetWaveHeight(transform.position.x, transform.position.z);
        if (transform.position.y < WaveHeight)
        {
            float BuoyFraction = Mathf.Clamp01((WaveHeight - transform.position.y) / SubmergeHeight);
            RB.AddForceAtPosition(-Physics.gravity * BuoyFraction * BuoyMult, transform.position, ForceMode.Acceleration);
            RB.AddForce(BuoyMult * BuoyFraction * - RB.velocity * WaterLinearDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            RB.AddTorque(BuoyMult * BuoyFraction * -RB.velocity * WaterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
}
