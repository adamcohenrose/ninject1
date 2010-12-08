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
using Ninject.Core.Activation;
using Ninject.Core.Infrastructure;
#endregion

namespace Ninject.Core.Parameters
{
	/// <summary>
	/// A collection that organizes parameters by type.
	/// </summary>
	public class ParameterCollection : TypedCollection<string, IParameter>, IParameterCollection
    {
        /*----------------------------------------------------------------------------------------
         * See http://groups.google.com/group/ninject/browse_thread/thread/6961f74cf141a9ca/79d7ea42a8c1d93c#79d7ea42a8c1d93c
         *----------------------------------------------------------------------------------------*/
        #region Interface implementation
        /*----------------------------------------------------------------------------------------*/
        /// <summary>
        /// Adds the specified item to the collection.
        /// </summary>
        /// <typeparam name="T">The type to organize the item under.</typeparam>
        /// <param name="item">The item to add.</param>
        void ITypedCollection<string, IParameter>.Add<T>(T item)
        {
            base.Add<T>(item);
        }
        /*----------------------------------------------------------------------------------------*/
        /// <summary>
        /// Adds the specified item to the collection.
        /// </summary>
        /// <param name="type">The type to organize the item under.</param>
        /// <param name="item">The item to add.</param>
        void ITypedCollection<string, IParameter>.Add(Type type, IParameter item)
        {
            base.Add(type, item);
        }
        /*----------------------------------------------------------------------------------------*/
        /// <summary>
        /// Adds the specified items to the collection.
        /// </summary>
        /// <typeparam name="T">The type to organize the items under.</typeparam>
        /// <param name="items">The items to add.</param>
        void ITypedCollection<string, IParameter>.AddRange<T>(IEnumerable<T> items)
        {
            base.AddRange<T>(items);
        }
        /*----------------------------------------------------------------------------------------*/
        /// <summary>
        /// Adds the specified items to the collection.
        /// </summary>
        /// <param name="type">The type to organize the items under.</param>
        /// <param name="items">The items to add.</param>
        void ITypedCollection<string, IParameter>.AddRange(Type type, IEnumerable<IParameter> items)
        {
            base.AddRange(type, items);
        }
        /*----------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets a value indicating whether an item with the specified key has been organized under
        /// the specified type.
        /// </summary>
        /// <typeparam name="T">The type the item is organized under.</typeparam>
        /// <param name="key">The item's key.</param>
        /// <returns><see langword="True"/> if the item has been defined, otherwise <see langword="false"/>.</returns>
        bool ITypedCollection<string, IParameter>.Has<T>(string key)
        {
            return base.Has<T>(key);
        }
        /*----------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets a value indicating whether an item with the specified key has been organized under
        /// the specified type.
        /// </summary>
        /// <param name="type">The type the item is organized under.</param>
        /// <param name="key">The item's key.</param>
        /// <returns><see langword="True"/> if the item has been defined, otherwise <see langword="false"/>.</returns>
        bool ITypedCollection<string, IParameter>.Has(Type type, string key)
        {
            return base.Has(type, key);
        }
        /*----------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets a value indicating whether one or more items organized under the specified type.
        /// </summary>
        /// <typeparam name="T">The type to check.</typeparam>
        /// <returns><see langword="True"/> if there are such items, otherwise <see langword="false"/>.</returns>
        bool ITypedCollection<string, IParameter>.HasOneOrMore<T>()
        {
            return base.HasOneOrMore<T>();
        }
        /*----------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets a value indicating whether one or more items organized under the specified type.
        /// </summary>
        /// <param name="type">The type check.</param>
        /// <returns><see langword="True"/> if there are such items, otherwise <see langword="false"/>.</returns>
        bool ITypedCollection<string, IParameter>.HasOneOrMore(Type type)
        {
            return base.HasOneOrMore(type);
        }
        /*----------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the item with the specified key, organized under the specified type, if one has been defined.
        /// </summary>
        /// <typeparam name="T">The type the item is organized under.</typeparam>
        /// <param name="key">The item's key.</param>
        /// <returns>The item, or <see langword="null"/> if none has been defined.</returns>
        T ITypedCollection<string, IParameter>.Get<T>(string key)
        {
            return base.Get<T>(key);
        }
        /*----------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the item with the specified key, organized under the specified type, if one has been defined.
        /// </summary>
        /// <param name="type">The type the item is organized under.</param>
        /// <param name="key">The item's key.</param>
        /// <returns>The item, or <see langword="null"/> if none has been defined.</returns>
        IParameter ITypedCollection<string, IParameter>.Get(Type type, string key)
        {
            return base.Get(type, key);
        }
        /*----------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the first item in the collection that is organized under the specified type.
        /// </summary>
        /// <typeparam name="T">The type to check.</typeparam>
        /// <returns>The item, or <see langword="null"/> if none has been defined.</returns>
        T ITypedCollection<string, IParameter>.GetOne<T>()
        {
            return base.GetOne<T>();
        }
        /*----------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the first item in the collection that is organized under the specified type.
        /// </summary>
        /// <param name="type">The type the item is organized under.</param>
        /// <returns>The item, or <see langword="null"/> if none has been defined.</returns>
        IParameter ITypedCollection<string, IParameter>.GetOne(Type type)
        {
            return base.GetOne(type);
        }
        /*----------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets all items organized under the specified type.
        /// </summary>
        /// <typeparam name="T">The type the items are organized under.</typeparam>
        /// <returns>A collection of items organized under the specified type.</returns>
        IList<T> ITypedCollection<string, IParameter>.GetAll<T>()
        {
            return base.GetAll<T>();
        }
        /*----------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets all items organized under the specified type.
        /// </summary>
        /// <param name="type">The type the items are organized under.</param>
        /// <returns>A collection of items organized under the specified type.</returns>
        IList<IParameter> ITypedCollection<string, IParameter>.GetAll(Type type)
        {
            return base.GetAll(type);
        }
        /*----------------------------------------------------------------------------------------*/
        /// <summary>
        /// Gets the types that items are organized under.
        /// </summary>
        /// <returns>A collection of types that items are organized under.</returns>
        IList<Type> ITypedCollection<string, IParameter>.GetTypes()
        {
            return base.GetTypes();
        }
        /*----------------------------------------------------------------------------------------*/
        #endregion
        /*----------------------------------------------------------------------------------------*/
		#region Public Methods
		/// <summary>
		/// Copies the parameters from the specified collection.
		/// </summary>
		/// <param name="parameters">The collection of parameters to copy from.</param>
		public void CopyFrom(IParameterCollection parameters)
		{
			parameters.GetTypes().Each(t => AddRange(t, parameters.GetAll(t)));
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Inherits any of the parameters in the specified collection that are marked for inheritance.
		/// </summary>
		/// <param name="parameters">The parameters to consider for inheritance.</param>
		public void InheritFrom(IParameterCollection parameters)
		{
			parameters.GetTypes().Each(t => AddRange(t, parameters.GetAll(t).Where(p => p.ShouldInherit)));
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Attempts to retrieve the value of the parameter with the specified type and name.
		/// </summary>
		/// <typeparam name="T">The type of the parameter.</typeparam>
		/// <param name="name">The name of the parameter.</param>
		/// <param name="context">The context in which the value is being resolved.</param>
		/// <returns>The value of the parameter in question, or <see langword="null"/> if no such parameter exists.</returns>
		public object GetValueOf<T>(string name, IContext context)
			where T : class, IParameter
		{
			var parameter = Get<T>(name);
			return (parameter == null) ? null : parameter.GetValue(context);
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Attempts to retrieve the value of the parameter with the specified type and name.
		/// </summary>
		/// <param name="type">The type of the parameter.</param>
		/// <param name="name">The name of the parameter.</param>
		/// <param name="context">The context in which the value is being resolved.</param>
		/// <returns>The value of the parameter in question, or <see langword="null"/> if no such parameter exists.</returns>
		public object GetValueOf(Type type, string name, IContext context)
		{
			var parameter = Get(type, name);
			return (parameter == null) ? null : parameter.GetValue(context);
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region Protected Methods
		/// <summary>
		/// Gets the key for the specified item.
		/// </summary>
		/// <param name="item">The item.</param>
		/// <returns>The key for the item.</returns>
		protected override string GetKeyForItem(IParameter item)
		{
			return item.Name;
		}
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Called when an item is added to the collection when an item with the same key already
		/// exists in the collection, organized under the same type.
		/// </summary>
		/// <param name="type">The type the items are organized under.</param>
		/// <param name="key">The key the items share.</param>
		/// <param name="newItem">The new item that was added.</param>
		/// <param name="existingItem">The item that already existed in the collection.</param>
		/// <returns><see langword="True"/> if the new item should replace the existing item, otherwise <see langword="false"/>.</returns>
		protected override bool OnKeyCollision(Type type, string key, IParameter newItem, IParameter existingItem)
		{
			throw new InvalidOperationException(ExceptionFormatter.ParameterWithSameNameAlreadyDefined(newItem));
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
	}
}
