using System;
using UnityEngine;


namespace UnityStandardAssets.Utility
{
    public class FollowTarget : MonoBehaviour
    {
		[SerializeField] private Transform target;
        [SerializeField] private Vector3 posOffset = new Vector3(0f, 0f, 0f);
        [SerializeField] private Vector3 rotOffset = new Vector3(0f, 0f, 0f);
		[SerializeField] private bool isFollowRotation;

        private void LateUpdate()
        {
            transform.position = target.position + posOffset;

            if (isFollowRotation)
                transform.Rotate(
                    new Vector3(
                        transform.rotation.x, 
                        transform.rotation.y, 
                        transform.rotation.z) + rotOffset);
        }
    }
}
