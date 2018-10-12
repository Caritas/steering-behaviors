﻿namespace IntroToGameDev.Steering
{
    using Behaviors;
    using UnityEngine;

    public class Vehicle : MonoBehaviour
    {
        private Vector3 velocity;

        private Vector3 acceleration;

        [SerializeField]
        private float mass = 1;

        [SerializeField, Range(1, 20)]
        private float velocityLimit = 3;

        [SerializeField, Range(1, 20)]
        private float steeringForceLimit = 5;           

        private const float Epsilon = 0.01f;

        public float VelocityLimit => velocityLimit;

        public void ApplyForce(Vector3 force)
        {
            force /= mass;
            acceleration += force;
        }

        private void Update()
        {
            ApplyFriction();

            ApplySteeringForce();
            
            ApplyForces();

            void ApplyFriction()
            {
                var friction = -velocity.normalized * 0.5f;
                ApplyForce(friction);
            }

            void ApplySteeringForce()
            {
                var provider = GetComponent<DesiredVelocityProvider>();
                if (provider == null)
                {
                    return;
                }

                var desiredVelocity = provider.GetDesiredVelocity();// 
                var steeringForce = desiredVelocity - velocity;
                
                ApplyForce(steeringForce.normalized * steeringForceLimit);
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