﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.Runtime.Serialization;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;

namespace Microsoft.Rest.Azure.Authentication
{
    /// <summary>
    /// Authentication exception for Microsoft Rest Client for Azure.
    /// </summary>
#if !PORTABLE
    [Serializable]
#endif
    public class AuthenticationException : RestException
    {

        /// <summary>
        /// Initializes a new instance of the AuthenticationException class.
        /// </summary>
        public AuthenticationException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the AuthenticationException class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public AuthenticationException(string message)
            : this(message, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the AuthenticationException class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public AuthenticationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Wrap an exception thrown by the ADAL library.  This prevents client dependencies on a particular version fo ADAL.
        /// </summary>
        /// <param name="message">The exception message</param>
        /// <param name="innerException">The inner AdalException with additional details</param>
        internal AuthenticationException(string message, AdalException innerException) :
            base(string.Format(CultureInfo.CurrentCulture, message, innerException.Message), innerException)
        {
        }
    }
}
