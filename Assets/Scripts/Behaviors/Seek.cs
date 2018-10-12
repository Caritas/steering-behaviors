namespace IntroToGameDev.Steering.Behaviors
{
    using UnityEngine;

    public class Seek : DesiredVelocityProvider
    {
        [SerializeField]
        private Transform objectToFollow;
        
        public override Vector3 GetDesiredVelocity()
        {
            return (objectToFollow.position - transform.position).normalized * Vehicle.VelocityLimit;
        }
    }
}