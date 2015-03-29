using System;
using System.Collections.Generic;
using SQLite.Net.Attributes;

namespace XForms.Framework
{

	public abstract class Entity : Entity<long>, IEntity<long>
	{
	}

	public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
	{
		/// <summary>
		/// Unique identifier for this entity.
		/// </summary>
		[PrimaryKey]
		public virtual TPrimaryKey Id { get; set; }
	}
}

