using System;

namespace XForms.Framework
{
	public interface IEntity : IEntity<long>
	{
	}

	public interface IEntity<TPrimaryKey>
	{
		TPrimaryKey Id { get; set; }
	}
}

