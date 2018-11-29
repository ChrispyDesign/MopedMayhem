using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {

	public Rigidbody m_ParentRigidBody;

	private void FixedUpdate()
	{
		transform.rotation = transform.parent.rotation;
	}
	
	// Lets hope we dont need this
	private void OnCollisionStay(Collision collision)
	{
		Debug.Log(collision.collider);

		Vector3 impulse = Vector3.zero;

		foreach (ContactPoint contact in collision.contacts)
		{
			Vector3 collisionNormal = contact.normal;
			//if (Vector3.Dot(contact.point, collisionNormal) > 0.0f)
			//{
			//	collisionNormal = -collisionNormal;
			//	Debug.Log("Inverting Normal");
			//}

			impulse += collisionNormal * contact.separation * Vector3.Dot(contact.point, collisionNormal);
		}
		impulse /= Time.fixedDeltaTime * collision.contacts.Length;

		m_ParentRigidBody.AddForce(impulse, ForceMode.Impulse);
	}
}
