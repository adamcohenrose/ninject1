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
using Ninject.Core.Activation;
using Ninject.Core.Infrastructure;
#endregion

namespace Ninject.Core.Behavior
{
	/// <summary>
	/// A baseline implementation of a behavior. Custom behaviors should extend this class.
	/// </summary>
	public abstract class BehaviorBase : DisposableObject, IBehavior
	{
		/*----------------------------------------------------------------------------------------*/
		#region Fields
		private IKernel _kernel;
		private readonly bool _supportsEagerActivation;
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region Properties
		/// <summary>
		/// Gets or sets the kernel related to the behavior.
		/// </summary>
		public IKernel Kernel
		{
			get { return _kernel; }
			set { _kernel = value; }
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Gets a value indicating whether the behavior supports eager activation.
		/// </summary>
		/// <remarks>
		/// If <see langword="true"/>, instances of the associated type will be automatically
		/// activated if the <c>UseEagerActivation</c> option is set for the kernel. If
		/// <see langword="false"/>, all instances of the type will be lazily activated.
		/// </remarks>
		public bool SupportsEagerActivation
		{
			get { return _supportsEagerActivation; }
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="BehaviorBase"/> class.
		/// </summary>
		/// <param name="supportsEagerActivation">A value indicating whether the behavior supports eager activation.</param>
		protected BehaviorBase(bool supportsEagerActivation)
		{
			_supportsEagerActivation = supportsEagerActivation;
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region Disposal
		/// <summary>
		/// Releases all resources held by the object.
		/// </summary>
		/// <param name="disposing"><see langword="True"/> if managed objects should be disposed, otherwise <see langword="false"/>.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && !IsDisposed)
				_kernel = null;

			base.Dispose(disposing);
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region Public Methods
		/// <summary>
		/// Resolves an instance of the type based on the rules of the behavior.
		/// </summary>
		/// <param name="context">The context in which the instance is being activated.</param>
		/// <returns>An instance of the type associated with the behavior.</returns>
		public abstract object Resolve(IContext context);
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Releases an instance of the type based on the rules of the behavior.
		/// </summary>
		/// <param name="reference">A contextual reference to the instance to be released.</param>
		public abstract void Release(IInstanceReference reference);
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region Protected Methods
		/// <summary>
		/// Creates a new instance of the type via the kernel's <see cref="IActivator"/>.
		/// </summary>
		/// <param name="context">The context in which the instance should be created.</param>
		/// <param name="existing">The existing object, if applicable.</param>
		protected virtual object CreateInstance(IContext context, object existing)
		{
			IActivator activator = Kernel.GetComponent<IActivator>();
			object instance = existing;

			lock (this)
			{
				// Ask the activator to create an instance of the appropriate type.
				activator.Create(context, ref instance);
			}

			return instance;
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Destroys an instance of the type via the kernel's <see cref="IActivator"/>.
		/// </summary>
		/// <param name="reference">A reference to the instance to destroy.</param>
		protected virtual void DestroyInstance(IInstanceReference reference)
		{
			IActivator activator = Kernel.GetComponent<IActivator>();
			object instance = reference.Instance;

			if (instance != null)
				activator.Destroy(reference.Context, ref instance);
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
	}
}