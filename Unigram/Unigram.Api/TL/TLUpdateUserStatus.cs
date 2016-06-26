// <auto-generated/>
using System;

namespace Telegram.Api.TL
{
	public partial class TLUpdateUserStatus : TLUpdateBase 
	{
		public TLUserStatusBase Status { get; set; }

		public TLUpdateUserStatus() { }
		public TLUpdateUserStatus(TLBinaryReader from, TLType type = TLType.UpdateUserStatus)
		{
			Read(from, type);
		}

		public override TLType TypeId { get { return TLType.UpdateUserStatus; } }

		public override void Read(TLBinaryReader from, TLType type = TLType.UpdateUserStatus)
		{
			UserId = from.ReadInt32();
			Status = TLFactory.Read<TLUserStatusBase>(from);
		}

		public override void Write(TLBinaryWriter to)
		{
			to.Write(0x1BFBD823);
			to.Write(UserId);
			to.WriteObject(Status);
		}
	}
}