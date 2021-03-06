﻿// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DictionaryExtensions.cs" company="NFluent">
//   Copyright 2019 Cyrille DUPUYDAUBY
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//       http://www.apache.org/licenses/LICENSE-2.0
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace NFluent.Extensions
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Helpers;
#if DOTNET_45 || NETSTANDARD1_3
    using System.Reflection;
#endif

#if !DOTNET_20 && !DOTNET_30
    using System.Linq;
#endif
    internal static class DictionaryExtensions
    {
        public static IReadOnlyDictionary<K, V> WrapDictionary<K, V>(object knownDictionary)
        {
            // if the object implements IDictionary
            if (knownDictionary is IDictionary simpleDictionary)
            {
                return new DictionaryWrapper<K, V>(simpleDictionary);
            }

            // if it implements IReadonlyDictionary<,>
            var interfaces = knownDictionary.GetType().GetInterfaces().Where( i=>i.IsGenericType()).ToArray();
            var roDictionaryInterface = interfaces
                .FirstOrDefault(i=> i.GetGenericTypeDefinition() == typeof(IReadOnlyDictionary<,>));
            if (roDictionaryInterface != null)
            {
                var targetRoType= typeof(ReadOnlyDictionaryWrapper<,,,>).MakeGenericType(typeof(K), typeof(V), roDictionaryInterface.GetGenericArguments()[0], roDictionaryInterface.GetGenericArguments()[1]);
                var roConstructor = targetRoType.GetConstructor(new[] {roDictionaryInterface});
                return (IReadOnlyDictionary<K,V>) roConstructor.Invoke(new[] {knownDictionary});
            }
        
            // last attempt, IDictionary<,>
            var dictionaryInterface = interfaces
                .FirstOrDefault(i => i.GetGenericTypeDefinition() == typeof(IDictionary<,>));
            if (dictionaryInterface == null)
            {
                return null;
            }

            var targetType= typeof(DictionaryWrapper<,,,>).MakeGenericType(typeof(K), typeof(V), dictionaryInterface.GetGenericArguments()[0], dictionaryInterface.GetGenericArguments()[1]);
            var constructor = targetType.GetConstructor(new[] {dictionaryInterface});
            return (IReadOnlyDictionary<K,V>) constructor.Invoke(new[] {knownDictionary});
        }

    }
}