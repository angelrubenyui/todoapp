using System;
using XForms.Framework;

namespace TodoApp.Forms
{
	public class TodoItem : Entity<string>
	{

		public static readonly string NEW_ID = Guid.NewGuid ().ToString ();
		public const int CREATED = 0;
		public const int UPDATED = 1;
		public const int DELETED = 2;
		public const int SYNCHRONIZATED = 3;

		public int State { get; private set; }

		public string Text { get; set; }

		public bool Complete { get; set; }

		public bool WaitingForSynchronization { get; private set; }

		public TodoItem()
		{
			State = CREATED;
			WaitingForSynchronization = true;
			Id = NEW_ID;
		}

		public void MarkAsCreated()
		{
			State = CREATED;
			WaitingForSynchronization = true;
		}

		public void MarkAsUpdated()
		{
			State = UPDATED;
			WaitingForSynchronization = true;
		}

		public void MarkAsDeleted()
		{
			State = DELETED;
			WaitingForSynchronization = true;
		}

		public void MarkAsSyncrhonizated()
		{
			State = SYNCHRONIZATED;
			WaitingForSynchronization = false;
		}

		public void MarkAsCompleted()
		{
			State = UPDATED;
			Complete = true;
			WaitingForSynchronization = true;
		}

	}
}

