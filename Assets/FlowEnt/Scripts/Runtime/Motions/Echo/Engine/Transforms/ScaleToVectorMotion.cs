using FriedSynapse.FlowEnt.Motions.Echo.Abstract;
using UnityEngine;

namespace FriedSynapse.FlowEnt.Motions.Echo.Transforms
{
    /// <summary>
    /// Scales the transform towards the target using the deltaTime as a step. 
    /// </summary>
    /// <typeparam name="TTransform"></typeparam>
    public class ScaleToVectorMotion<TTransform> : AbstractEchoMotion<TTransform>
        where TTransform : Transform
    {
#pragma warning disable RCS1158
        public const float DefaultSpeed = 1f;
        public const SpeedType DefaultSpeedType = SpeedType.Linear;
#pragma warning restore RCS1158

        public ScaleToVectorMotion(TTransform item, Vector3 target, float speed = DefaultSpeed, SpeedType speedType = DefaultSpeedType) : base(item)
        {
            this.target = target;
            this.speedType = speedType;
            this.speed = speed;
        }

        protected Vector3 target;
        private readonly SpeedType speedType;
        private readonly float speed;

        public override void OnUpdate(float deltaTime)
        {
            float speed = 0;
            switch (speedType)
            {
                case SpeedType.Linear:
                    speed = this.speed;
                    break;
                case SpeedType.Elastic:
                    speed = this.speed * (item.localScale.magnitude / target.magnitude);
                    break;
                case SpeedType.Gravity:
                    speed = this.speed * (target.magnitude / item.localScale.magnitude);
                    break;
            }

            item.localScale = Vector3.MoveTowards(item.localScale, target, speed * deltaTime);
        }
    }
}