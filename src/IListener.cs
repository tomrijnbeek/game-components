﻿namespace GameComponents
{
    public interface IListener<T>
    {
        /// <summary>
        /// Listen to messages sent from the game object.
        /// </summary>
        /// <param name="message">The sent message.</param>
        /// <typeparam name="T">The type of the sent message.</typeparam>
        void Listen(T message);
    }
}