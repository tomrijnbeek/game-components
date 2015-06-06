using System;
using System.Collections.Generic;
using System.Linq;

namespace GameComponents
{
    /// <summary>
    /// A game object represents an object in the game of which the behaviour is completely decided by its components.
    /// </summary>
    public sealed class GameObject
    {
        //private readonly List<IGameComponent> components = new List<IGameComponent>();
        private readonly LinkedList<IGameComponent> componentList = new LinkedList<IGameComponent>();
        private readonly Dictionary<Type, List<LinkedListNode<IGameComponent>>> componentDict = new Dictionary<Type, List<LinkedListNode<IGameComponent>>>(); 

        /// <summary>
        /// Updates the game object.
        /// </summary>
        /// <param name="dt">The amount of time passed since the last update call.</param>
        public void Update(float dt)
        {
            foreach (var c in this.componentList)
                c.Update(dt);
        }

        /// <summary>
        /// Adds a new component of the specified type to the game object.
        /// </summary>
        /// <typeparam name="T">The type of component to be added.</typeparam>
        /// <returns>The added component.</returns>
        public T AddComponent<T>() where T : IGameComponent, new()
        {
            T ret;
            this.AddComponent(ret = new T());
            return ret;
        }

        /// <summary>
        /// Adds an existing component to the game object.
        /// </summary>
        /// <param name="component">The component to be added.</param>
        public void AddComponent(IGameComponent component)
        {
            var node = this.componentList.AddLast(component);
            var type = component.GetType();
            List<LinkedListNode<IGameComponent>> list;
            if (this.componentDict.TryGetValue(type, out list))
                list.Add(node);
            else
                componentDict.Add(type, new List<LinkedListNode<IGameComponent>> { node });
        }

        /// <summary>
        /// Removes a component from the game object.
        /// </summary>
        /// <param name="component">The component to be removed.</param>
        /// <returns>True if the component is succesfully removed; false otherwise. Also returns false if the component was not present.</returns>
        public bool RemoveComponent(IGameComponent component)
        {
            return this.componentList.Remove(component);
        }

        /// <summary>
        /// Removes all components of a specified type from the game object.
        /// </summary>
        /// <typeparam name="T">The type of components to remove.</typeparam>
        /// <returns>The amount of components removed.</returns>
        public int RemoveComponents<T>()
        {
            List<LinkedListNode<IGameComponent>> list;

            if (!componentDict.TryGetValue(typeof (T), out list))
                return 0;
            var ret = list.Count;
            foreach (var node in list)
                this.componentList.Remove(node);
            list.Clear();

            return ret;
        }

        /// <summary>
        /// Gets the first component of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the component to retrieve.</typeparam>
        /// <returns>The first component of the specified type if it exists, null otherwise.</returns>
        public T GetComponent<T>() where T : IGameComponent
        {
            List<LinkedListNode<IGameComponent>> list;

            if (!componentDict.TryGetValue(typeof (T), out list) || list.Count == 0)
                return default(T);
            return (T)list[0].Value;
        }

        /// <summary>
        /// Gets all components of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the components to retrieve.</typeparam>
        /// <returns>An array of all components of the specified type.</returns>
        public T[] GetComponents<T>() where T : IGameComponent
        {
            List<LinkedListNode<IGameComponent>> list;

            if (!componentDict.TryGetValue(typeof(T), out list) || list.Count == 0)
                return new T[0];
            return list.Select(node => (T) node.Value).ToArray();
        }
    }
}