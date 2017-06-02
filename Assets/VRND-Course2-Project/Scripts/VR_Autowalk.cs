using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class VR_Autowalk : MonoBehaviour {

	// How fast to move
	public float speed = 3.0f;
	// Should I move forward or not
	public bool moveForward;
	// CharacterController script
	private CharacterController controller;
	// GvrViewer Script
	private GvrViewer gvrViewer;
	// VR Head
	private Transform vrHead;

	// Use this for initialization
	void Start () {
		// Find the CharacterController
		controller = GetComponent<CharacterController>();
		// Find the GvrViewer on child 0
		gvrViewer = transform.GetChild(0).GetComponent<GvrViewer>();
		// Find the VR Head
		vrHead = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {

		// If the Google VR button, or the Gear VR touchpad is pressed

		if (Input.GetButtonDown("Fire1")){
			// Change the state of moveForward
			moveForward = !moveForward;
		}


		// Check to see if I should move
		if (moveForward) {
			// Find the foreward direction
			Vector3 forward = vrHead.TransformDirection(Vector3.forward);
			// Tell CharacterController to move forward
			controller.SimpleMove(forward * speed);
			}
	
	}

	void LateUpdate() {
    GvrViewer.Instance.UpdateState();
    if (GvrViewer.Instance.BackButtonPressed) {
      Application.Quit();
    }
  }
}
