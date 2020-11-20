// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.Utilities;
using Microsoft.Extensions.DependencyInjection;

#nullable enable

namespace Microsoft.EntityFrameworkCore.Storage
{
    /// <summary>
    ///     <para>
    ///         Service dependencies parameter class for <see cref="RelationalConnection" />
    ///     </para>
    ///     <para>
    ///         This type is typically used by database providers (and other extensions). It is generally
    ///         not used in application code.
    ///     </para>
    ///     <para>
    ///         Do not construct instances of this class directly from either provider or application code as the
    ///         constructor signature may change as new dependencies are added. Instead, use this type in
    ///         your constructor so that an instance will be created and injected automatically by the
    ///         dependency injection container. To create an instance with some dependent services replaced,
    ///         first resolve the object from the dependency injection container, then replace selected
    ///         services using the 'With...' methods. Do not call the constructor at any point in this process.
    ///     </para>
    ///     <para>
    ///         The service lifetime is <see cref="ServiceLifetime.Scoped" />. This means that each
    ///         <see cref="DbContext" /> instance will use its own instance of this service.
    ///         The implementation may depend on other services registered with any lifetime.
    ///         The implementation does not need to be thread-safe.
    ///     </para>
    /// </summary>
    public sealed record RelationalConnectionDependencies
    {
        /// <summary>
        ///     <para>
        ///         Creates the service dependencies parameter object for a <see cref="RelationalConnection" />.
        ///     </para>
        ///     <para>
        ///         Do not call this constructor directly from either provider or application code as it may change
        ///         as new dependencies are added. Instead, use this type in your constructor so that an instance
        ///         will be created and injected automatically by the dependency injection container. To create
        ///         an instance with some dependent services replaced, first resolve the object from the dependency
        ///         injection container, then replace selected services using the 'With...' methods. Do not call
        ///         the constructor at any point in this process.
        ///     </para>
        ///     <para>
        ///         This is an internal API that supports the Entity Framework Core infrastructure and not subject to
        ///         the same compatibility standards as public APIs. It may be changed or removed without notice in
        ///         any release. You should only use it directly in your code with extreme caution and knowing that
        ///         doing so can result in application failures when updating to a new Entity Framework Core release.
        ///     </para>
        /// </summary>
        [EntityFrameworkInternal]
        public RelationalConnectionDependencies(
            [NotNull] IDbContextOptions contextOptions,
            [NotNull] IDiagnosticsLogger<DbLoggerCategory.Database.Transaction> transactionLogger,
            [NotNull] IDiagnosticsLogger<DbLoggerCategory.Database.Connection> connectionLogger,
            [NotNull] INamedConnectionStringResolver connectionStringResolver,
            [NotNull] IRelationalTransactionFactory relationalTransactionFactory,
            [NotNull] ICurrentDbContext currentContext)
        {
            Check.NotNull(contextOptions, nameof(contextOptions));
            Check.NotNull(transactionLogger, nameof(transactionLogger));
            Check.NotNull(connectionLogger, nameof(connectionLogger));
            Check.NotNull(connectionStringResolver, nameof(connectionStringResolver));
            Check.NotNull(relationalTransactionFactory, nameof(relationalTransactionFactory));
            Check.NotNull(currentContext, nameof(currentContext));

            ContextOptions = contextOptions;
            TransactionLogger = transactionLogger;
            ConnectionLogger = connectionLogger;
            ConnectionStringResolver = connectionStringResolver;
            RelationalTransactionFactory = relationalTransactionFactory;
            CurrentContext = currentContext;
        }

        /// <summary>
        ///     The options for the current context instance.
        /// </summary>
        public IDbContextOptions ContextOptions { get; [param: NotNull] init; }

        /// <summary>
        ///     The logger to which transaction messages will be written.
        /// </summary>
        public IDiagnosticsLogger<DbLoggerCategory.Database.Transaction> TransactionLogger { get; [param: NotNull] init; }

        /// <summary>
        ///     The logger to which connection messages will be written.
        /// </summary>
        public IDiagnosticsLogger<DbLoggerCategory.Database.Connection> ConnectionLogger { get; [param: NotNull] init; }

        /// <summary>
        ///     A service for resolving a connection string from a name.
        /// </summary>
        [EntityFrameworkInternal]
        public INamedConnectionStringResolver ConnectionStringResolver { get; [param: NotNull] init; }

        /// <summary>
        ///     A service for creating <see cref="RelationalTransaction" /> instances.
        /// </summary>
        public IRelationalTransactionFactory RelationalTransactionFactory { get; [param: NotNull] init; }

        /// <summary>
        ///     Contains the <see cref="DbContext" /> instance currently in use.
        /// </summary>
        public ICurrentDbContext CurrentContext { get; [param: NotNull] init; }
    }
}
