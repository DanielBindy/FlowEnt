using UnityEngine;
using FriedSynapse.FlowEnt.Motions.Lights;

namespace FriedSynapse.FlowEnt
{
    public static class LightMotionExtensions
    {
        #region Intensity

        public static TweenMotion<Light> Intensity(this TweenMotion<Light> motion, float value)
            => motion.Apply(new IntensityMotion(motion.Item, value));

        public static TweenMotion<Light> IntensityTo(this TweenMotion<Light> motion, float to)
            => motion.Apply(new IntensityToMotion(motion.Item, to));

        public static TweenMotion<Light> IntensityTo(this TweenMotion<Light> motion, float from, float to)
            => motion.Apply(new IntensityToMotion(motion.Item, from, to));

        #endregion

        #region Color

        public static TweenMotion<Light> Color(this TweenMotion<Light> motion, Color value)
            => motion.Apply(new ColorMotion(motion.Item, value));

        public static TweenMotion<Light> ColorTo(this TweenMotion<Light> motion, Color to)
            => motion.Apply(new ColorToMotion(motion.Item, to));

        public static TweenMotion<Light> ColorTo(this TweenMotion<Light> motion, Color from, Color to)
            => motion.Apply(new ColorToMotion(motion.Item, from, to));

        #endregion
    }
}