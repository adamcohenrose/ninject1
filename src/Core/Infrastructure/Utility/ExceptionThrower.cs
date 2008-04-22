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
using System.Reflection;
#endregion

namespace Ninject.Core.Infrastructure
{
	/// <summary>
	/// Provides utility functions for throwing exceptions.
	/// </summary>
	internal static class ExceptionThrower
	{
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Re-throws the specified exception, preserving its internal stack trace.
		/// </summary>
		/// <param name="ex">The exception to re-throw.</param>
		public static void RethrowPreservingStackTrace(Exception ex)
		{
			FieldInfo stackTraceField = typeof(Exception).GetField("_remoteStackTraceString",
				BindingFlags.Instance | BindingFlags.NonPublic);

			stackTraceField.SetValue(ex, ex.StackTrace);

			throw ex;
		}
		/*----------------------------------------------------------------------------------------*/
	}
}