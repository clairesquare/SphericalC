using UnityEngine;
using System.Collections;

public class MeshColliderScript : MonoBehaviour {

	MeshCollider meshCollider;
	SkinnedMeshRenderer skinnedMeshRenderer;
	Mesh colliderMesh;

	void Start () {
		// The mesh collider was showing up as being much bigger than the model itself.
		// I had to put the collider on a child object so that I could change it's scale.
		meshCollider = GetComponentInChildren<MeshCollider> ();
		skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer> ();
		colliderMesh = new Mesh ();
	}

	void Update () {
		// This creates a new mesh from the current position of the character model
		skinnedMeshRenderer.BakeMesh(colliderMesh);
		// Assign the new mesh to the mesh collider
		meshCollider.sharedMesh = colliderMesh;
	}
}
