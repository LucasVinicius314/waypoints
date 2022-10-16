using UnityEngine;

#nullable enable

public class PlayerScript : MonoBehaviour
{
  [Min(0f)]
  [SerializeField]
  float movementSpeed = 1f;

  CharacterController? controller;

  void HandleMovement(CharacterController controller)
  {
    var x = Input.GetAxis("Horizontal") * Vector3.right;
    var z = Input.GetAxis("Vertical") * Vector3.forward;

    var input = Vector3.ClampMagnitude(x + z, 1f) * movementSpeed;

    controller.SimpleMove(input);
  }

  void Awake()
  {
    controller = GetComponent<CharacterController>();
  }

  void Update()
  {
    if (controller != null)
    {
      HandleMovement(controller: controller);
    }
  }
}
