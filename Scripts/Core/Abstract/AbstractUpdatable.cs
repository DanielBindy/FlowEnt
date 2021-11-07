using System;

namespace FriedSynapse.FlowEnt
{
    /// <summary>
    /// Provides common options for behaviours that require frame update.
    /// </summary>
    public abstract class AbstractUpdatable : FastListItem<AbstractUpdatable>
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="AbstractUpdatable"/> class.
        /// </summary>
        protected AbstractUpdatable() : this(FlowEntController.Instance)
        {
        }

        private protected AbstractUpdatable(IUpdateController updateController)
        {
            Id = lastId;
            ++lastId;
            this.updateController = updateController;
#if FlowEnt_Debug
#if UNITY_EDITOR
            const int lineCountToHide = 5;
            string[] lines = Environment.StackTrace.Split('\n');
            int lineCount = lines.Length - lineCountToHide;
            string[] trimmedLines = new string[lineCount];
            Array.Copy(lines, lineCountToHide, trimmedLines, 0, lineCount);
            stackTrace = string.Join("\n", trimmedLines);
#else
            stackTrace = Environment.StackTrace;
#endif
#endif
        }

#if FlowEnt_Debug
        internal string stackTrace;
#endif

        //HACK for having a constructor that does nothing, to instantiate quicker when needed
#pragma warning disable RCS1163, IDE0060
        private protected AbstractUpdatable(int thisIsAnEmptyConstructorForAnchor)
#pragma warning restore RCS1163, IDE0060
        {
        }

        private static ulong lastId;
        /// <summary>
        /// A value used to identify the current updatable that is automatically assigned.
        /// </summary>
        /// <remarks>
        /// The value is generated and it automatically increments starting from 0.
        /// </remarks>
        public ulong Id { get; }

        /// <summary>
        /// A name that can be used to identify the animation. Empty by default.
        /// </summary>
        public string Name { get; set; }

        internal IUpdateController updateController;

        #region Events

        private protected Action onStarted;
        private protected Action<float> onUpdated;
        private protected Action onCompleted;

        #endregion

        internal abstract void StartInternal(float deltaTime = 0);
        internal abstract void UpdateInternal(float deltaTime);

        /// <summary>
        /// Stops the animation.
        /// </summary>
        /// <param name="triggerOnCompleted">If set to true will trigger the "OnCompleted" event on the animation</param>
        public virtual void Stop(bool triggerOnCompleted = false)
        {
        }
    }

    internal class UpdatableAnchor : AbstractUpdatable
    {
        private const string InvalidImplementation = "This method should not be called.";
        public UpdatableAnchor() : base(0)
        {
        }

        internal override void StartInternal(float deltaTime)
        {
            throw new InvalidOperationException(InvalidImplementation);
        }

        internal override void UpdateInternal(float deltaTime)
        {
            throw new InvalidOperationException(InvalidImplementation);
        }
    }
}
