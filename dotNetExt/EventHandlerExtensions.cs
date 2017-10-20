//Copyright (c) Chris Pietschmann 2012 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

using System;

namespace dotNetExt
{
    public static class EventHandlerExtensions
    {
        /// <summary>
        /// Method for invoking/raising events.
        /// </summary>
        /// <param name="handler">Required. The EventHandler to Invoke.</param>
        /// <param name="sender">Required.</param>
        public static void Raise(this System.EventHandler handler, object sender)
        {
            handler.Raise(sender, EventArgs.Empty);
        }

        /// <summary>
        /// Method for invoking/raising events.
        /// </summary>
        /// <param name="handler">Required. The EventHandler to Invoke.</param>
        /// <param name="sender">Required.</param>
        /// <param name="e">Required.</param>
        public static void Raise(this System.EventHandler handler, object sender, EventArgs e)
        {
            if (handler != null)
                handler(sender, e);
        }

        /// <summary>
        /// Method for invoking/raising events.
        /// </summary>
        /// <param name="handler">Required. The EventHandler to Invoke.</param>
        /// <param name="sender">Required.</param>
        public static void Raise<TEventArgs>(this System.EventHandler<TEventArgs> handler, object sender) where TEventArgs: EventArgs
        {
            handler.Raise<TEventArgs>(sender, Activator.CreateInstance<TEventArgs>());
        }

        /// <summary>
        /// Method for invoking/raising events.
        /// </summary>
        /// <param name="handler">Required. The EventHandler to Invoke.</param>
        /// <param name="sender">Required.</param>
        /// <param name="e">Required.</param>
        public static void Raise<TEventArgs>(this System.EventHandler<TEventArgs> handler, object sender, TEventArgs e) where TEventArgs : EventArgs
        {
            if (handler != null)
                handler(sender, e);
        }

    }
}
