#region License
//
// Author: Nate Kohari <nkohari@gmail.com>
// Copyright (c) 2007, Enkari, Ltd.
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
using System.Threading;
using Ninject.Core.Tests.Mocks;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
#endregion

namespace Ninject.Core.Tests.Activation
{
	[TestFixture]
	public class ConcurrencyFixture
	{
		/*----------------------------------------------------------------------------------------*/
		[Test]
		public void MultipleThreadsActivatingSameServiceDoNotTriggerCircularReferenceException()
		{
			using (IKernel kernel = new StandardKernel())
			{
				List<Thread> threads = new List<Thread>();

				for (int index = 0; index < 10; index++)
				{
					Thread thread = new Thread(delegate(object state) { kernel.Get<ImplA>(); });
					threads.Add(thread);
				}

				threads.ForEach(delegate(Thread t) { t.Start(); });
				threads.ForEach(delegate(Thread t) { t.Join(); });
			}
		}
		/*----------------------------------------------------------------------------------------*/
	}
}