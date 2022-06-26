using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Antarsoft
public class CameraFollow : MonoBehaviour{
    [SerializeField] Transform toFollow = default;
    [SerializeField] Vector3 offset = default;
    [SerializeField] Vector3 minValue = default;
    [SerializeField] Vector3 maxValue = default;

    [Range(1,10)]
    [SerializeField] float smoothFactor = default;

    private void FixedUpdate() {
        Follow();
    }

    private void Follow(){
        Vector3 targetPosition = toFollow.position + offset;
        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(targetPosition.x, minValue.x, maxValue.x),
            Mathf.Clamp(targetPosition.y, minValue.y, maxValue.y),
            offset.z
        );

        Vector3 smoothPosition = Vector3.Lerp(transform.position, 
                                    boundPosition, smoothFactor*Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}
