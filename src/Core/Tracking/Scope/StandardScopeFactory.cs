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
using Ninject.Core.Infrastructure;
#endregion

namespace Ninject.Core.Tracking
{
	/// <summary>
	/// The stock definition of a <see cref="IScopeFactory"/>.
	/// </summary>
	/// <remarks>
	/// I know, this looks like overkill. :) It exists to allow users to inject custom
	/// implementations into the kernel for more exotic situations.
	/// </remarks>
	public class StandardScopeFactory : KernelComponentBase, IScopeFactory
	{
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Creates a new scope.
		/// </summary>
		/// <returns>The newly-created scope.</returns>
		public IScope Create()
		{
			return new StandardScope(Kernel);
		}
		/*----------------------------------------------------------------------------------------*/
	}
}