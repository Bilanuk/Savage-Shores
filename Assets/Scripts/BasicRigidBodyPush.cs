﻿using UnityEngine;
using Unity.Netcode;
using System.Collections;

public class BasicRigidBodyPush : NetworkBehaviour
{
	public LayerMask pushLayers;
	public bool canPush;
	[Range(0.5f, 5f)] public float strength = 1.1f;

	private float cooldownTime = 0.3f;
    private bool isCooldown = false;

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (canPush) PushRigidBodies(hit);
	}

	private void PushRigidBodies(ControllerColliderHit hit)
	{
		if (isCooldown) { return; }
		// https://docs.unity3d.com/ScriptReference/CharacterController.OnControllerColliderHit.html

		// make sure we hit a non kinematic rigidbody
		Rigidbody body = hit.collider.attachedRigidbody;
		if (body == null || body.isKinematic) return;

		// make sure we only push desired layer(s)
		var bodyLayerMask = 1 << body.gameObject.layer;
		if ((bodyLayerMask & pushLayers.value) == 0) return;

		// We dont want to push objects below us
		if (hit.moveDirection.y < -0.3f) return;

		// Calculate push direction from move direction, horizontal motion only
		Vector3 pushDir = new Vector3(hit.moveDirection.x, 0.0f, hit.moveDirection.z);
		var hitSerialized = new NetworkObjectReference(hit.gameObject.GetComponent<NetworkObject>());

		PushRigidBodiesServerRPC(hitSerialized, pushDir);
		StartCoroutine(StartCooldown());
	}

	[ServerRpc(RequireOwnership = false)]
	public void PushRigidBodiesServerRPC(NetworkObjectReference hitReference, Vector3 pushDir)
	{
		if(!hitReference.TryGet(out NetworkObject hit)) { return; }

		// Apply the push and take strength into account

		var body = hit.GetComponent<Rigidbody>();
		body.AddForce(pushDir * strength, ForceMode.Impulse);


		Debug.Log($"Pushing {hit.name} with {pushDir} and {strength}");
	}

	private IEnumerator StartCooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isCooldown = false;
    }
}