using System;
using GameComponents.Tests.Dummies;
using Xunit;

namespace GameComponents.Tests
{
    public class GameObjectStressTests
    {
        private const int numObjects = 1000;
        private const int numGets = 1000;

        [Fact]
        public void GetComponents1PerObject()
        {
            getComponentsNPerObject(1);
            Assert.True(true);
        }

        [Fact]
        public void GetComponents10PerObject()
        {
            getComponentsNPerObject(10);
            Assert.True(true);
        }

        [Fact]
        public void GetComponents100PerObject()
        {
            getComponentsNPerObject(100);
            Assert.True(true);
        }

        private void getComponentsNPerObject(int n)
        {
            var rand = new Random();
            var r = rand.Next(n);

            for (int i = 0; i < numObjects; i++)
            {
                var go = new GameObject();

                if (i == r)
                    go.AddComponent<GameComponent1>();
                else
                    go.AddComponent<GameComponent0>();

                for (int j = 0; j < numGets; j++)
                    go.GetComponent<GameComponent1>();
            }
        }
    }
}
