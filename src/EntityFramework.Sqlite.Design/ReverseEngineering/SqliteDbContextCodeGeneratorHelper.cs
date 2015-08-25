﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using JetBrains.Annotations;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Relational.Design.ReverseEngineering;
using Microsoft.Data.Entity.Relational.Design.Utilities;

namespace Microsoft.Data.Entity.Sqlite.Design.ReverseEngineering
{
    public class SqliteDbContextCodeGeneratorHelper : DbContextCodeGeneratorHelper
    {
        public override string UseMethodName => nameof(SqliteDbContextOptionsBuilderExtensions.UseSqlite);

        public SqliteDbContextCodeGeneratorHelper(
            [NotNull] DbContextGeneratorModel generatorModel, 
            [NotNull] IRelationalMetadataExtensionProvider extensionsProvider, 
            [NotNull] ModelUtilities modelUtilities)
            : base(generatorModel, extensionsProvider, modelUtilities)
        {
        }
    }
}
