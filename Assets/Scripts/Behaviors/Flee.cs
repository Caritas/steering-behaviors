namespace IntroToGameDev.Steering.Behaviors
{
    using UnityEngine;

    public class Flee : DesiredVelocityProvider
    {
        [SerializeField]
        private Transform objectToFlee;
        
        public override Vector3 GetDesiredVelocity()
        {
            return -(objectToFlee.position - transform.position).normalized * Vehicle.VelocityLimit;
        }
    }
}