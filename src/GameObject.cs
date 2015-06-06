using System.Collections.Generic;
using System.Linq;

namespace GameComponents
{
    public sealed class GameObject
    {
        private readonly List<IGameComponent> components = new List<IGameComponent>();

        public void Update(float dt)
        {
            foreach (var c in this.components)
                c.Update(dt);
        }

        public void AddComponent(IGameComponent component)
        {
            this.components.Add(component);
        }

        public bool RemoveComponent(IGameComponent component)
        {
            return this.components.Remove(component);
        }

        public int RemoveComponents<T>()
        {
            return this.components.RemoveAll(c => c is T);
        }

        public T GetComponent<T>() where T : IGameComponent
        {
            return (T)this.components.First(c => c is T);
        }

        public List<T> GetComponents<T>() where T : IGameComponent
        {
            return this.components.OfType<T>().ToList();
        }
    }
}