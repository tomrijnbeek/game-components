using System;

namespace GameComponents
{
    /// <summary>
    /// The interface for game components that can be added to a game object.
    /// </summary>
    public abstract class GameComponent
    {
        private GameObject gameObject;

        /// <summary>
        /// Return the game object this component belongs to.
        /// </summary>
        /// <value>The game object this component belongs to.</value>
        protected GameObject GameObject { get { return this.gameObject; } }

        internal void SetGameObject(GameObject gameObject)
        {
            if (this.gameObject != null)
                throw new InvalidOperationException("Can not assign a game object to a component a second time.");

            this.gameObject = gameObject;
        }

        /// <summary>
        /// The update method that should be called every frame.
        /// </summary>
        /// <param name="dt">The amount of time passed since the last update call.</param>
        public void Update(float dt);
    }
}