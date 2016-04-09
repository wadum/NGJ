using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class DroneMovement : MonoBehaviour {

    public Rigidbody2D Drone;

    public Thruster LeftThruster;
    public Thruster RightThruster;

    public KeyCode LeftBoost;
    public KeyCode RightBoost;

    public KeyCode ToggleThrusters;

    public float BaseForce;
    public float BoostForce;
    public float HoverForce;
    public float HoverDistance;
    public float TimeToMaxBoost;
    public float TimeToBaseBoost;

    public float DroneDrag;
    public float DroneWeight;
    public float ThrusterDrag;
    public float ThrusterWeight;

    private void Start () {
        Drone.drag = DroneDrag;
        Drone.mass = DroneWeight;

        LeftThruster.SetThrusterDrag(ThrusterDrag);
        LeftThruster.SetThrusterMass(ThrusterWeight);
        LeftThruster.SetBaseThrust(BaseForce);
        LeftThruster.SetBoostThrust(BoostForce);
        LeftThruster.SetTimeToMaxBoost(TimeToMaxBoost);
        LeftThruster.SetTimeToBase(TimeToBaseBoost);
        LeftThruster.SetHoverThrust(HoverForce);
        LeftThruster.SetHoverDistance(HoverDistance);

        RightThruster.SetThrusterDrag(ThrusterDrag);
        RightThruster.SetThrusterMass(ThrusterWeight);
        RightThruster.SetBaseThrust(BaseForce);
        RightThruster.SetBoostThrust(BoostForce);
        RightThruster.SetTimeToMaxBoost(TimeToMaxBoost);
        RightThruster.SetTimeToBase(TimeToBaseBoost);
        RightThruster.SetHoverThrust(HoverForce);
        RightThruster.SetHoverDistance(HoverDistance);

        LeftThruster.SetEngine(true);
        RightThruster.SetEngine(true);
    }

    private void Update () {
        if (Input.GetKeyDown(LeftBoost))
            LeftThruster.SetBoost(true);
        if (Input.GetKeyUp(LeftBoost))
            LeftThruster.SetBoost(false);

        if (Input.GetKeyDown(RightBoost))
            RightThruster.SetBoost(true);
        if (Input.GetKeyUp(RightBoost))
            RightThruster.SetBoost(false);

        if (Input.GetKeyDown(ToggleThrusters)) {
            LeftThruster.ToggleEngine();
            RightThruster.ToggleEngine();
        }
    }
}