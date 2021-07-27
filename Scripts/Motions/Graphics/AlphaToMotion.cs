using UnityEngine;
using UnityEngine.UI;

namespace FlowEnt.Motions.Graphics
{
    public class AlphaToMotion<TGraphic> : AbstractMotion<TGraphic>
         where TGraphic : Graphic
    {
        public AlphaToMotion(TGraphic item, float to) : base(item)
        {
            To = to;
        }

        public AlphaToMotion(TGraphic item, float from, float to) : this(item, to)
        {
            From = from;
        }

        public float? From { get; private set; }
        public float To { get; }
        private Color color;

        public override void OnStart()
        {
            if (From == null)
            {
                From = Item.color.a;
            }
            else
            {
                Color color = Item.color;
                color.a = From.Value;
                Item.color = color;
            }
        }

        public override void OnUpdate(float t)
        {
            color = Item.color;
            color.a = Mathf.Lerp(From.Value, To, t);
            Item.color = color;
        }
    }
}