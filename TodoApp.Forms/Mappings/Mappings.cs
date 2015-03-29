using System;
using Api = TodoApp.ApiConnector;

namespace TodoApp.Forms
{
	public static class Mappings
	{
		public static void Init()
		{
			AutoMapper.Mapper.CreateMap<TodoItem, Api.TodoItem> ().ReverseMap ();
		}
	}
}

