﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

namespace Microsoft.Telepathy.Common.Rest.Server
{
    using System;

    using Microsoft.Owin;
    using Microsoft.Owin.Security.Infrastructure;

    public class ClientCertificateAuthMiddleware : AuthenticationMiddleware<ClientCertificateAuthenticationOptions>
    {
        private readonly IClientCertificateValidator clientCertificateValidator;

        public ClientCertificateAuthMiddleware(
            OwinMiddleware nextMiddleware,
            ClientCertificateAuthenticationOptions authOptions,
            IClientCertificateValidator clientCertificateValidator) : base(nextMiddleware, authOptions)
        {
            if (clientCertificateValidator == null)
            {
                throw new ArgumentNullException("ClientCertificateValidator");
            }

            this.clientCertificateValidator = clientCertificateValidator;
        }

        protected override AuthenticationHandler<ClientCertificateAuthenticationOptions> CreateHandler()
        {
            return new ClientCertificateAuthenticationHandler(this.clientCertificateValidator);
        }
    }
}
