using UnityEngine;
using UnityEngine.UI;

namespace FlowEnt.Motions.Graphics
{
    public class ColorMotion<TGraphic> : AbstractMotion<TGraphic>
        where TGraphic : Graphic
    {
        public ColorMotion(TGraphic item, Color value) : base(item)
        {
            Value = value;
        }

        public Color Value { get; }
        public Color? From { get; private set; }
        public Color? To { get; private set; }

        public override void OnStart()
        {
            From = Item.color;
            To = From + Value;
        }

        public override void OnUpdate(float t)
        {
            Item.color = Color.Lerp(From.Value, To.Value, t);
        }
    }
}