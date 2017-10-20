//Copyright (c) Chris Pietschmann 2012 (http://pietschsoft.com)
//All rights reserved.
//Licensed under the GNU Library General Public License (LGPL)
//License can be found here: http://www.codeplex.com/dotNetExt/license

using System;

namespace dotNetExt
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Returns a new instance of the specified Type passing in the specified constructor arguments.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static object CreateInstance(this Type type, params object[] args)
        {
            return Activator.CreateInstance(type, args);
        }

        /// <summary>
        /// Returns a new instance of the specified Type cast as the specified Generic type, passing in the specified constructor arguments.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static T CreateInstance<T>(this Type type, params object[] args)
        {
            return (T)type.CreateInstance(args);
        }
    }
}
