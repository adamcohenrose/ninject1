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
using Ninject.Core.Infrastructure;
using Ninject.Core.Planning.Directives;
#endregion

namespace Ninject.Core.Planning
{
	/// <summary>
	/// A collection of binding directives, stored in an activation plan.
	/// </summary>
	public class DirectiveCollection : TypedCollection<object, IDirective>, IDirectiveCollection
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
        void ITypedCollection<object, IDirective>.Add<T>(T item)
        {
            base.Add<T>(item);
        }
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Adds the specified item to the collection.
		/// </summary>
		/// <param name="type">The type to organize the item under.</param>
		/// <param name="item">The item to add.</param>
        void ITypedCollection<object, IDirective>.Add(Type type, IDirective item)
        {
            base.Add(type, item);
        }
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Adds the specified items to the collection.
		/// </summary>
		/// <typeparam name="T">The type to organize the items under.</typeparam>
		/// <param name="items">The items to add.</param>
        void ITypedCollection<object, IDirective>.AddRange<T>(IEnumerable<T> items)
        {
            base.AddRange<T>(items);
        }
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Adds the specified items to the collection.
		/// </summary>
		/// <param name="type">The type to organize the items under.</param>
		/// <param name="items">The items to add.</param>
        void ITypedCollection<object, IDirective>.AddRange(Type type, IEnumerable<IDirective> items)
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
        bool ITypedCollection<object, IDirective>.Has<T>(object key)
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
        bool ITypedCollection<object, IDirective>.Has(Type type, object key)
        {
            return base.Has(type, key);
        }
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Gets a value indicating whether one or more items organized under the specified type.
		/// </summary>
		/// <typeparam name="T">The type to check.</typeparam>
		/// <returns><see langword="True"/> if there are such items, otherwise <see langword="false"/>.</returns>
        bool ITypedCollection<object, IDirective>.HasOneOrMore<T>()
        {
            return base.HasOneOrMore<T>();
        }
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Gets a value indicating whether one or more items organized under the specified type.
		/// </summary>
		/// <param name="type">The type check.</param>
		/// <returns><see langword="True"/> if there are such items, otherwise <see langword="false"/>.</returns>
        bool ITypedCollection<object, IDirective>.HasOneOrMore(Type type)
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
        T ITypedCollection<object, IDirective>.Get<T>(object key)
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
        IDirective ITypedCollection<object, IDirective>.Get(Type type, object key)
        {
            return base.Get(type, key);
        }
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Gets the first item in the collection that is organized under the specified type.
		/// </summary>
		/// <typeparam name="T">The type to check.</typeparam>
		/// <returns>The item, or <see langword="null"/> if none has been defined.</returns>
        T ITypedCollection<object, IDirective>.GetOne<T>()
        {
            return base.GetOne<T>();
        }
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Gets the first item in the collection that is organized under the specified type.
		/// </summary>
		/// <param name="type">The type the item is organized under.</param>
		/// <returns>The item, or <see langword="null"/> if none has been defined.</returns>
        IDirective ITypedCollection<object, IDirective>.GetOne(Type type)
        {
            return base.GetOne(type);
        }
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Gets all items organized under the specified type.
		/// </summary>
		/// <typeparam name="T">The type the items are organized under.</typeparam>
		/// <returns>A collection of items organized under the specified type.</returns>
        IList<T> ITypedCollection<object, IDirective>.GetAll<T>()
        {
            return base.GetAll<T>();
        }
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Gets all items organized under the specified type.
		/// </summary>
		/// <param name="type">The type the items are organized under.</param>
		/// <returns>A collection of items organized under the specified type.</returns>
        IList<IDirective> ITypedCollection<object, IDirective>.GetAll(Type type)
        {
            return base.GetAll(type);
        }
		/*----------------------------------------------------------------------------------------*/
		/// <summary>
		/// Gets the types that items are organized under.
		/// </summary>
		/// <returns>A collection of types that items are organized under.</returns>
        IList<Type> ITypedCollection<object, IDirective>.GetTypes()
        {
            return base.GetTypes();
        }
		/*----------------------------------------------------------------------------------------*/
        #endregion
        /*----------------------------------------------------------------------------------------*/
		#region Public Methods
		/// <summary>
		/// Copies the directives from the specified collection.
		/// </summary>
		/// <param name="directives">The collection of directives to copy from.</param>
		public void CopyFrom(IDirectiveCollection directives)
		{
			directives.GetTypes().Each(t => AddRange(t, directives.GetAll(t)));
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
		#region Protected Methods
		/// <summary>
		/// Gets the key for the specified item.
		/// </summary>
		/// <param name="item">The item.</param>
		/// <returns>The key for the item.</returns>
		protected override object GetKeyForItem(IDirective item)
		{
			return item.DirectiveKey;
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
		protected override bool OnKeyCollision(Type type, object key, IDirective newItem, IDirective existingItem)
		{
			// The new directive should only override the old one if the old one was implicit, or they are both explicit.
			return (existingItem.IsExplicit) ? newItem.IsExplicit : true;
		}
		#endregion
		/*----------------------------------------------------------------------------------------*/
	}
}