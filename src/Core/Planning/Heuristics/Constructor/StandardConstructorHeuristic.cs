#region License
//
// Author: Nate Kohari <nkohari@gmail.com>
// Copyright (c) 2007-2008, Enkari, Ltd.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion
#region Using Directives
using System;
using System.Collections.Generic;
using System.Reflection;
using Ninject.Core.Binding;
using Ninject.Core.Infrastructure;
#endregion

namespace Ninject.Core.Planning.Heuristics
{
	/// <summary>
	/// Selects a constructor to call during activation by looking for one marked with
	/// an injection attribute.
	/// </summary>
	public class StandardConstructorHeuristic : KernelComponentBase, IConstructorHeuristic
	{
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Selects the member that should be injected.
		/// </summary>
		/// <param name="binding">The binding that points at the type whose activation plan being manipulated.</param>
		/// <param name="type">The type whose activation plan is being manipulated.</param>
		/// <param name="plan">The activation plan that is being manipulated.</param>
		/// <param name="candidates">A collection of potential members.</param>
		/// <returns>The member that should be injected.</returns>
		public ConstructorInfo Select(IBinding binding, Type type, IActivationPlan plan, IList<ConstructorInfo> candidates)
		{
			// If there was only a single constructor defined for the type, try to use it.
			if (candidates.Count == 1)
				return candidates[0];

			ConstructorInfo selectedConstructor = null;

			foreach (ConstructorInfo candidate in candidates)
			{
				if (candidate.HasAttribute(Kernel.Options.InjectAttributeType))
				{
					// Only a single injection constructor is allowed, so fail if we find more than one.
					if (selectedConstructor != null)
						throw new NotSupportedException(ExceptionFormatter.MultipleInjectionConstructorsNotSupported(binding));

					selectedConstructor = candidate;
				}
			}

			// If no constructors were marked for injection, try to use the default one.
			if (selectedConstructor == null)
				selectedConstructor = type.GetConstructor(Type.EmptyTypes);

			return selectedConstructor;
		}
		/*----------------------------------------------------------------------------------------*/
	}
}