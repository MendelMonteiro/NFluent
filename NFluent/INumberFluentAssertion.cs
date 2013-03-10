﻿// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="INumberFluentAssertion.cs" company="">
// //   Copyright 2013 Thomas PIERRAIN
// //   Licensed under the Apache License, Version 2.0 (the "License");
// //   you may not use this file except in compliance with the License.
// //   You may obtain a copy of the License at
// //       http://www.apache.org/licenses/LICENSE-2.0
// //   Unless required by applicable law or agreed to in writing, software
// //   distributed under the License is distributed on an "AS IS" BASIS,
// //   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// //   See the License for the specific language governing permissions and
// //   limitations under the License.
// // </copyright>
// // --------------------------------------------------------------------------------------------------------------------
namespace NFluent
{
    /// <summary>
    /// Provides assertion methods to be executed on a number instance.
    /// </summary>
    public interface INumberFluentAssertion : IFluentAssertion, IEqualityFluentAssertion, IInstanceTypeFluentAssertion<INumberFluentAssertion>
    {
        /// <summary>
        /// Verifies that the actual value is equal to zero.
        /// </summary>
        /// <returns>A chainable assertion.</returns>
        /// <exception cref="FluentAssertionException">The value is not equal to zero.</exception>
        IChainableFluentAssertion<INumberFluentAssertion> IsZero();

        /// <summary>
        /// Verifies that the actual value is NOT equal to zero.
        /// </summary>
        /// <returns>A chainable assertion.</returns>
        /// <exception cref="FluentAssertionException">The value is equal to zero.</exception>
        IChainableFluentAssertion<INumberFluentAssertion> IsNotZero();

        /// <summary>
        /// Verifies that the actual value is strictly positive.
        /// </summary>
        /// <returns>A chainable assertion.</returns>
        /// <exception cref="FluentAssertionException">The value is not strictly positive.</exception>
        IChainableFluentAssertion<INumberFluentAssertion> IsPositive();
    }
}