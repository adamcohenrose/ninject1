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
using System.IO;
using System.Reflection;
using System.Text;
using Ninject.Core.Activation;
using Ninject.Core.Binding;
#endregion

namespace Ninject.Core.Infrastructure
{
	internal static class ExceptionFormatter
	{
		/*----------------------------------------------------------------------------------------*/
		#region MultipleDefaultBindingsRegistered
		public static string MultipleDefaultBindingsRegistered(Type service, IList<IBinding> bindings)
		{
			using (StringWriter sw = new StringWriter())
			{
				sw.WriteLine("Error registering service {0}: Multiple default bindings declared for service.", Format.Type(service));
				sw.WriteLine("Found {0} default binding{1}:", bindings.Count, (bindings.Count == 1 ? "" : "s"));

				for (int index = 0; index < bindings.Count; index++)
				{
					IBinding binding = bindings[index];

					sw.WriteLine("{0,2}. {1}", (index + 1), Format.Binding(binding));

					if (binding.HasDebugInfo)
						sw.WriteLine("    declared at {0}", binding.DebugInfo);
				}

				return sw.ToString();
			}
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region IncompleteBindingsRegistered
		public static string IncompleteBindingsRegistered(Type service, List<IBinding> bindings)
		{
			using (StringWriter sw = new StringWriter())
			{
				sw.Write("Error registering service {0}: One or more bindings definitions were incomplete. ", Format.Type(service));
				sw.Write("Assign providers to these definitions before the module is loaded.");
				sw.WriteLine("Found {0} incomplete binding{1}:", bindings.Count, (bindings.Count == 1 ? "" : "s"));

				for (int index = 0; index < bindings.Count; index++)
				{
					IBinding binding = bindings[index];

					sw.WriteLine("{0,2}. {1}", (index + 1), Format.Binding(binding));

					if (binding.HasDebugInfo)
						sw.WriteLine("    declared at {0}", binding.DebugInfo);
				}

				return sw.ToString();
			}
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region InvalidProviderType
		public static string InvalidProviderType(IBinding binding, Type providerType)
		{
			using (StringWriter sw = new StringWriter())
			{
				sw.WriteLine("Error registering {0}: the supplied provider type {1} does not implement IProvider.", binding.Service, providerType);
				sw.WriteLine("Using {0}", Format.Binding(binding));

				if (binding.HasDebugInfo)
					sw.WriteLine("     declared by {0}", binding.DebugInfo);

				return sw.ToString();
			}
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region ProviderIncompatibleWithService
		public static string ProviderIncompatibleWithService(IContext context, Type implementation)
		{
			using (StringWriter sw = new StringWriter())
			{
				sw.WriteLine(
					"Error activating {0}: the {1} returned an instance of type {2}, which is not compatible with the requested service.",
					Format.Type(context.Service),
					Format.Type(context.Binding.Provider.GetType()),
					Format.Type(implementation));

				sw.WriteLine("Using {0}", Format.Binding(context.Binding));

				if (context.Binding.HasDebugInfo)
					sw.WriteLine("     declared by {0}", context.Binding.DebugInfo);

				sw.WriteLine("Activation path:");
				sw.Write(Format.ActivationPath(context));

				return sw.ToString();
			}
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region GenericArgumentsIncompatibleWithTypeDefinition
		public static string GenericArgumentsIncompatibleWithTypeDefinition(IContext context, Type prototype)
		{
			using (StringWriter sw = new StringWriter())
			{
				sw.WriteLine(
					"Error activating {0}: the generic type arguments of the service are incompatible with the open generic type {1} declared in the binding.",
					Format.Type(context.Service),
					Format.Type(prototype));

				sw.WriteLine("Using {0}", Format.Binding(context.Binding));

				if (context.Binding.HasDebugInfo)
					sw.WriteLine("     declared by {0}", context.Binding.DebugInfo);

				sw.WriteLine("Activation path:");
				sw.Write(Format.ActivationPath(context));

				return sw.ToString();
			}
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region CouldNotResolveBindingForType
		public static string CouldNotResolveBindingForType(Type type, IContext context)
		{
			using (StringWriter sw = new StringWriter())
			{
				sw.Write("Error activating {0}: ", Format.Type(context.Service));
				sw.WriteLine("no matching bindings are available, and the type is not self-bindable (or implicit binding is disabled).");

				sw.WriteLine("Activation path:");
				sw.Write(Format.ActivationPath(context));

				return sw.ToString();
			}
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region MultipleConditionalBindingsMatch
		public static string MultipleConditionalBindingsMatch(IContext context, IList<IBinding> bindings)
		{
			using (StringWriter sw = new StringWriter())
			{
				sw.Write("Error activating {0}: ", Format.Type(context.Service));
				sw.WriteLine("multiple conditional bindings match the context, and no default binding is available.");

				sw.WriteLine("Found {0} matching bindings:", bindings.Count);

				for (int index = 0; index < bindings.Count; index++)
				{
					IBinding binding = bindings[index];

					sw.WriteLine("{0,3}) {1}", (index + 1), Format.Binding(binding));

					if (binding.HasDebugInfo)
						sw.WriteLine("     declared by {0}", binding.DebugInfo);
				}

				sw.WriteLine("Activation path:");
				sw.Write(Format.ActivationPath(context));

				return sw.ToString();
			}
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region NoConstructorsAvailable
		public static string NoConstructorsAvailable(IContext context)
		{
			using (StringWriter sw = new StringWriter())
			{
				sw.Write("Error activating {0}: the implementation type {1} must either ",
					Format.Type(context.Binding.Service),
					Format.Type(context.Plan.Type));
				sw.WriteLine("have a parameterless constructor or one decorated with an InjectAttribute.");

				sw.WriteLine("Using {0}", Format.Binding(context.Binding));

				if (context.Binding.HasDebugInfo)
					sw.WriteLine("     declared by {0}", context.Binding.DebugInfo);

				sw.WriteLine("Activation path:");
				sw.Write(Format.ActivationPath(context));

				return sw.ToString();
			}
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region MultipleInjectionConstructorsNotSupported
		public static string MultipleInjectionConstructorsNotSupported(IBinding binding)
		{
			using (StringWriter sw = new StringWriter())
			{
				sw.Write("Error while registering {0}", Format.Binding(binding));

				if (binding.HasDebugInfo)
				{
					sw.WriteLine();
					sw.Write("  declared by {0}", binding.DebugInfo);
				}

				sw.WriteLine(":");
				sw.WriteLine("Multiple constructors decorated with an InjectAttribute are not supported.");

				return sw.ToString();
			}
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region ProviderCouldNotCreateInstance
		public static string ProviderCouldNotCreateInstance(IContext context)
		{
			using (StringWriter sw = new StringWriter())
			{
				sw.Write("Error activating {0}: {1} could not create instance of instance type {2}",
					Format.Type(context.Binding.Service),
					Format.Type(context.Binding.Provider.GetType()),
					Format.Type(context.Plan.Type));

				sw.WriteLine("Using {0}", Format.Binding(context.Binding));

				if (context.Binding.HasDebugInfo)
					sw.WriteLine("  declared by {0}", context.Binding.DebugInfo);

				sw.WriteLine("Activation path:");
				sw.Write(Format.ActivationPath(context));

				return sw.ToString();
			}
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region CannotConvertConstantValue
		public static string CannotConvertConstantValue(IContext context, Type constantType)
		{
			using (StringWriter sw = new StringWriter())
			{
				sw.Write("Error activating {0}: Could not convert constant value of type {1} to requested type {2}",
					Format.Type(context.Binding.Service),
					Format.Type(constantType),
					Format.Type(context.Service));

				sw.WriteLine("Using {0}", Format.Binding(context.Binding));

				if (context.Binding.HasDebugInfo)
					sw.WriteLine("  declared by {0}", context.Binding.DebugInfo);

				sw.WriteLine("Activation path:");
				sw.Write(Format.ActivationPath(context));

				return sw.ToString();
			}
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region CircularDependenciesDetected
		public static string CircularDependenciesDetected(IContext context)
		{
			Ensure.ArgumentNotNull(context, "context");

			using (StringWriter sw = new StringWriter())
			{
				sw.Write("Error activating {0}: Circular dependencies detected between constructors. ", Format.Type(context.Service));
				sw.WriteLine("Consider using property injection and implementing IInitializable instead.");

				sw.WriteLine("Using {0}", Format.Binding(context.Binding));

				if (context.Binding.HasDebugInfo)
					sw.WriteLine("  declared by {0}", context.Binding.DebugInfo);

				sw.WriteLine("Activation path:");
				sw.Write(Format.ActivationPath(context));

				return sw.ToString();
			}
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region InvalidInlineArgument
		public static string InvalidInlineArgument(Argument argument, object inlineArgument, IContext context)
		{
			Ensure.ArgumentNotNull(argument, "argument");
			Ensure.ArgumentNotNull(context, "context");

			using (StringWriter sw = new StringWriter())
			{
				sw.WriteLine("Error activating {0}: Invalid inline argument specified for constructor parameter '{1}' of type {2}.",
					Format.Type(context.Service),
					argument.Target.Name,
					Format.Type(context.Plan.Type));

				sw.WriteLine("The argument's type ({0}) is not compatible with the expected type ({1}), and the value cannot be converted.",
					Format.Type(inlineArgument.GetType()),
					Format.Type(argument.Target.Type));

				sw.WriteLine("Using {0}", Format.Binding(context.Binding));

				if (context.Binding.HasDebugInfo)
					sw.WriteLine("  declared by {0}", context.Binding.DebugInfo);

				sw.WriteLine("Activation path:");
				sw.Write(Format.ActivationPath(context));

				return sw.ToString();
			}
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
	}
}