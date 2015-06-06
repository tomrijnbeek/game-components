﻿using System.Collections.Generic;
using System.Linq;

namespace GameComponents
{
    /// <summary>
    /// A game object represents an object in the game of which the behaviour is completely decided by its components.
    /// </summary>
    public sealed class GameObject
    {
        private readonly List<IGameComponent> components = new List<IGameComponent>();

        /// <summary>
        /// Updates the game object.
        /// </summary>
        /// <param name="dt">The amount of time passed since the last update call.</param>
        public void Update(float dt)
        {
            foreach (var c in this.components)
                c.Update(dt);
        }

        /// <summary>
        /// Adds a new component to the game object.
        /// </summary>
        /// <param name="component">The component to be added.</param>
        public void AddComponent(IGameComponent component)
        {
            this.components.Add(component);
        }

        /// <summary>
        /// Removes a component from the game object.
        /// </summary>
        /// <param name="component">The component to be removed.</param>
        /// <returns>True if the component is succesfully removed; false otherwise. Also returns false if the component was not present.</returns>
        public bool RemoveComponent(IGameComponent component)
        {
            return this.components.Remove(component);
        }

        /// <summary>
        /// Removes all components of a specified type from the game object.
        /// </summary>
        /// <typeparam name="T">The type of components to remove.</typeparam>
        /// <returns>The amount of components removed.</returns>
        public int RemoveComponents<T>()
        {
            return this.components.RemoveAll(c => c is T);
        }

        /// <summary>
        /// Gets the first component of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the component to retrieve.</typeparam>
        /// <returns>The first component of the specified type if it exists, null otherwise.</returns>
        public T GetComponent<T>() where T : IGameComponent
        {
            return (T)this.components.First(c => c is T);
        }

        /// <summary>
        /// Gets all components of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the components to retrieve.</typeparam>
        /// <returns>A list of all components of the specified type.</returns>
        public List<T> GetComponents<T>() where T : IGameComponent
        {
            return this.components.OfType<T>().ToList();
        }
    }
}