﻿using System;

namespace Bifrost.Read
{
    /// <summary>
    /// The exception that is thrown when a readmodelof is not known by its name in the system
    /// </summary>
    public class UnknownReadModelOfException : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of <see cref="UnknownReadModelOfException"/>
        /// </summary>
        /// <param name="name"></param>
        public UnknownReadModelOfException(string name)
            : base("There is no readmodelof named : " + name)
        {
        }
    }
}