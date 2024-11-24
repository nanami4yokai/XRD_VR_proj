using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRRig : MonoBehaviour
{
    public VRMap head;
    public VRMap leftHand;
    public VRMap rightHand;

    public Transform headConstraint;
    public Vector3 headBodyOffset;

    // Start is called before the first frame update
    void Start()
    {
        headBodyOffset = transform.position - headConstraint.position;
        Debug.Log("Initial head body offset: " + headBodyOffset);
    }

    // void LateUpdate()
    // {
    //     // Update the VR Rig's position based on the head's target position, maintaining the initial offset
    //     transform.position = head.vrTarget.position + headBodyOffset;

    //     // Extract the yaw (Y-axis rotation) from the VR headset's orientation for smoother rig rotation
    //     float yaw = head.vrTarget.eulerAngles.y;

    //     // Interpolate the rig's rotation based on the yaw to avoid sudden rotation changes
    //     transform.rotation = Quaternion.Lerp(
    //         transform.rotation,
    //         Quaternion.Euler(0, yaw, 0), // Only update the Y-axis for the rotation
    //         Time.deltaTime * 5f // Adjust for smoother or faster interpolation
    //     );

    //     // Map the positions and rotations of the head and controllers
    //     head.Map();
    //     leftHand.Map();
    //     rightHand.Map();
    // }

    void LateUpdate()
    {
        // Adjust this to keep the Y-axis fixed if necessary
        transform.position = new Vector3(
            head.vrTarget.position.x + headBodyOffset.x,
            transform.position.y, // Maintain the current Y position
            head.vrTarget.position.z + headBodyOffset.z
        );

        float yaw = head.vrTarget.eulerAngles.y;
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.Euler(0, yaw, 0), // Only rotate on the Y-axis
            Time.deltaTime * 5f
        );

        head.Map();
        leftHand.Map();
        rightHand.Map();
    }


}
