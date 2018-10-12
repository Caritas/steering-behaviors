namespace IntroToGameDev.Steering
{
    using UnityEngine;

    public class VehicleManualMover : MonoBehaviour
    {
        [SerializeField]
        private float force = 5;
        
        private Vehicle vehicle;

        private void Awake()
        {
            vehicle = GetComponent<Vehicle>();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                vehicle.ApplyForce(Vector3.back * force);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                vehicle.ApplyForce(Vector3.forward * force);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                vehicle.ApplyForce(Vector3.right * force);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                vehicle.ApplyForce(Vector3.left * force);
            }

        }
    }
}