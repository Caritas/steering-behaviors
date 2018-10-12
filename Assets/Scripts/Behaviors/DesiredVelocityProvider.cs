namespace IntroToGameDev.Steering.Behaviors
{
    using UnityEngine;

    public abstract class DesiredVelocityProvider : MonoBehaviour
    {
        protected Vehicle Vehicle;

        private void Awake()
        {
            Vehicle = GetComponent<Vehicle>();
        }

        public abstract Vector3 GetDesiredVelocity();
    }
}