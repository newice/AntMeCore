﻿using System;

namespace AntMe
{
    /// <summary>
    /// Empty Base Class for all Factory Interops.
    /// </summary>
    public abstract class FactoryInterop : Interop
    {
        /// <summary>
        /// Protected Reference to the related Faction.
        /// </summary>
        protected readonly Faction Faction;

        /// <summary>
        /// Current Game Round.
        /// </summary>
        public int Round { get; private set; }

        /// <summary>
        /// Current Game Time (based on the Frames Per Second Constant).
        /// </summary>
        public TimeSpan GameTime { get; private set; }

        /// <summary>
        /// Default Constructor for the Type Mapper.
        /// </summary>
        /// <param name="faction">Instance of the related Faction</param>
        public FactoryInterop(Faction faction)
        {
            if (faction == null)
                throw new ArgumentNullException("faction");

            // Faction soll bereits teil eines Levels sein.
            if (faction.Level == null)
                throw new ArgumentException("Faction is not Part of a Level");

            Faction = faction;
        }

        /// <summary>
        /// Updates the current Interop.
        /// </summary>
        protected override void OnUpdate()
        {
            Round = Faction.Level.Round;
            GameTime = TimeSpan.FromSeconds((double)Round / Level.FRAMES_PER_SECOND);
            base.OnUpdate();
        }
    }
}
