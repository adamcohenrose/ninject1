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
using Ninject.Core;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
#endregion

namespace Ninject.Tests
{
	[TestFixture]
	public class ModuleFixture
	{
		/*----------------------------------------------------------------------------------------*/
		[Test]
		public void KernelLoadsModulesAndAppliesTheirBindings()
		{
			using (var kernel = new StandardKernel(new MockModuleA(), new MockModuleB()))
			{
				IServiceA one = kernel.Get<IServiceA>();
				Assert.That(one, Is.Not.Null);
				Assert.That(one, Is.InstanceOfType(typeof(ServiceImplA)));

				IServiceB two = kernel.Get<IServiceB>();
				Assert.That(two, Is.Not.Null);
				Assert.That(two, Is.InstanceOfType(typeof(ServiceImplB)));
			}
		}
		/*----------------------------------------------------------------------------------------*/
	}
}