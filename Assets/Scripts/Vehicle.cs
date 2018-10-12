namespace IntroToGameDev.Steering
{
    using UnityEngine;

    public class Vehicle : MonoBehaviour
    {
        private Vector3 velocity;

        private Vector3 acceleration;

        [SerializeField]
        private float mass = 1;

        [SerializeField, Range(1, 10)]
        private float velocityLimit = 3;

        private const float Epsilon = 0.01f;

        public void ApplyForce(Vector3 force)
        {
            force /= mass;
            acceleration += force;
        }

        private void Update()
        {
            ApplyFriction();
            
            ApplyForces();

            void ApplyFriction()
            {
                var friction = -velocity.normalized * 0.5f;
                ApplyForce(friction);
            }

            void ApplyForces()
            {
                velocity += acceleration * Time.deltaTime;
            
                //limit velocity
                velocity = Vector3.ClampMagnitude(velocity, velocityLimit);

                //on small values object might start to blink, so we considering 
                //small velocities as zeroes
                if (velocity.magnitude < Epsilon)
                {
                    velocity = Vector3.zero;
                    return;
                }
            
                transform.position += velocity * Time.deltaTime;
                acceleration = Vector3.zero;
                transform.rotation = Quaternion.LookRotation(velocity);
            }
        }

        
    }
}